using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_3.Entities
{
    class Movie
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public int DurationMinutes { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public int DirectorId { get; private set; }
        public int Rating { get; private set; }

        public Movie(int id, string title, int durationMinutes, DateTime releaseDate, int directorId, int rating)
        {
            Id = id;
            Title = title;
            DurationMinutes = durationMinutes;
            ReleaseDate = releaseDate;
            DirectorId = directorId;
            Rating = rating;
        }

        public Movie(int id, string title, int durationMinutes, DateTime releaseDate, int directorId)
        {
            Id = id;
            Title = title;
            DurationMinutes = durationMinutes;
            ReleaseDate = releaseDate;
            DirectorId = directorId;
        }
    }
}
