using HR.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MG_HR.DATA.Entity.BCMDJ
{
    [Table("MagSide")]
    public class MagSide : GeneralLocalizableEntity
    {
        public int Id { get; set; }
        [Required]
        public string NameAr { get; set; }
        public string NameEn { get; set; }


        //#region Navigation property
        //#region One company to Many MagSide
        public int BranchId { get; set; }
        public Branch? Branch { get; set; }
        // #endregion
        ////one Magside has many Departs
        //public List<Depart>? Depart { get; set; }

        //#endregion

    }
}
