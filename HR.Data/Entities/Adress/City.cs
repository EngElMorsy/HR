using HR.Data.Entities.EmployeeData.Abstraction.Gerenal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MG_HR.DATA.Entity.Address
{
    [Table("City")]
    public class City : GeneralFileds
    {

        public int CountryId { get; set; }
        public Country? Country { get; set; }

    }
}
