using Entity.API.Models.KarbanModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.API.Configuration.KarbonConf
{
    public class ListTicketConf : IBaseConfiguration<ListTicket>
    {
        public void Configure(EntityTypeBuilder<ListTicket> builder)
        {
            builder.HasOne(x => x.ListCard).WithMany(x => x.ListTickets).HasForeignKey(x => x.ListCardId);
        }
    }
}
