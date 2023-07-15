using HR.Data.Entities.EmployeeData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Data.Fluent_Api.EmployeeData
{
    public class EmployeeFluent : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            #region Employee Has One 
            #region Qualification
            builder.HasOne(b => b.Qualifiction)
            .WithOne(i => i.Employee)
           .HasForeignKey<Qualifiction>(b => b.EmployeeCode)
           .HasPrincipalKey<Employee>(c => c.Code);
            #endregion
            #region Safty
            builder.HasOne(b => b.Safty)
          .WithOne(i => i.Employee)
          .HasForeignKey<Safty>(b => b.EmployeeCode)
          .HasPrincipalKey<Employee>(c => c.Code);
            #endregion
            #region Job
            builder.HasOne(b => b.Job)
           .WithOne(i => i.Employee)
           .HasForeignKey<Job>(b => b.EmployeeCode)
           .HasPrincipalKey<Employee>(c => c.Code);
            #endregion

            #endregion


            //builder.HasOne(b => b.Depart).
            //    WithMany(b => b.Employee);




            builder.ToTable("Employees").HasKey(x => x.Id);
            // builder.Property(x => x.Code).ValueGeneratedNever();
            // builder.Property(x => x.Id).ValueGeneratedOnAdd();
            //builder.HasIndex(b => b.Id).IsClustered();
            // builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.IsUpdate).HasDefaultValue(false);
            builder.Property(x => x.DTCreation).HasDefaultValueSql("GETDATE()");
            //  builder.Property(x => x.DisName).HasMaxLength(50);
            //builder.Property(x => x.Address).HasMaxLength(50);
            builder.Property(x => x.NationID).IsRequired().HasMaxLength(14);
            builder.Property(x => x.Gender).HasMaxLength(10);
            builder.Property(x => x.Religion).HasMaxLength(10);
            builder.Property(x => x.Social).HasMaxLength(10);
            builder.Property(x => x.Position).HasMaxLength(20);

            #region  
            //builder.Property(x => x.DisName).HasComputedColumnSql("[FName]+','+[MName]+','+[LName]");
            //builder.Property(x => x.FName).HasMaxLength(15).IsRequired();
            //builder.Property(x => x.MName).HasMaxLength(15).IsRequired();
            //builder.Property(x => x.LName).HasMaxLength(15).IsRequired();
            // builder.Property(x => x.DTUpdate).ValueGeneratedOnUpdate();
            //builder.HasIndex(m => new {m.Name}); 
            //builder.Property(x => x.FName).HasColumnName("Ename").
            //IsRequired().HasMaxLength(50);
            //builder.Property(x => x.LName).HasMaxLength(50);
            #endregion

        }
    }
}
