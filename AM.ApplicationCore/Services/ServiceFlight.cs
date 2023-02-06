using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {

        IList<Flight> listeFlights = new List<Flight>() ; 

        public IList<DateTime> GetFlightDates(string destination)
        {
            /* avec forEach
            List<DateTime> listeDates = new List<DateTime>() ; 
            
            foreach (var flight in listeFlights)
            {
                if(flight.Destination == destination)
                  listeDates.Add(flight.FlightDate) ;
                
            }
             return listeDates;
            */


            // avec langage Link
            var query = from flight in listeFlights
                        where flight.Destination == destination
                        select flight.FlightDate  ;
            // query par défaut tarjja3 liste enumerable donc ncastiwha el list
            return query.ToList() ; 
        }

        public IList<Flight> GetFlights(string filterType, string filterValue)
        {

            List<Flight> list = new List<Flight>(); 
            foreach(var flight in listeFlights)
            {

                switch(filterType)
                {
                    case "Destination": 
                        {
                           if(flight.Destination.Equals(filterValue))
                                list.Add(flight) ;
                            break;
                        }
                 }

                
            }

            return null;

         }

        public void ShowFlightDetails(Plane plane)
        {
             var query = from flight in listeFlights
                        where flight.plane == plane
                        select new { flight.FlightDate, flight.Destination }   
                        ;
       

           // query.ToList().ForEach(flight => { Console.WriteLine("destination : " + flight.Destination + "date : " + flight.FlightDate); }); 
 
         }
    }
}
