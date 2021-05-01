using GraphQL.Types;
using RealEstate.DataAccess.Repositories.Contracts;
using RealEstate.Types.Payment;

namespace RealEstate.Types.Property
{
    public class PropertyType : ObjectGraphType<Database.Models.Property>
    {
        public PropertyType(IPaymentRepository paymentRepository, IBillRepository billRepository)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Value);
            Field(x => x.City);
            Field(x => x.Family);
            Field(x => x.Street);
            Field<ListGraphType<PaymentType>>("payments",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "last"}),
                resolve: context =>
                {
                    var lastItemsFilter = context.GetArgument<int?>("last");
                    return lastItemsFilter != null
                        ? paymentRepository.GetAllForProperty(context.Source.Id, lastItemsFilter.Value)
                        : paymentRepository.GetAllForProperty(context.Source.Id);
                });

            Field<ListGraphType<BillType>>("bills",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "last" }),
                resolve: context =>
                {
                    var lastItemsFilter = context.GetArgument<int?>("last");
                    return lastItemsFilter != null
                        ? billRepository.GetAllForProperty(context.Source.Id, lastItemsFilter.Value)
                        : billRepository.GetAllForProperty(context.Source.Id);
                });
        }
    }
}