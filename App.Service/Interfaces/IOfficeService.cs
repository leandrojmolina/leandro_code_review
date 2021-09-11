using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Interfaces
{
    public interface IOfficeService
    {
        Task<List<Office>> GetAsync(string searchPattern);
    }
}
