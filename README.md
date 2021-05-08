# Intercom Take Home Test

A program written in C# using .Net 5. This program takes a list of customers in a .txt file in a Json format and returns a list of these customers that are within 100Km of the Intercom office.

- The Program Logic is contained in IntercomTakeHomeTest Folder. Written in C#.
- The Tests are contained in the IntercomTakeHomeTest.Tests Folder. Written in C# and uses the xUnit testing framework.

Each Class in the IntercomTakeHomeTest Folder has a corresponding Test class in the IntercomTakeHomeTest.Tests Folder, except for Program.cs as this is just the entry point for the program.

## Structure

### Program.cs

The entrypoint for the program. When you run ```dotnet run```, the Main method in here will be called.

### GuestList.cs

This is where the main business logic is for getting the list of users within 100km of the office. The logic is built in such a way that it mainly just uses methods from Distance.cs and FileConversion.cs as this modularises the logic and makes it easier to test.

### FileConversion.cs

This is where we convert the text data to Customer objects and vice versa.

### Distance.cs

This is where the logic for calculating the distance between 2 points on Earth and if these points are more or less than 100km apart.

### Customer.cs

This class defines the object that we use to structure our customer data from the input file.

## Setup & Execution

Install .Net 5 : https://dotnet.microsoft.com/download

Clone this repo to your local machine

In your Command Line, navigate to the IntercomTakeHomeTest folder.

Run this command: ```dotnet run```

## Testing

After following the setup instructions above, In your Command Line, navigate to the IntercomTakeHomeTest.Test folder.

Run this command: ```dotnet test```

Example Output:

![image](https://user-images.githubusercontent.com/9054477/117555038-aca1ef80-b053-11eb-99c1-56607e298b97.png)


## Output

Sample output from the provided customers.txt file:

``` 
[
  {
    "Name": "Ian Kehoe",
    "User_Id": 4
  },
  {
    "Name": "Nora Dempsey",
    "User_Id": 5
  },
  {
    "Name": "Theresa Enright",
    "User_Id": 6
  },
  {
    "Name": "Eoin Ahearn",
    "User_Id": 8
  },
  {
    "Name": "Richard Finnegan",
    "User_Id": 11
  },
  {
    "Name": "Christina McArdle",
    "User_Id": 12
  },
  {
    "Name": "Olive Ahearn",
    "User_Id": 13
  },
  {
    "Name": "Michael Ahearn",
    "User_Id": 15
  },
  {
    "Name": "Patricia Cahill",
    "User_Id": 17
  },
  {
    "Name": "Eoin Gallagher",
    "User_Id": 23
  },
  {
    "Name": "Rose Enright",
    "User_Id": 24
  },
  {
    "Name": "Stephen McArdle",
    "User_Id": 26
  },
  {
    "Name": "Oliver Ahearn",
    "User_Id": 29
  },
  {
    "Name": "Nick Enright",
    "User_Id": 30
  },
  {
    "Name": "Alan Behan",
    "User_Id": 31
  },
  {
    "Name": "Lisa Ahearn",
    "User_Id": 39
  }
]
```
