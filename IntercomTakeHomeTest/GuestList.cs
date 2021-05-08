using System;
using System.Collections.Generic;

namespace IntercomTakeHomeTest
{
    public class GuestList
    {
        private const double IntercomDublinOfficeLatitude = 53.339428;
        private const double IntercomDublinOfficeLongitude = -6.257664;

        public static string GetListOfCustomersWithin100kmOfIntercomOffice(string fileLocation){
            var customerList = FileConversion.JsonCustomerListToCustomerList("customers.txt");

            var customersWithin100km = new List<Customer>();

            foreach(Customer customer in customerList){

                if(Distance.AreValidCoordinates(customer.Latitude, customer.Longitude)){
                    if(Distance.IsLessThan100KilometersBetweenPoints(customer.Latitude, customer.Longitude, IntercomDublinOfficeLatitude, IntercomDublinOfficeLongitude))
                    {
                        customersWithin100km.Add(customer);
                    }
                } else {
                    Console.WriteLine($"The Coordinates for Customer {customer.Name} are invalid");
                }               
            }
            
            //Sort the users in ascending order by User_Id
            customersWithin100km.Sort((x, y) => x.User_Id.CompareTo(y.User_Id));

            return FileConversion.CustomerListToJson(customersWithin100km);
        }
    }
}
