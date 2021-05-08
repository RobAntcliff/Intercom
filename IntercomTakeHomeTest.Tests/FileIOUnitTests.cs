using System;
using Xunit;
using System.Collections.Generic;

namespace IntercomTakeHomeTest.Tests
{
    public class FileIOUnitTests
    {
        [Fact]
        public void Given_EmptyTextFile_When_JsonCustomerListToCustomerListCalled_Then_EmptyListReturned(){
            List<Customer> result = FileIO.JsonCustomerListToCustomerList("../../../TestFiles/EmptyTextFile.txt");

            Assert.Empty(result);
        }

        [Fact]
        public void Given_SingleCustomerInTextFile_When_JsonCustomerListToCustomerListCalled_Then_ListWithSingleCustomerReturned(){
            List<Customer> result = FileIO.JsonCustomerListToCustomerList("../../../TestFiles/SingleCustomerWithin100Km.txt");

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
            List<Customer> result = FileIO.JsonCustomerListToCustomerList("../../../TestFiles/ThreeCustomersWithin100Km.txt");

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
            List<Customer> result = FileIO.JsonCustomerListToCustomerList("123.txt");

            Assert.Empty(result);
        }

        [Fact]
        public void Given_InvalidJsonData_When_JsonCustomerListToCustomerListCalled_Then_EmptyCustomerListReturned(){
            List<Customer> result = FileIO.JsonCustomerListToCustomerList("../../../TestFiles/InvalidCustomerData.txt");

            Assert.Empty(result);
        }

        
    }
}