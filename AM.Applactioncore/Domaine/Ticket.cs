﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applactioncore.Domaine
{
    public class Ticket
    {
      
      
        public double prix { get; set; }
        public string Siege { get; set; }

        public Boolean VIP { get; set; }

        [ForeignKey("PassengerFk")]
        public virtual Passenger Passenger { get; set; }
        public string PassengerFk { get; set; }

        [ForeignKey("FlightFk")]
        public virtual Flight Flight { get; set; }
        public int FlightFk { get; set; }

    }
}
