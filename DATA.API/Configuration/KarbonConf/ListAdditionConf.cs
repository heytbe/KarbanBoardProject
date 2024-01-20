using Entity.API.Models.KarbanModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.API.Configuration.KarbonConf
{
    public class ListAdditionConf : IBaseConfiguration<ListAddition>
    {
        public void Configure(EntityTypeBuilder<ListAddition> builder)
        {
            builder.HasOne(x => x.ListCard).WithMany(x => x.ListAdditions).HasForeignKey(x => x.ListCardId);
        }
    }
}
