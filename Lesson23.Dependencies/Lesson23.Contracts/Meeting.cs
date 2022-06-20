namespace Lesson23.Contracts
{
    public class Meeting
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public User Creator { get; set; }

        public List<User> Partisipants { get; set; }

        public Room Room { get; set; }
    }
}