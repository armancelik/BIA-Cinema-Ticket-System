using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIA_Cinema_Ticket.Models
{
    public class Cinema
    {
        public int cinema_ID { get; set; }
        public String cinemaName { get; set; }
        public String city { get; set; }
        public String addressText { get; set; }
    }
}
