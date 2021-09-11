using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Domain.Interfaces.Repository;
using App.Service.Interfaces;
using App.Service.Services;

namespace App.API.Services
{

    public class UserService: BaseService, IUserService
    {
        private readonly INotifier _notifier;
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;


        public UserService(INotifier notifier, IUserRepository userRepository, IUserRoleRepository userRoleRepository) : base(notifier)
        {
            this._notifier = notifier;
            this._userRepository = userRepository;
            this._userRoleRepository = userRoleRepository;
        }

        public Task<bool> IsAdministrator(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(Guid user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetByOfficesAsync
        /// </summary>
        /// <param name="officeIds"></param>
        public async Task<List<User>> GetByOfficesAsync(string officeIds)
        {
            //check de string param
            Guid[] ids = officeIds
               .Split(",", StringSplitOptions.RemoveEmptyEntries)
               .Select(o => Guid.Parse(o))
               .ToArray();

            //Get users by office id
            var users = await this._userRepository.GetUserByOfficeId(ids);


            return users.ToList();
        }

    }
}
