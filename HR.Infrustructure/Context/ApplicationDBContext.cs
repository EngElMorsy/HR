using HR.Data.Entities.BCMDJ;
using HR.Data.Entities.EmployeeData;
using HR.Data.Entities.EmployeeData.Parts.SafyParts;
using HR.Data.Fluent_Api.EmployeeData;
using MG_HR.DATA.Entity.Address;
using MG_HR.DATA.Entity.BCMDJ;
using Microsoft.EntityFrameworkCore;
//using HR.Data.Entities.Identity;
using System.Reflection;


namespace HR.Infrustructure.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        #region EmployeeData
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Qualifiction> Qualifiction { get; set; }
        public DbSet<Safty> Safty { get; set; }
        public DbSet<Job> Job { get; set; }
        #endregion

        #region BCMDJ
        public DbSet<Company> Company { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<MagSide> MagSide { get; set; }
        public DbSet<Depart> Depart { get; set; }
        public DbSet<JobPart> JobPart { get; set; }
        public DbSet<JobFinal> JobFinal { get; set; }
        #endregion

        #region Address
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
        #endregion



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            #region CREATE FOLDER CONTAIN FOR EVERY ENTITY CLASS fOR FLUENAPI AND REFERENCE FORM IT HEFRE
            #region EmployeeData
            new EmployeeFluent().Configure(modelBuilder.Entity<Employee>());
            new QualifictionFluent().Configure(modelBuilder.Entity<Qualifiction>());
            new SaftyFluent().Configure(modelBuilder.Entity<Safty>());
            new JobFluent().Configure(modelBuilder.Entity<Job>());
            #endregion

            #region Safty
            new ClothsFluent().Configure(modelBuilder.Entity<Cloths>());
            new SizesFluent().Configure(modelBuilder.Entity<Sizes>());

            #endregion

            #endregion
        }

    }
}
