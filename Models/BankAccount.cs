using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCFinAppAPI.Enums;

namespace MVCFinAppAPI.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int HouseHoldId { get; set; }
        public HouseHold HouseHold { get; set; }

        public string FAUserId { get; set; }
        public FAUser FAUser { get; set; }
        public string Name { get; set; }

        public AccountType Type { get; set; }

        public decimal StartingBalance { get; set; }
        public decimal? CurrentBalance { get; set; }
    }
}
