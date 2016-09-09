using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day4.Models
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public Address HomeAddress { get; set; }

        public Role Role { get; set; }
    }
}