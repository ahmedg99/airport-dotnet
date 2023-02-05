using System;
using System.Collections.Generic;
using System.Linq;
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
        public string  ? LasttName { get; set; }
        public DateTime BirthDate { get; set; }
        public int TelNumber { get; set; }
        public string  ? EmailAddress { get; set; }
        public  ICollection<Flight> ? Flights { get; set; }

        public override string? ToString()
        {
            return "passport id : " + PassportNumber + "first name : " + FirstName  ;
        }



    }
}
