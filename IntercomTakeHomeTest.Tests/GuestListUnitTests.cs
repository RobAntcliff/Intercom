using System;
using System.IO;
using Xunit;
using System.Collections.Generic;

namespace IntercomTakeHomeTest.Tests
{
    public class GuestListUnitTests
    {
        [Fact]
        public void Given_AFileContainingAListOfCustomers_When_GetListOfCustomersWithin100kmOfIntercomOffice_Then_ExpectedListReturned(){
            
            string expectedResult = File.ReadAllText("../../../TestFiles/customersToInvite.txt");

            string result = GuestList.GetListOfCustomersWithin100kmOfIntercomOffice("../../../TestFiles/customers.txt");
            
            Assert.Equal(expectedResult, result);            
        }

        [Fact]
        public void Given_AnEmptyFile_When_GetListOfCustomersWithin100kmOfIntercomOffice_Then_EmptyListReturned(){
            
            string expectedResult = "[]";

            string result = GuestList.GetListOfCustomersWithin100kmOfIntercomOffice("../../../TestFiles/EmptyTextFile.txt");
            
            Assert.Equal(expectedResult, result);            
        }

        [Fact]
        public void Given_FileContainingOneCustomeOutside100KmLimit_When_GetListOfCustomersWithin100kmOfIntercomOffice_Then_EmptyListReturned(){
            
            string expectedResult = "[]";

            string result = GuestList.GetListOfCustomersWithin100kmOfIntercomOffice("../../../TestFiles/SingleCustomerOutside100KmLimit.txt");
            
            Assert.Equal(expectedResult, result);            
        }

        [Fact]
        public void Given_FileContainingOneCustomeInside100KmLimit_When_GetListOfCustomersWithin100kmOfIntercomOffice_Then_EmptyListReturned(){
            
            string expectedResult = "[\r\n  {\r\n    \"Name\": \"Jane Doe\",\r\n    \"User_Id\": 4\r\n  }\r\n]";

            string result = GuestList.GetListOfCustomersWithin100kmOfIntercomOffice("../../../TestFiles/SingleCustomerWithin100Km.txt");
            
            Assert.Equal(expectedResult, result);            
        }

        [Fact]
        public void Given_AnUnsortedListOfCustomers_When_SortCustomerList_Then_ListSortedByCustomerId(){
            
            List<Customer> customerList = new List<Customer>();

            var rand = new Random();

            for (int ctr = 0; ctr <= 10; ctr++) {
                int userId = rand.Next(1, 101);
                Customer customer = new Customer("Jane Doe", userId, 10.0, 10.0);
                customerList.Add(customer);
            }

            GuestList.SortCustomerList(customerList);

            for(int i = 1; i < customerList.Count; i++){
                Assert.True(customerList[i].User_Id >= customerList[i - 1].User_Id);
            }
        }
    }
}