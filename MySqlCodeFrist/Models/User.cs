using System;
using System.ComponentModel.DataAnnotations;

namespace MySqlCodeFrist.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(32), Required]
        public string Aaccount { get; set; }

        [MaxLength(32), Required]
        public string Password { get; set; }
    }
}
