using DiffMatchPatch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace WebTest
{
    [Serializable]
    public class Webpage : ISerializable, INotifyPropertyChanged
    {
        public const string REFRESH_IMAGE = "Images/1382978244_arrow_cycle.png";
        public const string CHANGED_IMAGE = "Images/1383098581_burn.png";
        public const string SAME_IMAGE = "Images/blank.png"; 
        public const string ERROR_IMAGE = "Images/1382978241_no_entry.png";
        public const string NO_IMAGE = "Images/blank.png"; 

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string strPropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(strPropertyName));
        }

        // Member Variables
        protected string _cache;

        // Default Constructor
        public Webpage()
        {
            _url = "";
            _cache = "";
            //_lastUpdate = null;
            _threshold = 5.0;
            _percentChanged = 0.0;
            _image = NO_IMAGE;
        }

        // Alternate Constructor
        public Webpage(string url) 
        {
            _url = url;
            _cache = "";
            //_lastUpdate = null;
            _threshold = 5.0;
            _percentChanged = 0.0;
            _image = NO_IMAGE;
        }

        // Implement this method to serialize data. The method is called on serialization. 
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            try
            {
                // Use the AddValue method to specify serialized values.
                info.AddValue("_url", _url, typeof(string));
                info.AddValue("_lastUpdate", _lastUpdate, typeof(DateTime));
                info.AddValue("_cache", _cache, typeof(string));
                info.AddValue("_threshold", _threshold, typeof(double));
            }
            catch { }
        }

        // The special constructor is used to deserialize values. 
        public Webpage(SerializationInfo info, StreamingContext context)
        {
            try
            {
                // Reset the property value using the GetValue method.
                _url = (string)info.GetValue("_url", typeof(string));
                _lastUpdate = (DateTime)info.GetValue("_lastUpdate", typeof(DateTime));
                _cache = (string)info.GetValue("_cache", typeof(string));
                _threshold = (double)info.GetValue("_threshold", typeof(double));
            }
            catch
            {
                if (_url == null) _url = "";
                if (_cache == null) _cache = "";
                if (_threshold == null) _threshold = 5.0;
            }
            finally
            {
                _percentChanged = 0.0;
                _image = NO_IMAGE;
            }
        }

        // Getters and Setters    
        protected string _url;
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                SetUrl(value);                
            }
        }
        protected DateTime _lastUpdate;
        public string LastUpdate
        {
            get
            {
                return _lastUpdate.ToString("MMM d h:mm tt");
            }
            //set
            //{
            //    SetLastUpdate(value);
            //}
        }
        protected double _threshold;     
        public string Threshold
        {
            get
            {
                return _threshold.ToString("F");
            }
            set
            {
                SetThreshold(value);
            }
        }
        protected double _percentChanged;
        public string PercentChanged
        {
            get
            {
                return _percentChanged.ToString("F");
            }
            set
            {
                double d;
                try
                {
                    d = System.Convert.ToDouble(value);
                }
                catch
                {
                    d = 0.0;
                }

                SetPercentChanged(d);
            }
        }
        protected string _image;
        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                SetImage(value);
            }
        }

        // Member Functions

        protected void SetUrl(string value)
        {
            _url = value;
            NotifyPropertyChanged("Url");
            ResetCache();
        }

        protected void SetLastUpdate(DateTime value)
        {
            _lastUpdate = value;
            NotifyPropertyChanged("LastUpdate");
        }

        protected void SetPercentChanged(double value)
        {
            try
            {
                _percentChanged = value;

                if (_percentChanged == -1)
                {
                    SetImage(ERROR_IMAGE);
                }
                else
                {
                    if (_percentChanged < _threshold)
                        SetImage(SAME_IMAGE);
                    else
                        SetImage(CHANGED_IMAGE);
                }
            }
            catch { }

            NotifyPropertyChanged("PercentChanged");
        }

        protected void SetImage(string value)
        {
            _image = value;
            NotifyPropertyChanged("Image");
        }

        protected void SetThreshold(string value)
        {
            try
            {
                _threshold = System.Convert.ToDouble(value);
            }
            catch
            {
                _threshold = 5.0;
            }

            NotifyPropertyChanged("Threshold");
            Refresh();
        }

        // Take a new snapshot of webpage, update timestamp, refresh dependent properties
        public void ResetCache()
        {
            _cache = Helpers.WebHelper.DownloadWebPage(_url);
            SetLastUpdate(DateTime.Now);

            Refresh();
        }

        // Calculate the percentage changed
        public void Refresh()
        {
            try
            {
                double percentDifferent = CalculatePercentChanged();
                SetPercentChanged(percentDifferent);
            }
            catch { }
        }

        public double CalculatePercentChanged()
        {
            string page1 = _cache;
            string page2 = Helpers.WebHelper.DownloadWebPage(_url);
            if (page2 == "")
            {
                Error();
                return -1.0;
            }

            diff_match_patch difflib = new diff_match_patch();
            List<Diff> list = difflib.diff_main(page1, page2);

            double levenshtein = difflib.diff_levenshtein(list);
            double length = (page1.Length > page2.Length) ? page1.Length : page2.Length;

            double percentDifferent = levenshtein / length * 100;

            return percentDifferent;
        }

        protected void Error()
        {
            // ???
            // set picture to error
            // do not display status 
        }
    }
}
