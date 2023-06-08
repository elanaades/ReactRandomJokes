using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactRandomJokes.Data
{
    public class JokesRepository
    {
        private readonly string _connectionString;

        public JokesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Exists(int id)
        {
            using var context = new JokeManagerDataContext(_connectionString);
            return context.Jokes.Any(j => j.LitId == id);
        }

        public void AddJoke(Joke j)
        {
            using var context = new JokeManagerDataContext(_connectionString);
            context.Jokes.Add(j);
            context.SaveChanges();
        }

        public Joke GetByOriginId(int LitId)
        {
            using var context = new JokeManagerDataContext(_connectionString);
            return context.Jokes.FirstOrDefault(j => j.LitId == LitId);
        }
        public UserLikedJokes GetLike(int userId, int jokeId)
        {
            using var context = new JokeManagerDataContext(_connectionString);
            return context.UserLikedJokes.FirstOrDefault(u => u.UserId == userId && u.JokeId == jokeId);
        }

        public void InteractWithJoke(int userId, int jokeId, bool like)
        {
            using var context = new JokeManagerDataContext(_connectionString);
            var userLike = context.UserLikedJokes.FirstOrDefault(u => u.UserId == userId && u.JokeId == jokeId);
            if (userLike == null)
            {
                context.UserLikedJokes.Add(new UserLikedJokes
                {
                    UserId = userId,
                    JokeId = jokeId,
                    Liked = like,
                    TimeLiked = DateTime.Now
                });
            }
            else
            {
                userLike.Liked = like;
                userLike.TimeLiked = DateTime.Now;
            }

            context.SaveChanges();
        }

        public Joke GetWithLikes(int jokeId)
        {
            using var context = new JokeManagerDataContext(_connectionString);
            return context.Jokes.Include(u => u.UserLikedJokes)
                .FirstOrDefault(j => j.Id == jokeId);
        }

        public List<Joke> GetAll()
        {
            using var context = new JokeManagerDataContext(_connectionString);
            return context.Jokes.Include(j => j.UserLikedJokes).ToList();
        }
    }
}
