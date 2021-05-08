using System;
using System.Text.Json.Serialization;

namespace IntercomTakeHomeTest
{
    public class Customer
    {
        public string Name {get; set;}
        public int User_Id {get; set;}
        [JsonIgnore]
        public double Latitude { get; set; }
        [JsonIgnore]
        public double Longitude { get; set; }

        public Customer(string name, int user_id, double latitude, double longitude)
        {
            Name = name;
            User_Id = user_id;
            Latitude = latitude;
            Longitude = longitude;
        }
    }    
}
