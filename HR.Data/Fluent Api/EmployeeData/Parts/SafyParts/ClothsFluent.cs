using HR.Data.Entities.EmployeeData.Parts.SafyParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Data.Fluent_Api.EmployeeData
{
    public class ClothsFluent : IEntityTypeConfiguration<Cloths>
    {
        public void Configure(EntityTypeBuilder<Cloths> builder)
        {
            builder.ToTable("Cloths").HasKey(x => x.Id);
            builder.Property(x => x.NameAr).HasMaxLength(30);
            builder.Property(x => x.NameEn).HasMaxLength(30);


        }
    }
}
