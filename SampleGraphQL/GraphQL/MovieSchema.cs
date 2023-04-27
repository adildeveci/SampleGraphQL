using GraphQL.Types;

namespace SampleGraphQL.GraphQL
{

    public class MovieSchema : Schema
    { 
        public MovieSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        { 
            Query = serviceProvider.GetRequiredService<MovieQuery>();
        }
    }
}
