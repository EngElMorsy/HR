using HR.Data.Entities.EmployeeData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Data.Fluent_Api.EmployeeData
{
    public class QualifictionFluent : IEntityTypeConfiguration<Qualifiction>
    {
        public void Configure(EntityTypeBuilder<Qualifiction> builder)
        {
            builder.ToTable("Qualifiction").HasKey(x => x.Id);

            builder.Property(x => x.QfySide).HasMaxLength(50);
            builder.Property(x => x.Qfy).HasMaxLength(50);
            builder.Property(x => x.spfy).HasMaxLength(50);
            builder.Property(x => x.IsUpdate).HasDefaultValue(false);
            builder.Property(x => x.DTCreation).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.DTUpdate).HasDefaultValueSql("GETDATE()");

            //DTUpdate

        }
    }
}
