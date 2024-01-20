using Core.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.API.Configuration
{
    public interface IBaseConfiguration<T> :IEntityTypeConfiguration<T> where T : class,IEntityBase,new()
    {
    }
}
