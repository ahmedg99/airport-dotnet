using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Plane
    {


        // prop + 2 tab

        [Range(1,int.MaxValue)]
 public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public  PlaneType PlaneType { get; set; }
  
        public ICollection<Flight>  ? flights { get; set;}
         

    }

}




