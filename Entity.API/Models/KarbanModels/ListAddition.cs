using Core.API.Entity;

namespace Entity.API.Models.KarbanModels
{
    public class ListAddition : EntityBase
    {
        public string? Name { get; set; }
        public string Path { get; set; }
        public Guid ListCardId { get; set; }
        public virtual ListCard ListCard { get; set; }
    }
}
