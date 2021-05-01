using System.Collections.Generic;
using GraphQL.Types;
using RealEstate.Types.Property;
using RealEstate.DataAccess.Repositories.Contracts;
using RealEstate.Types.Payment;

namespace RealEstate.API.Queries
{
    public class PropertyQuery : ObjectGraphType
    {
        public PropertyQuery(IPropertyRepository propertyRepository, IBillRepository billRepository)
        {
            Field<ListGraphType<PropertyType>>(
                "properties",
                resolve: context => propertyRepository.GetAll());

            Field<PropertyType>(
                "property",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => propertyRepository.GetById(context.GetArgument<int>("id")));

            Field<ListGraphType<BillType>>(
                "bills",
                resolve: context => billRepository.GetAll());
        }
    }
}