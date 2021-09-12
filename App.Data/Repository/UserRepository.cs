using App.API.Data.Context;
using App.Domain.Entities;
using App.Domain.Interfaces.Repository;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace App.Data.Repository
{


    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(SampleAppContext db) : base(db)
        {
           
        }

        public async Task<User[]> GetUserByOfficeId(Guid[] officeIds)
        {
            //get users 
            var obj = await Db.Users.AsNoTracking().Include(x => x.Office).ToArrayAsync();

            //search user with id office
            var filter = obj.Where(x => officeIds.Contains(x.Office.Id)).ToArray();

            //get UserRoles
            var userRoles = await this.Db.UserRoles.AsNoTracking().ToArrayAsync();

            //relation between user and userRoles
            var roles = (from m in userRoles
                         join g in filter on m.UserId equals g.Id
                      select userRoles).FirstOrDefault();

            if(roles != null)
            {
                //add roles into User
                foreach (var role in roles)
                {
                    var _user = filter.FirstOrDefault(o => o.Id == role.UserId);
                    if (_user is null)
                    {
                        continue;
                    }

                    if (_user.Roles is null)
                    {
                        _user.Roles = new List<UserRole>();
                    }

                    _user.Roles.Add(role);
                }
            }

           

            return filter;
        }
        
    }
}
