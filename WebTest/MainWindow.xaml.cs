using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows;

namespace WebTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected ObservableCollection<Item> items;
        protected ObservableCollection<Webpage> webpages;
        protected bool usedChangeDetection;

        public MainWindow()
        {
            InitializeComponent();

            usedChangeDetection = false;

            items = new ObservableCollection<Item>();
            dataGrid1.DataContext = items;

            webpages = new ObservableCollection<Webpage>();
            dataGrid2.DataContext = webpages;
        }

        private void Monitor_Refresh()
        {
            Monitor_RefreshButton.IsEnabled = false;

            // Clear previous results
            foreach (Item item in items)
            {
                item.Status = "";
                item.Details = "";
                item.Image = Item.REFRESH_IMAGE;

                //dataGrid1.DataContext = items;
                //dataGrid1.Items.Refresh();
            }

            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext(); // this gets info for the UI thread

            var t = Task.Factory.StartNew(() => // this will run in background on separate thread
            {
                foreach (Item item in items)
                {
                    try
                    {
                        WebRequest request = WebRequest.Create(item.Site);
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        if (response == null || response.StatusCode != HttpStatusCode.OK)
                        {
                            item.Status = "Error";
                            item.Details = response.StatusCode.ToString() + ": " + response.StatusDescription;
                            item.Image = Item.ERROR_IMAGE;
                        }
                        else
                        {
                            item.Status = "OK";
                            item.Details = "";
                            item.Image = Item.CHECKMARK_IMAGE;
                        }
                        response.Close();
                    }
                    catch (Exception ex)
                    {
                        item.Status = "Error";
                        item.Details = ex.Message;
                        item.Image = Item.ERROR_IMAGE;
                    }

                    Task.Factory.StartNew(() => // this will jump back onto the UI thread
                    {
                        //dataGrid1.Items.Refresh();
                    }, System.Threading.CancellationToken.None, TaskCreationOptions.None, uiScheduler);
                }

                Task.Factory.StartNew(() => // this will jump back onto the UI thread
                {
                    Monitor_RefreshButton.IsEnabled = true;
                }, System.Threading.CancellationToken.None, TaskCreationOptions.None, uiScheduler);
            });
        }

        private void Monitor_RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Monitor_Refresh();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("sites.txt"))
            {
                foreach (Item item in items)
                {
                    file.WriteLine(item.Site);
                }
            }

            SerializeItem(webpages, "Webpages.b");
        }

        public static void SerializeItem(ObservableCollection<Webpage> obj, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, obj);
            fs.Close();
        }

        public static ObservableCollection<Webpage> DeserializeItem(string fileName)
        {
            ObservableCollection<Webpage> obj = null;

            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                IFormatter formatter = new BinaryFormatter();
                obj = (ObservableCollection<Webpage>)formatter.Deserialize(fs);
            }
            catch { }

            return obj;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader("sites.txt"))
            {
                while (file.Peek() >= 0)
                {
                    string s = file.ReadLine();
                    Item item = new Item(s);
                    items.Add(item);
                }
            }

            string fileName = "Webpages.b";
            if(File.Exists(fileName))
            {
                webpages = (ObservableCollection<Webpage>)DeserializeItem(fileName);
                dataGrid2.DataContext = webpages;
            }

            Monitor_Refresh();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            dataGrid1.Width = e.NewSize.Width - 100;
            dataGrid2.Width = e.NewSize.Width - 100;
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_DeleteRow_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedItems.Count > 0)
            {
                // Check to make sure last row isn't selected
                if (dataGrid1.SelectedItems.Count == 1)
                {
                    const string NewItemPlaceholderName = "{NewItemPlaceholder}";

                    if (dataGrid1.SelectedValue.ToString() == NewItemPlaceholderName)
                        return;
                }

                List<string> urls = new List<string>();

                // Copy URLs to be deleted
                foreach (Item i in dataGrid1.SelectedItems)
                {
                    urls.Add(i.Site);
                }

                // Find URLs within "items" and RemoveAt()
                foreach (string s in urls)
                {
                    int index = -1;

                    bool found = false;
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].Site == s)
                        {
                            index = i;
                            found = true;
                            break;
                        }
                    }

                    if (found && index != -1)
                    {
                        items.RemoveAt(index);
                    }
                }
            }
        }

        private void MenuItem_DeleteRow2_Click(object sender, RoutedEventArgs e)
        {
            // !!!
        }

        public static void OpenWebsite(string url)
        {
            System.Diagnostics.Process.Start(GetDefaultBrowserPath(), url);
        }

        private static string GetDefaultBrowserPath()
        {
            string key = @"http\shell\open\command";
            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(key, false);
            return ((string)registryKey.GetValue(null, null)).Split('"')[1];
        }

        private void Changes_RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Changes_Refresh();
        }

        private void Changes_Refresh()
        {
            Changes_RefreshButton.IsEnabled = false;

            foreach (Webpage webpage in webpages)
            {
                webpage.Image = Webpage.REFRESH_IMAGE;
            }

            dataGrid2.Items.Refresh();

            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext(); // this gets info for the UI thread
            var t = Task.Factory.StartNew(() => // this will run in background on separate thread
            {
                foreach (Webpage webpage in webpages)
                {
                    webpage.Refresh();
                }

                Task.Factory.StartNew(() => // this will jump back onto the UI thread
                {
                    Changes_RefreshButton.IsEnabled = true;
                }, System.Threading.CancellationToken.None, TaskCreationOptions.None, uiScheduler);
            });
        }

        private void DG2_Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Documents.Hyperlink link = (System.Windows.Documents.Hyperlink)e.OriginalSource;
            OpenWebsite(link.NavigateUri.AbsoluteUri);
        }

        private void MenuItem_Reset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid2.SelectedItem != null)
                {
                    Webpage item = dataGrid2.SelectedItem as Webpage;
                    item.ResetCache();
                }
            }
            catch { }
        }

        private void tabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                System.Windows.Controls.TabItem tab = tabControl.SelectedItem as System.Windows.Controls.TabItem;

                if (tab.Header.ToString() == "Change Detection")
                {
                    if(usedChangeDetection == false) // run automatically only the first time
                        Changes_Refresh();

                    usedChangeDetection = true;
                    tab.Focus();
                }
            }
            catch { }
        }
    }
}
