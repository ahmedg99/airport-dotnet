﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmployementDate { get; set; }
        public Double Salary { get; set; }
        public string Function { get; set; }


        // override indique qu'on peut réimplémenter la méthode PassengerType()
        public override void PassengerType()
        {
            base.PassengerType(); // implémentation de la méthode PassengerType de la classe mere
            Console.WriteLine("I am staff");
        }
    }




}
