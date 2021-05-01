using System.Collections.Generic;
using System.Linq;
using RealEstate.DataAccess.Repositories.Contracts;
using RealEstate.Database;
using RealEstate.Database.Models;

namespace RealEstate.DataAccess.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly RealEstateContext _db;

        public BillRepository(RealEstateContext db)
        {
            _db = db;
        }

        public IEnumerable<Bill> GetAllForProperty(int propertyId)
        {
            return _db.Bills.Where(x => x.PropertyId == propertyId);
        }
        public IEnumerable<Bill> GetAllForProperty(int propertyId, int lastAmount)
        {
            return _db.Bills.Where(x => x.PropertyId == propertyId)
                .OrderByDescending(x => x.DateCreated)
                .Take(lastAmount);
        }

        public IEnumerable<Bill> GetAll()
        {
            return _db.Bills;
        }
    }
}
