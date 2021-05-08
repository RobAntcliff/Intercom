using System;
using System.Collections.Generic;

namespace IntercomTakeHomeTest
{
    public class GuestList
    {
        private const double IntercomDublinOfficeLatitude = 53.339428;
        private const double IntercomDublinOfficeLongitude = -6.257664;

        /// <summary>
        /// Gets a list of customers that are within 100 Kilometers of the Intercom office
        /// </summary>
        /// <returns>
        /// Json list of customers that are within 100 Kilometers of the Intercom office
        /// </returns>
        /// <param name="fileLocation">Location of the text file</param>
        public static string GetListOfCustomersWithin100kmOfIntercomOffice(string fileLocation){
            var customerList = FileConversion.JsonCustomerListToCustomerList(@"" + fileLocation + "");

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
            SortCustomerList(customersWithin100km);

            return FileConversion.CustomerListToJson(customersWithin100km);
        }

        /// <summary>
        /// Sorts a List of Customer Objects in ascendin order by UserId
        /// </summary>
        /// <param name="customerList">List of Customer objects to be sorted</param>
        public static void SortCustomerList(List<Customer> customerList){
            customerList.Sort((x, y) => x.User_Id.CompareTo(y.User_Id));
        }
    }
}
