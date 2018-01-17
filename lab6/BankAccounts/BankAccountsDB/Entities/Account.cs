using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankAccountsDB.Entities
{
    [Table("Account")]
    public class Account : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Number { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public int Points { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int CardId { get; set; }

        public virtual Card Card { get; set; }
    }
}
