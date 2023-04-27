using GraphQL;
using GraphQL.Types;
using SampleGraphQL.GraphQL.Types;
using SampleGraphQL.Models;
using System.Xml.Linq;

namespace SampleGraphQL.GraphQL
{
    public class MovieQuery : ObjectGraphType//<object>
    {
        public MovieQuery(MovieContext _MovieContext)
        {
            Name = "Movie_Query"; 

            Field<ListGraphType<MovieType>>("Movies",
            arguments: new QueryArguments
            {
                     new QueryArgument<MovieFilterType>{
                         Name="filter"
                     },
            },
         resolve: ctx => _MovieContext.GetMovies(ctx.GetArgument<MovieFilter>("filter")));


            Field<ListGraphType<GenreType>>("Genres",
                resolve: ctx => _MovieContext.GetGenres());

              
        }
    }


}
