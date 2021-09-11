using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class User: Entity
    {
        public string Login { get; set; }
        public Office Office { get; set; }
        public List<UserRole> Roles { get; set; }
    }
}
