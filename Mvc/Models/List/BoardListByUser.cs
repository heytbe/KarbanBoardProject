namespace Mvc.Models.List
{
    public class BoardListByUser
    {
        public Guid? BoardId { get; set; }
        public BoardNameList Board { get; set; }
        public string UserEmail { get; set; }
    }
}
