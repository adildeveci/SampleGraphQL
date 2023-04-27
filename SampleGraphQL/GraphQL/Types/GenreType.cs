using GraphQL.Types;
using SampleGraphQL.Models;

namespace SampleGraphQL.GraphQL.Types
{
    public class GenreType : ObjectGraphType<Genre>
    {
        public GenreType()
        {
            Name = "Genre";
            Field(p => p.Id);
            Field(p => p.Name);
        }
    }
}

