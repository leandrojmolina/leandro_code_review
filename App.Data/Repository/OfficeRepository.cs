
using App.API.Data.Context;
using App.Domain.Entities;
using App.Domain.Interfaces.Repository;

namespace App.Data.Repository
{
    public class OfficeRepository: Repository<Office>, IOfficeRepository
    {
        public OfficeRepository(SampleAppContext db) : base(db)
        {
        }
    }
}
