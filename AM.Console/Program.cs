// See https://aka.ms/new-console-template for more information

using AM.ApplicationCore.Domain;


#region

/*
// Constructeur par défaut  
Plane plan1 = new Plane();
plan1.Capacity = 1000; 
plan1.PlaneId= 1;
plan1.ManufactureDate= DateTime.Now;


// constructeur paramètré 
Plane plane2 = new Plane(100, DateTime.Now, 1,PlaneType.Boing);

// constructeur a  n  params 
Plane plane3 = new Plane(190,DateTime.Now); 

Console.WriteLine("plane instance was created !");
*/
#endregion


// initialiseur d'objet 
Plane plane4 = new Plane
{
    Capacity = 1000,
    PlaneId = 1,
    ManufactureDate = DateTime.Now,
 
};

Plane plane5 = new Plane
{
    Capacity = 1000,
};


Passenger passenger1 = new Passenger
{
   FirstName = "ahmed" , 
   LastName = "gouiaa" , 
   EmailAddress="ahmed.gouiaa@esprit.tn"
};

Staff staff1 = new()
{
    FirstName = "ahmed",
    LastName = "debbiche",
    EmailAddress = "ahmed.debbiche@esprit.tn"
};
Traveller traveller = new()
{
    FirstName = "mahdi",
    LastName = "Dridi",
    EmailAddress = "mahdi.dridi@esprit.tn"

};

 


Console.WriteLine(passenger1.login("ahmed", "gouiaa"));
Console.WriteLine(passenger1.login("ahmed", "gouiaa","ahmed.debbiche@esprit.tn"));
passenger1.PassengerType();  // cette methode va printer "I am passenger "


