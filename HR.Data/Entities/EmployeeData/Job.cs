using HR.Data.Entities.EmployeeData.ConstantFileds;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Data.Entities.EmployeeData
{
    [Table("Job")]
    public class Job : ConstProperty
    {

        #region Job 
        public int Id { get; set; }
        [Required]
        public int Company { get; set; }
        [Required]
        public int Branch { get; set; }
        [Required]
        public int MagSide { get; set; }
        [Required]
        public int Depart { get; set; }
        [Required]
        public int JobPart { get; set; }
        public int JobFinal { get; set; }
        public DateTime? StarDt { get; set; }
        public DateTime? EndDt { get; set; }
        #endregion
        #region navgation Property
        #region One To One 
        public int EmployeeCode { get; set; }
        public Employee? Employee { get; set; }
        #endregion

        #endregion
    }
}
