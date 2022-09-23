using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}