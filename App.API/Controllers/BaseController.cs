using App.API.Services;
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    public class BaseController: ControllerBase
    {
        private readonly INotifier _notifier;
        public readonly IUserService _userService;
        public User LoggedUser;

        public BaseController(INotifier notifier,
                              IUserService userService)
        {
            this._notifier = notifier;
            this._userService = userService;
        }

        protected async Task<bool> UserIsAdministratorAsync(Guid userId)
        {
            return await _userService.IsAdministrator(userId);
        }


        protected bool ValidOperation()
        {
            return !_notifier.HaveNotification();
        }
    }
}
