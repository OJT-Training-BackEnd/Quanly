using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quanly.Models.User
{
    public class User
    {
        public int Id { get; set; }
        [Required, StringLength(30, MinimumLength = 6)]
        public string Username { get; set; } = string.Empty;
        [Required, StringLength(30, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
    }

}