using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomerReading.Entities
{
        public class UserLogin
        {
            [Required]
            public string UserName { get; set; }
            [Required]
            public string Password { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }
        }
}
