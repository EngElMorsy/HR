using HR.Data.Entities.EmployeeData.ConstantFileds;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Data.Entities.EmployeeData
{
    [Table("Qualifiction")]
    public class Qualifiction : ConstProperty
    {

        #region QUALIGFICATION 
        public int Id { get; set; }

        public string? QfySide { get; set; }
        public string? Qfy { get; set; }
        public string? spfy { get; set; }
        public DateTime? QfyYear { get; set; }
        public string? deg { get; set; }
        #endregion

        #region navgation Property 

        #region One To One 
        public int EmployeeCode { get; set; }
        public Employee? Employee { get; set; }
        #endregion

        #endregion

    }
}
