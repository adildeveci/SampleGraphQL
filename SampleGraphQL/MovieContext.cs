using Microsoft.Extensions.Hosting;
using SampleGraphQL.Models;

namespace SampleGraphQL
{

    public class MovieContext
    {
        private readonly List<Genre> _genre = new List<Genre>();
        private readonly List<Country> _country = new List<Country>();
        private readonly List<Movie> _movie = new List<Movie>();
        private readonly List<Person> _person = new List<Person>();

        public MovieContext()
        {

            #region Fill Genre

            List<Enums.Genre> genres = Enum.GetValues(typeof(Enums.Genre)).Cast<Enums.Genre>().ToList();
            foreach (var item in genres)
            {
                _genre.Add(new Genre
                {
                    Id = (int)item,
                    Name = item.ToString()
                });
            }

            #endregion

            #region Fill Country


            _country.Add(new Country
            {
                Id = 1,
                Name = "Turkey",
                Alpha2Code = "TR"
            });
            _country.Add(new Country
            {
                Id = 2,
                Name = "United States of America",
                Alpha2Code = "US"
            });
            _country.Add(new Country
            {
                Id = 3,
                Name = "United Kingdom of Great Britain",
                Alpha2Code = "GB"
            });
            _country.Add(new Country
            {
                Id = 4,
                Name = "China",
                Alpha2Code = "CN"
            });
            _country.Add(new Country
            {
                Id = 3,
                Name = "India",
                Alpha2Code = "IN"
            });

            #endregion

            #region Fill Person

            _person.Add(new Person
            {
                Id = 1,
                Name = "Stephen King"
            });
            _person.Add(new Person
            {
                Id = 2,
                Name = "Morgan Freeman"
            });
            _person.Add(new Person
            {
                Id = 3,
                Name = "Tim Robbins"
            });
            _person.Add(new Person
            {
                Id = 4,
                Name = "Bob Gunton"
            });

            _person.Add(new Person
            {
                Id = 5,
                Name = "Christian Bale"
            });

            _person.Add(new Person
            {
                Id = 6,
                Name = "Heath Ledger"
            });
            _person.Add(new Person
            {
                Id = 7,
                Name = "Aaron Eckhart"
            });
            _person.Add(new Person
            {
                Id = 8,
                Name = "Christopher Nolan"
            });

            _person.Add(new Person
            {
                Id = 9,
                Name = "Keanu Reeves"
            });
            _person.Add(new Person
            {
                Id = 10,
                Name = "Laurence Fishburne"
            });
            _person.Add(new Person
            {
                Id = 11,
                Name = "Carrie-Anne Moss"
            });

            _person.Add(new Person
            {
                Id = 12,
                Name = "Hugo Weaving"
            });

            #endregion

            #region Fill Movie

            _movie.Add(new Movie
            {
                Id = 1,
                Name = "Esaretin Bedeli",
                Genres = _genre.Where(x => x.Id == (int)Enums.Genre.Drama).ToList(),
                ImdbRate = 9.3M,
                ReleaseDate = new DateTime(1994, 9, 10),
                CountryOfOrigin = _country.SingleOrDefault(X => X.Alpha2Code == "US"),
                Description = "Birkaç yıl boyunca, iki hükümlü bir dostluk kurar, teselli arar ve nihayetinde temel şefkatle kefaret arar.",
                Director = _person.FirstOrDefault(x => x.Name == "Stephen King"),
                Stars = _person.Where(x => x.Name == "Tim Robbins" || x.Name == "Morgan Freeman" || x.Name == "Bob Gunton").ToList(),
            });

            _movie.Add(new Movie
            {
                Id = 2,
                Name = "Baba",
                Genres =  _genre.Where(x => x.Id == (int)Enums.Genre.Drama || x.Id == (int)Enums.Genre.Crime).ToList(),
                ImdbRate = 9.2M,
                ReleaseDate = new DateTime(1972, 3, 14),
                CountryOfOrigin = _country.SingleOrDefault(X => X.Alpha2Code == "US"),
                Description = "Savaş sonrası New York City'deki bir organize suç hanedanının yaşlanan reisi, gizli imparatorluğunun kontrolünü gönülsüz en küçük oğluna devreder.",
                Director = _person.FirstOrDefault(x => x.Name == "Francis Ford Coppola"),
                Stars = _person.Where(x => x.Name == "Marlon Brando" || x.Name == "Al Pacino" || x.Name == "James Caan").ToList(),
            });

            _movie.Add(new Movie
            {
                Id = 3,
                Name = "Kara Şövalye",
                Genres =_genre.Where(x => x.Id == (int)Enums.Genre.Drama || x.Id == (int)Enums.Genre.Crime || x.Id == (int)Enums.Genre.Action).ToList(),
                ImdbRate = 9.0M,
                ReleaseDate = new DateTime(2008, 7, 14),
                CountryOfOrigin = _country.SingleOrDefault(X => X.Alpha2Code == "US"),
                Description = "Joker olarak bilinen tehdit, Gotham halkını kasıp kavurup kaosa yol açtığında, Batman, adaletsizlikle savaşma yeteneğinin en büyük psikolojik ve fiziksel testlerinden birini kabul etmek zorundadır.",
                Director = _person.FirstOrDefault(x => x.Name == "Christopher Nolan"),
                Stars =   _person.Where(x => x.Name == "Christian Bale" || x.Name == "Heath Ledger" || x.Name == "Aaron Eckhart").ToList(),
            });

            _movie.Add(new Movie
            {
                Id = 4,
                Name = "Matrix",
                Genres = _genre.Where(x => x.Id == (int)Enums.Genre.Drama || x.Id == (int)Enums.Genre.Crime).ToList(),
                ImdbRate = 9.0M,
                ReleaseDate = new DateTime(1999, 3, 24),
                CountryOfOrigin = _country.SingleOrDefault(X => X.Alpha2Code == "US"),
                Description = "Güzel bir yabancı, bilgisayar korsanı Neo'yu ürkütücü bir yeraltı dünyasına götürdüğünde, şok edici gerçeği keşfeder - bildiği hayat, şeytani bir siber zekanın ayrıntılı aldatmacasıdır.",
                Director = _person.FirstOrDefault(x => x.Name == "Christopher Nolan"),
                Stars =  _person.Where(x => x.Name == "Keanu Reeves" || x.Name == "Laurence Fishburne" || x.Name == "Carrie-Anne Moss" || x.Name == "Hugo Weaving").ToList(),
            });

            #endregion

        }

        public List<Movie> GetMovies(MovieFilter filter)
        {
            var movies = _movie.AsQueryable();
            if (filter != null)
            {
                if (filter.Id.HasValue)
                {
                    movies = movies.Where(x => x.Id == filter.Id);
                }
                if (!string.IsNullOrWhiteSpace(filter.Name))
                {
                    movies = movies.Where(x => x.Name.Contains(filter.Name));
                }
                if (filter.GenreId.HasValue)
                {
                    ; movies = movies.Where(x => x.Genres.Any(x => x.Id == filter.GenreId));
                }
                if (filter.ImdbRate != null)
                {
                    if (filter.ImdbRate.Min > 0)
                    {
                        movies = movies.Where(x => x.ImdbRate >= filter.ImdbRate.Min);
                    }

                    if (filter.ImdbRate.Max > 0)
                    {
                        movies = movies.Where(x => x.ImdbRate <= filter.ImdbRate.Max);
                    }
                }
            }
            return movies.ToList();
        }

        public List<Genre> GetGenres()
        {
            return _genre;
        }
    }
}
