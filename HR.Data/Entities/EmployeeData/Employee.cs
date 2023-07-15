using HR.Data.Entities.EmployeeData.ConstantFileds;
using MG_HR.DATA.Entity.Address;
using MG_HR.DATA.Entity.BCMDJ;

namespace HR.Data.Entities.EmployeeData
{
    // [Table("Employe")]
    //[Index(nameof(DisName),nameof(NationID), IsUnique = true)]

    public class Employee : ConstProperty
    {
        #region Property 
        public int Id { get; set; }
        public int Code { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DTDelete { get; set; }
        public DateTime? DTBrith { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public string NationID { get; set; }
        public DateTime? DTexp { get; set; }
        public string? Gender { get; set; }
        public string? Religion { get; set; }
        public string? Social { get; set; }
        public string? Position { get; set; }
        #endregion

        #region ForegnKeys

        // public Depart? DepartId { get; set; }
        //public int DistrictId { get; set; }

        #endregion

        #region navgation Property   

        #region One To One 
        public Qualifiction? Qualifiction { get; set; }
        public Safty? Safty { get; set; }
        public Job? Job { get; set; }

        #endregion

        #region One To Many  
        public int DepartId { get; set; }
        public Depart? Depart { get; set; }

        public int DistrictId { get; set; }
        public District? District { get; set; }

        // public int JobFinalId { get; set; }

        // public JobFinal? JobFinal { get; set; }
        #endregion

        #region Many To Many
        #endregion


        #endregion









        //public int DepartmentId { get; set; }



        // public Department? Department { get; set; }
        //public District? District { get; set; }
        //public Qualifiction? Qualifiction { get; set; }
    }
}
