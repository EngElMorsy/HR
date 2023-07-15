using HR.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Data.Entities.BCMDJ
{
    [Table("Company")]
    public class Company : GeneralLocalizableEntity
    {
        public int Id { get; set; }
        [Required]
        public string NameAr { get; set; }
        public string NameEN { get; set; }



        //#region One Branch To Many Company 
        //public int BranchId { get; set; }
        //public Branch? Branch { get; set; }
        //// One company has many MagSide
        //public List<MagSide>? MagSide { get; set; }

        // #endregion
    }
}
