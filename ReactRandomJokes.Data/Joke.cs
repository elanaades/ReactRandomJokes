namespace ReactRandomJokes.Data
{
    public class Joke
    {
        public int Id { get; set; }
        public int LitId { get; set; }
        public string SetUp { get; set; }
        public string PunchLine { get; set; }

        public List<UserLikedJokes> UserLikedJokes { get; set; }
    }
}