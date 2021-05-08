using System;
using Xunit;
using System.Collections.Generic;

namespace IntercomTakeHomeTest.Tests
{
    public class FileConversionUnitTests
    {
        [Fact]
        public void Given_EmptyTextFile_When_JsonCustomerListToCustomerListCalled_Then_EmptyListReturned(){
            List<Customer> result = FileConversion.JsonCustomerListToCustomerList("../../../TestFiles/EmptyTextFile.txt");

            Assert.Empty(result);
        }

        [Fact]
        public void Given_SingleCustomerInTextFile_When_JsonCustomerListToCustomerListCalled_Then_ListWithSingleCustomerReturned(){
            List<Customer> result = FileConversion.JsonCustomerListToCustomerList("../../../TestFiles/SingleCustomerWithin100Km.txt");

            Assert.NotEmpty(result);
            foreach(Customer customer in result){
                Assert.Equal(53.2451100, customer.Latitude);
                Assert.Equal(4, customer.User_Id);
                Assert.Equal("Jane Doe", customer.Name);
                Assert.Equal(-6.238350, customer.Longitude);
            }
        }

        [Fact]
        public void Given_MultipleCustomersInTextFile_When_JsonCustomerListToCustomerListCalled_Then_ListWithMultipleCustomersReturned(){
            List<Customer> result = FileConversion.JsonCustomerListToCustomerList("../../../TestFiles/ThreeCustomersWithin100Km.txt");

            Assert.NotEmpty(result);
            foreach(Customer customer in result){
                Assert.Equal(53.2451100, customer.Latitude);
                Assert.Equal(4, customer.User_Id);
                Assert.Equal("Jane Doe", customer.Name);
                Assert.Equal(-6.238350, customer.Longitude);
            }
        }

        [Fact]
        public void Given_InvalidFilePath_When_JsonCustomerListToCustomerListCalled_Then_EmptyCustomerListReturned(){
            List<Customer> result = FileConversion.JsonCustomerListToCustomerList("123.txt");

            Assert.Empty(result);
        }

        [Fact]
        public void Given_InvalidJsonData_When_JsonCustomerListToCustomerListCalled_Then_EmptyCustomerListReturned(){
            List<Customer> result = FileConversion.JsonCustomerListToCustomerList("../../../TestFiles/InvalidCustomerData.txt");

            Assert.Empty(result);
        }

        [Fact]
        public void Given_ValidCustomerList_When_CustomerListToJson_Then_ExpectedJsonReturned(){
            
            Customer customer = new Customer("Jane Doe", 123, 80.0, 80.0);
            List<Customer> customerList = new List<Customer>();
            customerList.Add(customer);

            string expectedJson = "[\r\n  {\r\n    \"Name\": \"Jane Doe\",\r\n    \"User_Id\": 123\r\n  }\r\n]";

            string json = FileConversion.CustomerListToJson(customerList);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Given_EmptyCustomerList_When_CustomerListToJson_Then_ExpectedJsonReturned(){
            
            List<Customer> customerList = new List<Customer>();

            string expectedJson = "[]";

            string json = FileConversion.CustomerListToJson(customerList);

            Assert.Equal(expectedJson, json);
        }
    }
}