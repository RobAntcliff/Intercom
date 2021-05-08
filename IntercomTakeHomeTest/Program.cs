using System;

namespace IntercomTakeHomeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string guestList = GuestList.GetListOfCustomersWithin100kmOfIntercomOffice("customers.txt");

            Console.WriteLine(guestList);
        }
    }
}
