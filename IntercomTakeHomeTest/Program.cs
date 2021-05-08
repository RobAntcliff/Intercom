using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace IntercomTakeHomeTest
{
    class Program
    {
        private const double IntercomDublinOfficeLatitude = 53.339428;
        private const double IntercomDublinOfficeLongitude = -6.257664;

        static async Task Main(string[] args)
        {
            var customerList = FileIO.JsonCustomerListToCustomerList("customers.txt");

            var customersWithin100km = new List<Customer>();

            foreach(Customer customer in customerList){
                if(Distance.GreatCircleDistanceOnEarth(customer.Latitude, customer.Longitude, IntercomDublinOfficeLatitude, IntercomDublinOfficeLongitude) <= 100)
                {
                    customersWithin100km.Add(customer);
                }
            }
            
            //Sort the users in ascending order by User_Id
            customersWithin100km.Sort((x, y) => x.User_Id.CompareTo(y.User_Id));

            await FileIO.CustomerListToJson(customersWithin100km);
        }
    }
}
