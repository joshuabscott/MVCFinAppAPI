using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinAppAPI.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int HouseHoldId { get; set; }
        public HouseHold HouseHold { get; set; }

        public DateTime Created { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public bool IsRead { get; set; }
    }
}
