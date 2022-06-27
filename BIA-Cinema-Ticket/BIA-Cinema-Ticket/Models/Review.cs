using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIA_Cinema_Ticket.Models
{
    public class Review
    {
        public int comment_ID { get;set; }
        public String commentText { get; set; }
        public bool isSpoiler { get; set; }
        public int movie_ID { get; set; }
        public int user_ID { get; set; }
        public String nickName { get; set; }
        public int rate { get; set; }
    }
}
