using Core.API.Entity;
using Entity.API.Models.Identity;

namespace Entity.API.Models.KarbanModels
{
    public class Board : EntityBase
    {
        public Board()
        {
            BoardUsers = new HashSet<BoardUsers>();
            BoardLists = new HashSet<BoardLists>();
        }

        public string BoardName { get; set; }
        public string? BoardColor { get; set; }
        public string UserEmail { get; set; }
        public virtual ICollection<BoardUsers>? BoardUsers { get; set; }
        public virtual ICollection<BoardLists> BoardLists { get; set; }
    }
}
