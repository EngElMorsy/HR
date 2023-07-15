using HR.Data.Entities.EmployeeData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Data.Fluent_Api.EmployeeData
{
    public class JobFluent : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Job").HasKey(x => x.Id);

            builder.Property(x => x.Company).HasDefaultValue(true);
            builder.Property(x => x.Branch).HasDefaultValue(true);
            builder.Property(x => x.MagSide).HasDefaultValue(true);
            builder.Property(x => x.Depart).HasDefaultValue(true);
            builder.Property(x => x.JobPart).HasDefaultValue(true);
            builder.Property(x => x.JobFinal).HasDefaultValue(true);
            builder.Property(x => x.IsUpdate).HasDefaultValue(false);
            builder.Property(x => x.DTCreation).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.DTUpdate).HasDefaultValueSql("GETDATE()");




        }



    }
}
