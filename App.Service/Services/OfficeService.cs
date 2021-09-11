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
    public class OfficeService: BaseService, IOfficeService
    {
        private readonly INotifier _notifier;
        private readonly IOfficeRepository _officeRepository;

        public OfficeService(INotifier notifier, IOfficeRepository officeRepository) : base(notifier)
        {
            this._notifier = notifier;
            this._officeRepository = officeRepository;
        }

        public async Task<List<Office>> GetAsync(string officeIds)
        {
            return await _officeRepository.GetAsync();
        }
    }
}
