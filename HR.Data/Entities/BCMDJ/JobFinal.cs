using HR.Data.Commons;
using MG_HR.DATA.Entity.BCMDJ;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Data.Entities.BCMDJ
{
    [Table("jobFinal")]

    public class JobFinal : GeneralLocalizableEntity
    {
        public int Id { get; set; }
        [Required]
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        #region Navgation Property 



        #region One To Many
        public int JobPartId { get; set; }
        public JobPart? JobPart { get; set; }
        #endregion

        #endregion

        //  public JobPart? JobPart { get; set; }

    }
}
