using System;
using System.Collections.Generic;
using System.Text;
using RealEstate.Database.Models;

namespace RealEstate.DataAccess.Repositories.Contracts
{
    public interface IBillRepository
    {
        IEnumerable<Bill> GetAllForProperty(int propertyId);
        IEnumerable<Bill> GetAllForProperty(int propertyId, int lastAmount);

        IEnumerable<Bill> GetAll();

    }
}
