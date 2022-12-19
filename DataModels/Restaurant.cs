using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataModels.Annotations;

namespace DataModels
{
    public class Restaurant : INotifyPropertyChanged
    {
        private string _businessName;
        private string _address;
        private float _latitude;
        private float _longitude;
        private string _rating;
        private string _businessType;
        private DateTime _ratingDate;

        public DateTime RatingDate
        {
            get { return _ratingDate; }
            set
            {
                if (value.Equals(_ratingDate)) return;
                _ratingDate = value;
                OnPropertyChanged();
            }
        }

        public string BusinessType
        {
            get { return _businessType; }
            set
            {
                if (value == _businessType) return;
                _businessType = value;
                OnPropertyChanged();
            }
        }


        public string BusinessName
        {
            get { return _businessName; }
            set
            {
                if (value == _businessName) return;
                _businessName = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (value == _address) return;
                _address = value;
                OnPropertyChanged();
            }
        }

        public float Latitude
        {
            get { return _latitude; }
            set
            {
                if (value.Equals(_latitude)) return;
                _latitude = value;
                OnPropertyChanged();
            }
        }

        public float Longitude
        {
            get { return _longitude; }
            set
            {
                if (value.Equals(_longitude)) return;
                _longitude = value;
                OnPropertyChanged();
            }
        }

        public string Rating
        {
            get { return _rating; }
            set
            {
                if (value == _rating) return;
                _rating = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
