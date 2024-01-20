using Entity.API.Models.KarbanModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.API.Configuration.KarbonConf
{
    public class BoardUserConf : IBaseConfiguration<BoardUsers>
    {
        public void Configure(EntityTypeBuilder<BoardUsers> builder)
        {
           builder.HasOne(x => x.Board).WithMany(x => x.BoardUsers).HasForeignKey(x => x.BoardId);
        }
    }
}
