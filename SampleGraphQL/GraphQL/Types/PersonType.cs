using GraphQL.Types;
using SampleGraphQL.Models;

namespace SampleGraphQL.GraphQL.Types
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Name = "Person";
            Field(p => p.Id);
            Field(p => p.Name); 
        }
    }
}

