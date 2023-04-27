using GraphQL.Types;
using SampleGraphQL.Models;

namespace SampleGraphQL.GraphQL.Types
{
    public class CountryType : ObjectGraphType<Country>
    {
        public CountryType()
        {
            Name = "Country";
            Field(p => p.Id);
            Field(p => p.Name);
            Field(p => p.Alpha2Code);
        }
    }
}

