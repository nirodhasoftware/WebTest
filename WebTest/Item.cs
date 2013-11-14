using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace WebTest
{
    [Serializable]
    public class Item : ISerializable, INotifyPropertyChanged
    {
        public const string CHECKMARK_IMAGE = "Images/1382978238_checkmark.png";
        public const string ERROR_IMAGE = "Images/1382978241_no_entry.png";
        public const string REFRESH_IMAGE = "Images/1382978244_arrow_cycle.png";
        public const string NO_IMAGE = "Images/blank.png";

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string strPropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(strPropertyName));
        }

        protected string site;
        public string Site
        {
            get
            {
                return site;
            }
            set
            {
                site = value;
                NotifyPropertyChanged("Site");
            }
        }
        protected string status;
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                NotifyPropertyChanged("Status");
            }
        }
        protected string details;
        public string Details
        {
            get
            {
                return details;
            }
            set
            {
                details = value;
                NotifyPropertyChanged("Details");
            }
        }
        protected string image;
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                NotifyPropertyChanged("Image");
            }
        }

        public Item() // ctor
        {
            details = "";
            status = "";
            image = NO_IMAGE;
        }

        public Item(string url) // ctor
        {
            site = url;
            status = "";
            details = "";
            image = NO_IMAGE;
        }

        // Implement this method to serialize data. The method is called on serialization. 
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("site", site, typeof(string));
        }

        // The special constructor is used to deserialize values. 
        public Item(SerializationInfo info, StreamingContext context)
        {
            // Reset the property value using the GetValue method.
            site = (string)info.GetValue("site", typeof(string));
            status = "";
            details = "";
            image = NO_IMAGE;
        }
    }
}
