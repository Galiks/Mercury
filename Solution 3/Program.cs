using NLog;
using Solution_3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_3
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private static Random random = new Random();

        static void Main(string[] args)
        {
            List<Director> directors = new List<Director>();
            List<Actor> actors = new List<Actor>();
            List<Movie> movies = new List<Movie>();
            List<MovieActor> moviesActors = new List<MovieActor>();

            FirstQuery(movies);
            SecondQuery(movies, moviesActors);
            ThirdQuery(actors, movies, moviesActors);
            FourthQuery(directors, movies, moviesActors);
            Console.ReadKey();
        }

        private static void AddDataForFourthQuery(List<Director> directors, List<Actor> actors, List<Movie> movies, List<MovieActor> moviesActors)
        {
            directors.Add(new Director(directors.Count + 1, "TEST DIRECTOR"));
            for (int i = 0; i < 4; i++)
            {
                actors.Add(new Actor(actors.Count + 1, $"TEST ACTOR #{actors.Count + 1}", 19 + i));
            }

            for (int i = 0; i < 4; i++)
            {
                movies.Add(new Movie(movies.Count + 1, $"TEST MOVIE #{movies.Count + 1}", 100,
                    new DateTime(random.Next(1970, 2000), random.Next(1, 12),
                                random.Next(1, 30), 0, 0, 0, 0), 1, 10));
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    moviesActors.Add(new MovieActor(i + 1, j + 1));
                }
            }
        }

        private static void AddRandomDataToLists(List<Director> directors, List<Actor> actors, List<Movie> movies, List<MovieActor> moviesActors)
        {
            for (int i = 0; i < 50; i++)
            {
                directors.Add(new Director(directors.Count + 1, $"DirectorName{directors.Count + 1}"));
                actors.Add(new Actor(actors.Count + 1, $"ActorName{actors.Count + 1}", actors.Count + 18));
            }
            for (int i = 0; i < 50; i++)
            {
                try
                {
                    movies.Add(new Movie(movies.Count + 1, $"MovieTitle{movies.Count + 1}",
                                random.Next(50, 240),
                                new DateTime(random.Next(1970, 2015), random.Next(1, 12),
                                random.Next(1, 30), 0, 0, 0, 0),
                                random.Next(1, directors.Count), random.Next(1, 10)));
                }
                catch (ArgumentOutOfRangeException e)
                {
                    i--;
                    logger.Error(e);
                    continue;
                }
            }

            for (int i = 0; i < 20; i++)
            {
                moviesActors.Add(new MovieActor(random.Next(1, movies.Count), random.Next(1, actors.Count)));
            }
        }

        private static void FourthQuery(List<Director> directors, List<Movie> movies, List<MovieActor> moviesActors)
        {
            Console.WriteLine("FourthQuery");
            var result = (from m in movies
                          join ma in moviesActors on m.Id equals ma.MovieId
                          join d in directors on m.DirectorId equals d.Id
                          where
                            m.Rating >= 8 &&
                            m.DurationMinutes >= 60 &&
                            m.ReleaseDate <= new DateTime(2005, 01, 01, 0, 0, 0, 0)
                          group d by new
                          {
                              d.Name,
                              m.Title
                          } into g
                          where g.Count() >= 3 && g.Count() <= 7
                          select new
                          {
                              g.Key.Name,
                          }).ToHashSet();
            if (result.Count() != 0)
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                Console.WriteLine("List is empty!");
            }
        }

        private static void ThirdQuery(List<Actor> actors, List<Movie> movies, List<MovieActor> moviesActors)
        {
            Console.WriteLine("ThirdQuery");
            var result = from m in movies
                         join ma in moviesActors on m.Id equals ma.MovieId
                         join a in actors on ma.ActorId equals a.Id
                         where
                           m.Rating >= 9
                         orderby
                           a.Name ascending,
                           a.Age descending
                         select new
                         {
                             a.Name,
                             a.Age
                         };
            if (result.Count() != 0)
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.Name + " " + item.Age);
                }
            }
            else
            {
                Console.WriteLine("List is empty!");
            }
        }

        private static void SecondQuery(List<Movie> movies, List<MovieActor> moviesActors)
        {
            Console.WriteLine("SecondQuery");
            var result = from ma in moviesActors
                         join m in movies on ma.MovieId equals m.Id
                         group m by new
                         {
                             m.Title
                         } into g
                         select new
                         {
                             g.Key.Title,
                             Count_of_Actors = g.Count()
                         };
            
            if (result.Count() != 0)
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.Title.ToString() + " " + item.Count_of_Actors.ToString());
                }
            }
            else
            {
                Console.WriteLine("List is empty!");
            }
        }

        private static void FirstQuery(List<Movie> movies)
        {
            Console.WriteLine("FirstQuery");
            var result = from m in movies
                         where
                           m.ReleaseDate <= new DateTime(2018, 12, 31, 0, 0, 0, 0) &&
                           m.Rating > 7
                         select new
                         {
                             m.Title
                         };
            if (result.Count() != 0)
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.Title);
                }
            }
            else
            {
                Console.WriteLine("List is empty!");
            }
        }
    }
}
