using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace IntercomTakeHomeTest
{
    class FileIO
    {
        public static List<Customer> JsonCustomerListToCustomerList(string fileLocation){

            var customerList = new List<Customer>();

            string line;           

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@""+ fileLocation + "");
            while((line = file.ReadLine()) != null)
            {  
                Customer customer = JsonConvert.DeserializeObject<Customer>(line);
                
                customerList.Add(customer);
            }

            file.Close();

            return customerList;            
        }

        public static void CustomerListToTextFile(List<Customer> customerList){

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = System.Text.Json.JsonSerializer.Serialize(customerList, options);

            File.WriteAllText("Output/CustomersWithin100Kilometers" + DateTime.Now.Ticks + ".txt", json);
        }
    }
}
