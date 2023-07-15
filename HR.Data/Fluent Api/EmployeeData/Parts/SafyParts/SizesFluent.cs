using HR.Data.Entities.EmployeeData.Parts.SafyParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Data.Fluent_Api.EmployeeData
{
    public class SizesFluent : IEntityTypeConfiguration<Sizes>
    {
        public void Configure(EntityTypeBuilder<Sizes> builder)
        {
            builder.ToTable("Sizes").HasKey(x => x.Id);
            builder.Property(x => x.NameAr).HasMaxLength(30);
            builder.Property(x => x.NameEn).HasMaxLength(30);
        }
    }
}
