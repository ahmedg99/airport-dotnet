﻿using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public  interface IServiceFlight
    {
        public IList<DateTime> GetFlightDates(string destination);
        public IList<Flight> GetFlights(string filterType, string filterValue);

        public void ShowFlightDetails(Plane plane);
        // fgh

        public int ProgrammedFlightNumber(DateTime startDate);
        public double DurationAverage(string destination);
        public List<Flight> OrderedDurationFlights();
        public List<Flight> OrderedDurationFlights1();


        public IEnumerable<Traveller> SeniorTravellers(Flight flight);
        public Dictionary<String, List<Flight>> DestinationGroupedFlights();


    }
}
