using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Core.AnimationMetrics;

namespace DataModels
{
    public class RestaurantViewModel
    {
        public ObservableCollection<Restaurant> Restaurants { get; set; }

        public RestaurantViewModel()
        {
            Restaurants = new ObservableCollection<Restaurant>();
            LoadData();
        }

        public async void LoadData()
        {
            
            var document =
                await XmlDocument.LoadFromUriAsync(new Uri("http://ratings.food.gov.uk/OpenDataFiles/FHRS814en-GB.xml"));
            foreach (var node in document.SelectNodes("FHRSEstablishment/EstablishmentCollection/EstablishmentDetail"))
            {
                var restaurant = new Restaurant();
                var businessNameNode = node.SelectSingleNode("BusinessName");
                if (businessNameNode != null)
                    restaurant.BusinessName = businessNameNode.InnerText;

                var addressLine1Node = node.SelectSingleNode("AddressLine1");
                if (addressLine1Node != null)
                    restaurant.Address = addressLine1Node.InnerText;

                var latitudeNode = node.SelectSingleNode("Geocode/Latitude");
                if (latitudeNode != null)
                    restaurant.Latitude = float.Parse(latitudeNode.InnerText);

                var longitudeNode = node.SelectSingleNode("Geocode/Longitude");
                if (longitudeNode != null)
                    restaurant.Longitude = float.Parse(longitudeNode.InnerText);

                var ratingValueNode = node.SelectSingleNode("RatingValue");
                if (ratingValueNode != null)
                    restaurant.Rating = ratingValueNode.InnerText;

                var businessTypeNode = node.SelectSingleNode("BusinessType");
                if (businessTypeNode != null)
                    restaurant.BusinessType = businessTypeNode.InnerText;

                Restaurants.Add(restaurant);
            }
        }
    }
}
