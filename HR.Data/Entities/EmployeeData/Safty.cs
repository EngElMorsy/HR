using HR.Data.Entities.EmployeeData.ConstantFileds;

namespace HR.Data.Entities.EmployeeData
{
    public class Safty : ConstProperty
    {
        #region Safty 
        public int Id { get; set; }
        public string? ClothsName { get; set; }
        public string? Sizes { get; set; }
        public bool Done { get; set; }
        #endregion

        #region navgation Property
        #region One To One 
        public int EmployeeCode { get; set; }
        public Employee? Employee { get; set; }
        #endregion

        #endregion
    }
}
