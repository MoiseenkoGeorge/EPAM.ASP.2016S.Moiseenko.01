using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day3.Infrastructure
{
    public static class StaticUserRepository
    {
        public static List<User> Users { get; set; } = new List<User>()
        {
            new User() {Name = "Dart", Surname = "Veider", Side = Side.Dark},
            new User() {Name = "Obi-Van", Surname = "Kenobi", Side = Side.Light}
        };
    }
}