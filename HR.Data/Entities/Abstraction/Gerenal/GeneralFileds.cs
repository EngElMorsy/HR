using HR.Data.Commons;

namespace HR.Data.Entities.EmployeeData.Abstraction.Gerenal
{
    public abstract class GeneralFileds : GeneralLocalizableEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }

    }
}
