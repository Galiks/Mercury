using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_4
{
    class Post
    {
        public int UserId { get; private set; }
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Body { get; private set; }

        public Post(int userId, int id, string title, string body)
        { 
            UserId = userId;
            Id = id;
            Title = title;
            Body = body;
        }
    }
}
