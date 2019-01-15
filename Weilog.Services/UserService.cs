using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using Weilog.Entities;
using Weilog.Repositories;

namespace Weilog.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public User GetUser(string username)
        {
            return _userRepository.Get(username);
        }
        public IList<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void DeleteUser(User user)
        {
            _userRepository.DeleteUser(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }

        public User GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }
    }
}
