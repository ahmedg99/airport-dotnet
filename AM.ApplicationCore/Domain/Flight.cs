﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }

        public string Source { get; set; }



        public int PlaneFK { get; set; }

       // [ForeignKey("PlaneFK")]
        public Plane Plane { get; set; }
        public ICollection<Passenger> Passengers { get; set; }

        public string AirlineLog { get; set; }


        public String toString()
        {
           
            return " flight id  " + FlightId +
                    " flight date  " + FlightDate +
                    "EstimatedDuration " + EstimatedDuration
                    + "EffectiveArrival" + EffectiveArrival
                    ;
        }

   



    }
}
    