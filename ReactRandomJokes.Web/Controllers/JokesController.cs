using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactRandomJokes.Data;
using ReactRandomJokes.Web.ViewModels;
using System;
using System.Text.Json;

namespace ReactRandomJokes.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private string _connectionString;
        public JokesController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [HttpGet]
        [Route("getrandomjoke")]
        public Joke GetRandomJoke()
        {
            var joke = JokeApi.GetRandomJoke();
            var jokesRepo = new JokesRepository(_connectionString);

            if (!Exists(joke))
            {
                jokesRepo.AddJoke(joke);
                return joke;
            }

            return jokesRepo.GetByOriginId(joke.LitId);
        }

        private bool Exists(Joke j)
        {
            var jokesRepo = new JokesRepository(_connectionString);
            return jokesRepo.Exists(j.LitId);
        }

        //[HttpGet]
        //[Route("getlikescount/{jokeid}")]
        //public object GetLikesCount(int jokeId)
        //{
        //    var repo = new JokesRepository(_connectionString);
        //    var joke = repo.GetWithLikes(jokeId);
        //    return new
        //    {
        //        likes = joke.UserLikedJokes.Count(u => u.Liked),
        //        dislikes = joke.UserLikedJokes.Count(u => !u.Liked)
        //    };
        //}

        [HttpGet]
        [Route("getinteractionstatus/{jokeid}")]
        public object GetInteractionStatus(int jokeId)
        {
            UserJokeInteractionStatus status = GetStatus(jokeId);
            return new { status };
        }

        [HttpPost]
        [Authorize]
        [Route("interactwithjoke")]
        public void InteractWithJoke(InteractViewModel viewModel)
        {
            var userRepo = new UserRepository(_connectionString);
            var user = userRepo.GetByEmail(User.Identity.Name);
            var jokeRepo = new JokesRepository(_connectionString);
            jokeRepo.InteractWithJoke(user.Id, viewModel.JokeId, viewModel.Like);
        }

        [HttpGet]
        [Route("viewall")]
        public List<Joke> ViewAll()
        {
            var jokeRepo = new JokesRepository(_connectionString);
            return jokeRepo.GetAll();
        }

        private UserJokeInteractionStatus GetStatus(int jokeId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return UserJokeInteractionStatus.Unauthenticated;
            }
            var userRepo = new UserRepository(_connectionString);
            var user = userRepo.GetByEmail(User.Identity.Name);
            var jokeRepo = new JokesRepository(_connectionString);
            UserLikedJokes likeStatus = jokeRepo.GetLike(user.Id, jokeId);
            if (likeStatus == null)
            {
                return UserJokeInteractionStatus.NeverInteracted;
            }

            if (likeStatus.TimeLiked.AddMinutes(5) < DateTime.Now)
            {
                return UserJokeInteractionStatus.CanNoLongerInteract;
            }
            return likeStatus.Liked
                ? UserJokeInteractionStatus.Liked
                : UserJokeInteractionStatus.Disliked;
        }
    }
}
