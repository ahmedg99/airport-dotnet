using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
 using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
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
                        select new { flight.FlightDate, flight.Destination }; 
                        //or select ( flight.FlightDate, flight.Destination )  

                        ;
           
            
            //query.ToList().ForEach(flight => { Console.WriteLine("destination : " + flight.Destination + "date : " + flight.FlightDate); }); 
            foreach(var flight in query)
            {
                Console.WriteLine(flight.Destination);
            }

            // avec lamda expression 1

            query.ToList().ForEach(flight => { Console.WriteLine(flight.Destination); });


            // another query 
            var query2 = plane.flights
                         .Select(f => (f.FlightDate, f.Destination));

            query2.ToList().ForEach(flight => { Console.WriteLine(flight); });








         }


        public int ProgrammedFlightNumber(DateTime startDate) {
            // ************** methode 0 **************:

            //int nbFlights = 0;
            /*
            foreach (var flight in listeFlights)
            {
                if((flight.FlightDate>startDate) &&(flight.FlightDate<startDate.AddDays(7)))
                {
                    nbFlights++;
                }
            }
            
            return  nbFlights;
        
        */


            // **************1er methode **************:
            /*
            var query = from flight in listeFlights
                         where (flight.FlightDate > startDate && flight.FlightDate < startDate.AddDays(7))
                         select flight; 
            
            return query.Count() ;
            */


            // **************2eme methode   in lambda functions we do not put select clause :*************** 
            return listeFlights.Where(p => (p.FlightDate <= startDate) && (p.FlightDate >= startDate.AddDays(7))).Count();



          }



       public double    DurationAverage(string destination)
        {

            // methode 1 
            /*
            var query = from flight in listeFlights
                        where (flight.Destination==destination)
                        select flight.EstimatedDuration;

            return query.Average();
            */

            //  method 2  : 
            return (listeFlights.Where(f => f.Destination.Equals(destination)).Average(flight => flight.EstimatedDuration));

         }


        public void OrderedDurationFlights()
        {
            var query = from flight in listeFlights
                        orderby flight.EstimatedDuration descending
                        select flight;
            Console.WriteLine("les Vols ordonnés par EstimatedDuration du plus long au plus court");


            foreach (var flight in query)
            {
                Console.WriteLine(flight.ToString());  
            }
            // avec lambda 
            query.ToList().ForEach(f => Console.WriteLine(f.ToString()));

        }

       public  List<Flight> OrderedDurationFlights1()
        {
     
             return listeFlights.OrderByDescending(lf=>lf.EstimatedDuration).ToList();
        }


        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
             
            var queryPasseger = from p in flight.Passengers.OfType<Traveller>() 
                                orderby p.BirthDate 
                                 select p;


            return  queryPasseger.Take(3);


            // other methode :
            // return flight.Passengers.OfType<Traveller>().ToList().OrderBy(p=>p.BirthDate).Take(3); 








            /*
                Console.WriteLine("les 3 passagers, de type traveller, les plus âgés d’un vol");

                foreach (var p in queryPasseger.Take(3))
                {
                    Console.WriteLine(p.ToString());
                }
                */



            //avec lambda 
            //   queryPasseger.Take(3).ToList().ForEach(p => Console.WriteLine(p.ToString())) ;



        }

        public void DestinationGroupedFlights()
        {

            var query = from f in listeFlights.GroupBy(f => f.Destination)  
                         select f;






            Console.WriteLine("les vols groupés par destination");



            // avec for each  
            foreach (var group in query)
            {
                var groupKey = group.Key;
                Console.WriteLine("Destination " + groupKey);

                foreach (var groupedItem in group)
                {
                    Console.WriteLine("Décollage : " + groupedItem.FlightDate  ); 
                }

              // avec lambda 
                
                query.ToList().ForEach(group =>
                {
                    var groupKey = group.Key;
                    Console.WriteLine("Destination " + groupKey);
                    group.ToList().ForEach(groupItem => {
                        Console.WriteLine("Décollage : " + groupItem.FlightDate);
                    }); 
                }); 
                 




            }


        }
 
    }
}
