namespace Mvc.Models.List
{
    public class BoardListList
    {
        public Guid Id { get; init; }
        public string ListName { get; init; }

        public IEnumerable<CardList> ListCards { get; set; }
    }
}
