using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsAdministrator(Guid userId);

        Task<User> GetAsync(Guid user);

        Task<List<User>> GetByOfficesAsync(string officeIds);

        Task<User> GetByIdAsync(Guid id);

    }
}
