using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Entities;

namespace Weilog.Repositories
{
    public interface IMenuRepository
    {
        void AddMenu(Menu user);

        IList<Menu> GetMenus();
    }
}
