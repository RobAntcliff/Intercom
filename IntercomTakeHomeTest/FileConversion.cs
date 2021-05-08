using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace IntercomTakeHomeTest
{
    public class FileConversion
    {
        public static List<Customer> JsonCustomerListToCustomerList(string fileLocation){

            var customerList = new List<Customer>();

            string line;

            try{
                using(System.IO.StreamReader file = new System.IO.StreamReader(@""+ fileLocation + ""))
                {
                    while((line = file.ReadLine()) != null)
                    {  
                        Customer customer = JsonConvert.DeserializeObject<Customer>(line);
                        
                        //If there's no name or customer Id then the data must be invalid
                        if(customer.Name != null || customer.User_Id != 0){
                            customerList.Add(customer);
                        } else {
                            Console.WriteLine("Please make sure that your input data is valid");
                        }
                    }
                }                
            } catch (IOException ex) {
                Console.WriteLine($"Exception Occured: {ex}");
                return customerList;
            }

            return customerList;
        }

        public static string CustomerListToJson(List<Customer> customerList){

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = System.Text.Json.JsonSerializer.Serialize(customerList, options);

            return json;
        }
    }
}
