using GraphQL.Types;
using SampleGraphQL.Models;

namespace SampleGraphQL.GraphQL.Types
{
    public class RangeFilterInputType<T> : InputObjectGraphType<RangeFilter<T>>
    {
        public RangeFilterInputType()
        {
            Field(x => x.Min, nullable: true);
            Field(x => x.Max, nullable: true);
        }
    }

}
