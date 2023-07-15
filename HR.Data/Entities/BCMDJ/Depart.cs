using HR.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MG_HR.DATA.Entity.BCMDJ
{
    [Table("Depart")]
    public class Depart : GeneralLocalizableEntity
    {
        public int Id { get; set; }
        [Required]
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public int MagSideId { get; set; }
        public MagSide? MagSide { get; set; }
        #region Navigation property
        #region One To Many
        //public List<Employee>? Employee { get; set; }
        // public List<JobPart>? JobPart { get; set; }


        #endregion
        #endregion


    }
}
