using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Core.Domain.Repositories;
using Weilog.Entities;

namespace Weilog.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly IRepositoryAsync<Menu> _repository;

        /// <summary>
        /// 初始化 <see cref="UserRepository"/> 类的新实例。
        /// </summary>
        public MenuRepository(IRepositoryAsync<Menu> menuRepository)
        {
            _repository = menuRepository;
        }

        public void AddMenu(Menu menu)
        {
            _repository.Insert(menu);
        }

        public void DeleteMenu(int id)
        {
            _repository.Delete(id);
        }

        public void DeleteMenu(Menu menu)
        {
            _repository.Delete(menu);
        }

        public void UpdateMenu(Menu menu)
        {
            _repository.Update(menu);
        }

        public Menu GetMenu(int id)
        {
            return _repository.Get(id);
        }

        public IList<Menu> GetMenus()
        {
            IList<Menu> menus = new List<Menu>();
            menus = _repository.Queryable(false).ToList();
            return menus;
        }


    }
}
