using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Entities;

namespace Weilog.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        User Get(string username);
        IList<User> GetUsers();
        void AddUser(User user);

        void DeleteUser(int id);

        void DeleteUser(User user);

        void UpdateUser(User user);

        User GetUser(int id);
    }
}
