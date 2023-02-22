using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //Id , ID , PassengerId ces nom vont etre par defaut primary key 
        public int Id { get; set; }
        public string  ? PassportNumber { get; set; }
        public string ?  FirstName { get; set; }
        public string  ? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int TelNumber { get; set; }
        public string  ? EmailAddress { get; set; }
        public  ICollection<Flight> ? Flights { get; set; }

        // polymorphisme signature : 
        // 1 er methode 
        public bool checkProfile(string nom, string prenom)
        {

            return (FirstName.Equals(prenom) && LastName.Equals(nom)); 
 
        }
        // 2 eme methode 
        public bool checkProfile(string nom, string prenom, string email)
        {
            return (FirstName.Equals(prenom) && LastName.Equals(nom)&& EmailAddress.Equals(email));
        }
        //3eme methode login  : 

        public bool login(string nom , string prenom , string email=null)
        {
            if(email!=null)
                return checkProfile(nom, prenom, email);
            return checkProfile(prenom, nom);
            
            //return email != null ? checkProfile(prenom, nom, email) : checkProfile(prenom, nom);  
        }

        public override string? ToString()
        {
            return "passport id : " + PassportNumber + "first name : " + FirstName  ;
        }


        // abstarct used only on abstarct classes 
        // virtual je peux ajouter de l'implémentation a la methode  
        // virtual permet d'héhriter la méthode  
        public virtual void PassengerType()
        {
            // cwl (shortcut to write " console.writeln " ) + 2 tab 
            System.Console.WriteLine("I am a passenger ");
         }

        
             


    }



}
