namespace Mvc.Models.Create
{
    public class BoardCreate
    {
        public string BoardName { get; set; }
        public string? BoardColor { get; set; }
        public string UserEmail { get; set; }
        public List<string> BoardListCreate { get; set; }
        public List<string>? BoardUsersCreate { get; set; }
    }
}
