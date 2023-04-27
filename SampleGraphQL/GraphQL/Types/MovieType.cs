using GraphQL;
using GraphQL.Types;
using SampleGraphQL.Models;
using System.Xml.Linq;

namespace SampleGraphQL.GraphQL.Types
{
    public class MovieType : ObjectGraphType<Movie>
    {
        public MovieType()
        {
            Name = "Movie";
            Field(p => p.Id);
            Field(p => p.Name);
            Field(p => p.Description);
            Field(p => p.ImdbRate);
            Field(p => p.ReleaseDate);
            Field<CountryType>("CountryOfOrigin", resolve: _ => _.Source.CountryOfOrigin);
            Field<PersonType>("Director", resolve: _ => _.Source.Director);
            Field<ListGraphType<GenreType>>("Genres", resolve: _ => _.Source.Genres);//for nested list
            Field<ListGraphType<PersonType>>("Stars", resolve: _ => _.Source.Stars);//for nested list

        }


    }

    public class MovieFilterType : InputObjectGraphType<MovieFilter>
    {
        public MovieFilterType()
        {
            Field(x => x.Id, nullable: true);
            Field(x => x.Name, nullable: true);
            Field(x => x.GenreId, nullable: true);
            Field<RangeFilterInputType<int>>("ImdbRate", resolve: _ => _.Source.ImdbRate);
        }
    }
}

