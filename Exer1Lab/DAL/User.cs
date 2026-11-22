using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class User
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
