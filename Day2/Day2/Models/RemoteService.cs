using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Day2.Models
{
    public class RemoteService
    {
        public async Task<List<User>> AddUser(User user)
        {
            return await Task<List<User>>.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                List<User> users = new List<User> {user};
                return users;
            });
        }
    }
}