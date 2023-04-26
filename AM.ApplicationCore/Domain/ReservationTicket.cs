using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class ReservationTicket
    {

        
        public DateTime DateReservation { get; set; }
        public float prix { get; set; }

        public string PassengerFK { get; set; }
        public int TicketFK { get; set; }


        [ForeignKey("TicketFK")]
        public Ticket Ticket { get; set; }
        [ForeignKey("PassengerFK")]
        public Passenger Passenger{ get; set; }

    }

}
