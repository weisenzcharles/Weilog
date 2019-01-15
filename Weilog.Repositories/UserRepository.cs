using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Core.Domain.Repositories;
using Weilog.Entities;

namespace Weilog.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IRepositoryAsync<User> _repository;

        /// <summary>
        /// 初始化 <see cref="UserRepository"/> 类的新实例。
        /// </summary>
        public UserRepository(IRepositoryAsync<User> userRepository)
        {
            _repository = userRepository;
        }

        public void Add(User user)
        {
            _repository.Insert(user);
        }

        public User Get(string username)
        {
            return _repository.Find(username);
        }

        public IList<User> GetUsers()
        {
            IList<User> users = new List<User>();
            users = _repository.Queryable(false).ToList();
            return users;
        }

        public void AddUser(User user)
        {
            _repository.Insert(user);
        }

        public void DeleteUser(int id)
        {
            _repository.Delete(id);
        }

        public void DeleteUser(User user)
        {
            _repository.Delete(user);
        }

        public void UpdateUser(User user)
        {
            _repository.Update(user);
        }

        public User GetUser(int id)
        {
            return _repository.Get(id);
        }

    }
}
