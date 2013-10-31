using System;
using System.IO;
using System.Net;

namespace WebTest.Helpers
{
    class WebHelper
    {
        public static string DownloadWebPage(string URL)
        {
            // Exception handling
            try
            {
                if (URL == null || URL == "")
                    return "";

                try
                {
                    Uri temp = new Uri(URL);
                }
                catch
                {
                    URL = "http://" + URL;
                    Uri temp = new Uri(URL);
                }
            }
            catch
            {
                return "";
            }

            HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
            //request.Credentials = new NetworkCredential(Settings.Default.LicenseUser, Settings.Default.LicensePassword);
            request.KeepAlive = false;
            request.Timeout = 5000;
            request.Proxy = null;

            request.ServicePoint.ConnectionLeaseTimeout = 5000;
            request.ServicePoint.MaxIdleTime = 5000;

            // Read stream
            string responseString = String.Empty;
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream objStream = response.GetResponseStream())
                    {
                        using (StreamReader objReader = new StreamReader(objStream))
                        {
                            responseString = objReader.ReadToEnd();
                            objReader.Close();
                        }
                        objStream.Flush();
                        objStream.Close();
                    }
                    response.Close();
                }
            }
            catch (WebException ex)
            {
                ////throw new LicenseServerUnavailableException();
                //CraigslistReader.Helpers.Logger.LogMessageToFile("DownloadWebPage[1]: Tried to access " + URL);
                //CraigslistReader.Helpers.Logger.LogMessageToFile(ex.Message, ex.StackTrace);
            }
            catch(Exception e)
            {
                //CraigslistReader.Helpers.Logger.LogMessageToFile("DownloadWebPage[2]: Tried to access " + URL);
                //CraigslistReader.Helpers.Logger.LogMessageToFile(e.Message, e.StackTrace);
            }
            finally
            {
                request.Abort();
            }

            return responseString;
        }
    }
}
