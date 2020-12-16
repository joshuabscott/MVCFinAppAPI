using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVCFinAppAPI.Models
{
    public class FAUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public byte[] FileData { get; set; }
        public string FileName { get; set; }

        public int? HouseHoldId { get; set; }
    }
}
