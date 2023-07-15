using HR.Data.Entities.Test;
using HR.Data.Fluent_Api.Interface;
using Microsoft.EntityFrameworkCore;

namespace HR.Data.Fluent_Api.Test
{
    public class BlogMap : IEntityMap
    {
        public BlogMap(ModelBuilder builder)
        {
            builder.Entity<Blog>(b =>
            {
                b.HasKey(e => e.BlogId);
                b.Property(e => e.Url).HasMaxLength(500).IsRequired();
            });
        }
    }
}
