using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFinAppAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int HouseHoldId { get; set; }
        public HouseHold HouseHold { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
