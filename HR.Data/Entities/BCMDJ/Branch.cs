using HR.Data.Commons;
using HR.Data.Entities.BCMDJ;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MG_HR.DATA.Entity.BCMDJ
{
    [Table("Branch")]
    public class Branch : GeneralLocalizableEntity
    {
        public int Id { get; set; }
        [Required]
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        #region Navigation property 


        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        //#region One To Many 
        ////One Branch has Many Company
        //public List<Company>? Company { get; set; }
        //#endregion
        #endregion
    }
}
