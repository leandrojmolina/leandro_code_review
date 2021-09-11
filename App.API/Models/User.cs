using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Models
{
    public class User: BaseModel
    {
        public string Login { get; set; }
        public Office Office { get; set; }
        public List<UserRole> Roles { get; set; }
    }
    

    
}
