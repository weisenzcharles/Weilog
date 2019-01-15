using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Entities;
using Weilog.Repositories;

namespace Weilog.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;


        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public void Add(Menu user)
        {
            _menuRepository.AddMenu(user);
        }

        public IList<Menu> GetMenus()
        {
            return _menuRepository.GetMenus();
        }
    }
}
