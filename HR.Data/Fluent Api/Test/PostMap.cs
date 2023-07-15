using HR.Data.Entities.Test;
using HR.Data.Fluent_Api.Interface;
using Microsoft.EntityFrameworkCore;

namespace HR.Data.Fluent_Api.Test
{
    public class PostMap : IEntityMap
    {
        public PostMap(ModelBuilder builder)
        {
            builder.Entity<Post>(b =>
            {
                b.HasKey(e => e.PostId);
                b.Property(e => e.Title).HasMaxLength(128).IsRequired();
                b.Property(e => e.Content).IsRequired();
            });
        }
    }
}
