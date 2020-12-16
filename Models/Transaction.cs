using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCFinAppAPI.Enums;

namespace MVCFinAppAPI.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public int? CategoryItemId { get; set; }
        public CategoryItem CategoryItem { get; set; }

        public int BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        public string FAUserId { get; set; }
        public FAUser FAUser { get; set; }

        public DateTime Created { get; set; }
        public TransactionType Type { get; set; }

        public string Memo { get; set; }
        public decimal Amount { get; set; }

        public bool IsDeleted { get; set; }
    }
}
