using Entity.API.Models.KarbanModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.API.Configuration.KarbonConf
{
    public class BoardListConf : IBaseConfiguration<BoardLists>
    {
        public void Configure(EntityTypeBuilder<BoardLists> builder)
        {
            builder.HasOne(x => x.Board).WithMany(x => x.BoardLists).HasForeignKey(x => x.BoardId);
        }
    }
}
