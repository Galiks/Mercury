using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_3.Entities
{
    class MovieActor
    {
        public int MovieId { get; private set; }
        public int ActorId { get; private set; }

        public MovieActor(int movieId, int actorId)
        {
            MovieId = movieId;
            ActorId = actorId;
        }
    }
}
