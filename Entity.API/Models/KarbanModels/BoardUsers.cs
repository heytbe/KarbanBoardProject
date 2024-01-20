using Core.API.Entity;

namespace Entity.API.Models.KarbanModels
{
    public class BoardUsers : EntityBase
    {
        public Guid? BoardId { get; set; }
        public virtual Board Board { get; set; }
        public string UserEmail { get; set; }
    }
}
