using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.API.Data;
using App.API.Models;
using App.API.Services;
using App.Domain.Interfaces;
using App.Service.Interfaces;
using AutoMapper;
using AutoMapper.Configuration;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.API.Controllers
{
    [ApiController]
    [Route("offices")]
    public class OfficeController : BaseController
    {
        private readonly INotifier _notifier;
        private readonly IMapper _mapper;
        private readonly IOfficeService _officeService;

        public OfficeController(INotifier notifier,
                              IUserService userService, IOfficeService officeService,
                              IMapper mapper): base(notifier, userService)
        {
            this._notifier = notifier;
            this._mapper = mapper;
            this._officeService = officeService;
        }

        /// <summary>
        /// GetOffices
        /// </summary>
        /// <param name="searchPattern"></param>
        [HttpGet]
        [Route("getOffices")]
        public async Task<IEnumerable<Office>> GetOffices(string searchPattern)
        {
            try
            {
                //check de string, if it is null then fill the variable
                if (searchPattern == null)
                    searchPattern = string.Empty;

                //get all office or by searchPattern
                List<App.Domain.Entities.Office> _object = await this._officeService.GetAsync(searchPattern);

                //map objects
                var return_ = _mapper.Map<List<Office>>(_object.Where(x => x.Address.Contains(searchPattern)));

                return return_;
            }
            catch(Exception ex)
            {
                //if get an error, notify.
                _notifier.Handle(new Domain.Notifications.Notification(ex.Message, false));
                _notifier.GetNotifications(); // possibiliti to implement and send the error *BadRequest(_notifier.GetNotifications());
                return new List<Office>();
            }
           
        }

        //old code 
            //// to avoid additional allocations
            //=> context.Query<Office>($@"select * from Offices where lower(Address) like lower('%{searchPattern}%')");       
            
    }
}
