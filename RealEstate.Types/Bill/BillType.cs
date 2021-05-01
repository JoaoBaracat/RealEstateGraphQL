using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;

namespace RealEstate.Types.Payment
{
    public class BillType : ObjectGraphType<Database.Models.Bill>
    {
        public BillType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Value);
            Field(x => x.DateCreated);
            Field(x => x.DateOverdue);
            Field(x => x.Paid);
        }
    }
}
