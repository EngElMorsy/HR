using HR.Data.Entities.EmployeeData.Abstraction.Gerenal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MG_HR.DATA.Entity.Address
{
    [Table("District")]
    public class District : GeneralFileds
    {

        public int CityId { get; set; }
        public City? City { get; set; }
    }
}
