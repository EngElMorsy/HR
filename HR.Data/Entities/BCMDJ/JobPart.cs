using HR.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MG_HR.DATA.Entity.BCMDJ
{
    [Table("JobPart")]
    public class JobPart : GeneralLocalizableEntity
    {
        public int Id { get; set; }
        [Required]
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public int DepartId { get; set; }
        public Depart? Depart { get; set; }

        // public List<JobFinal>? JobFinal { get; set; }
    }
}
