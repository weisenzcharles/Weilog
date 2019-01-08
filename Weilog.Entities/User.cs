using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weilog.Core.Domain.Entities;

namespace Weilog.Entities
{
    public class User: EntityBase
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
