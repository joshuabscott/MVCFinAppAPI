using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinAppAPI.Models
{
    public class Invitation
    {
        public int Id { get; set; }
        public int HouseHoldId { get; set; }
        public HouseHold HouseHold { get; set; }

        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }

        public bool Accepted { get; set; }

        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public Guid Code { get; set; } = Guid.NewGuid();
    }
}
