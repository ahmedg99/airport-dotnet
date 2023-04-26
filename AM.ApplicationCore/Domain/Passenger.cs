using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //Id , ID , PassengerId ces nom vont etre par defaut primary key 
        // public int Id { get; set; }

        
        [Key]
        [StringLength(100)]
        public string  ? PassportNumber { get; set; }
        public FullName FullName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("date of birth")]
        public DateTime BirthDate { get; set; }
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        public int TelNumber { get; set; }
        [EmailAddress]
        public string  ? EmailAddress { get; set; }
        public  ICollection<Flight> ? Flights { get; set; }

        public ICollection<ReservationTicket>? ReservationTickets { get; set; }







        // polymorphisme signature : 
        // 1 er methode 
        public bool checkProfile(string nom, string prenom)
        {

            return (FullName.FirstName.Equals(prenom) && FullName.LastName.Equals(nom)); 
 
        }
        // 2 eme methode 
        public bool checkProfile(string nom, string prenom, string email)
        {
            return (FullName.FirstName.Equals(prenom) && FullName.LastName.Equals(nom)&& EmailAddress.Equals(email));
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
            return "passport id : " + PassportNumber + "first name : " + FullName.FirstName  ;
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
