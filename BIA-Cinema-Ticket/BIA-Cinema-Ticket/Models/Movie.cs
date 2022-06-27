using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIA_Cinema_Ticket.Models
{
    public class Movie
    {
        public int movie_ID { get; set; }
        public String description { get; set; }
        public int duration { get; set; }
        public String movieName { get; set; }
        public String viewStatus { get; set; }
        public String trailerLink { get; set; }
        public String director { get; set; }
        public int year { get; set; }
        public int rate { get; set; }
        public string categories { get; set; }
    }
}
