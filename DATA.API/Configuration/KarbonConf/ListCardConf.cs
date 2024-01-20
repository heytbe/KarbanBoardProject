using Entity.API.Models.KarbanModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.API.Configuration.KarbonConf
{
    public class ListCardConf : IBaseConfiguration<ListCard>
    {
        public void Configure(EntityTypeBuilder<ListCard> builder)
        {
            builder.HasOne(x => x.BoardLists).WithMany(x => x.ListCards).HasForeignKey(x => x.BoardListsId);
        }
    }
}
