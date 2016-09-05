using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Day2.Models;

namespace Day2.Infrastructure
{
    public static class StaticUserRepository
    {
        public static List<User> users { get; private set; } = new List<User>();

        public static async Task<List<User>> Add(User user)
        {
            return await Task<List<User>>.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                users.Add(user);
                return users;
            });
        }  
    }
}