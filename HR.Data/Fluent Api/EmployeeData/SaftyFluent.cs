using HR.Data.Entities.EmployeeData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Data.Fluent_Api.EmployeeData
{
    public class SaftyFluent : IEntityTypeConfiguration<Safty>
    {
        public void Configure(EntityTypeBuilder<Safty> builder)
        {
            builder.ToTable("Safty").HasKey(x => x.Id);

            builder.Property(x => x.ClothsName).HasMaxLength(20);
            builder.Property(x => x.Sizes).HasMaxLength(20);
            builder.Property(x => x.Done).HasDefaultValue(true);
            builder.Property(x => x.IsUpdate).HasDefaultValue(false);
            builder.Property(x => x.DTCreation).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.DTUpdate).HasDefaultValueSql("GETDATE()");



        }
    }
}
