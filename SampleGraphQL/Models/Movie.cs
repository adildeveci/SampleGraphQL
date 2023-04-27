namespace SampleGraphQL.Models
{
    public class Movie
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ImdbRate { get; set; } 
        public DateTime ReleaseDate { get; set; }
        public Country CountryOfOrigin { get; set; }
        public List<Genre> Genres { get; set; }
        public Person Director { get; set; } 
        public List<Person> Stars { get; set; } 

    }

    public class MovieFilter
    {
        public int? Id { get; set; }

        public string Name { get; set; }
        public int? GenreId { get; set; }
        public RangeFilter<decimal> ImdbRate { get; set; }

    }
}
