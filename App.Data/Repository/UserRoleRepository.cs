using App.API.Data.Context;
using App.Domain.Entities;
using App.Domain.Interfaces.Repository;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.Data.Repository
{
    public class UserRoleRepository: Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(SampleAppContext db) : base(db)
        {

        }
    }
}
