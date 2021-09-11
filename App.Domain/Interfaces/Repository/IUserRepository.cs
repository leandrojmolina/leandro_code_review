using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Repository
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User[]> GetUserByOfficeId(Guid[] officeIds);


    }
}
