using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day4.Infrastructure;

namespace Day4.Models
{
    [ModelBinder(typeof(PersonModelBinder))]
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public Address HomeAddress { get; set; }

        public string AddressSummary { get; set; }

        public Role Role { get; set; }
    }
}