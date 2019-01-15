using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Entities;

namespace Weilog.Services
{
    public interface IUserService
    {
        void Add(User user);
        IList<User> GetUsers();
        User GetUser(string username);

        void AddUser(User user);

        void DeleteUser(int id);

        void DeleteUser(User user);

        void UpdateUser(User user);

        User GetUser(int id);
    }
}
