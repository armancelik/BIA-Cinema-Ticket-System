using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIA_Cinema_Ticket.Models
{
    public class User
    {
        public int user_ID { get; set; }
        public String name { get; set; }
        public String surname { get; set; }
        public String nickName { get; set; }
        public bool gender { get; set; }
        public String email { get; set; }
        public String phoneNumber { get; set; }
        public DateTime birthday { get; set; }
        public String password { get; set; }
        public bool userType { get; set; }
    }
}
