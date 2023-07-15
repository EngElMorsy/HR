using HR.Data.Commons;

namespace HR.Data.Entities.EmployeeData.ConstantFileds
{
    public abstract class ConstProperty : GeneralLocalizableEntity
    {

        public DateTime? DTCreation { get; set; }
        public bool IsUpdate { get; set; }
        public DateTime? DTUpdate { get; set; }
    }
}
