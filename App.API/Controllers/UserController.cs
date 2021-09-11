using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.API.Models;
using App.API.Services;
using App.Domain.Interfaces;
using App.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : BaseController
    {
        private readonly INotifier _notifier;
        private readonly IMapper _mapper;

        public UserController(INotifier notifier,
                              IUserService userService,
                              IMapper mapper) : base(notifier, userService)
        {
            this._notifier = notifier;
            this._mapper = mapper;
        }

        /// <summary>
        /// GetUsers
        /// </summary>
        /// <param name="officeIds"></param>
        [HttpGet]
        [Route("getUsers")]
        public async Task<List<User>> GetUsers(string officeIds)
        {
            try
            {
                //check de string, if it is null then fill the variable
                if (officeIds == null)
                    officeIds = string.Empty;

                // get user by id office 
                var obj = await _userService.GetByOfficesAsync(officeIds);

                //map objects
                var mapper_ = _mapper.Map<List<User>>(obj);

                return mapper_;
            }
            catch(Exception ex)
            {
                //if get an error notify.
                _notifier.Handle(new Domain.Notifications.Notification(ex.Message, false));
                _notifier.GetNotifications(); // possibility to implement and send the error *BadRequest(_notifier.GetNotifications());
                return new List<User>();
            }
           
        }
    }
}
