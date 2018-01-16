using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankAccountsDB.Entities
{
    [Table("Card")]
    public class Card
    {
        public Card()
        {
            Accounts = new HashSet<Account>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int BalanceCoefficient { get; set; }

        [Required]
        public int ProfitCoefficient { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
