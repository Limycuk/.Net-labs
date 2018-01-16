using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankAccountsDB.Entities
{
    [Table("User")]
    public class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
