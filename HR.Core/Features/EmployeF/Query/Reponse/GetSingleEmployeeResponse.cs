namespace HR.Core.Features.EmployeF.Query.Reponse
{
    public class GetSingleEmployeeResponse
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string? DisName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DTBrith { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
        public string NationID { get; set; }
        public DateTime? DTexp { get; set; }
        public string? Gender { get; set; }
        public string? Religion { get; set; }
        public string? Social { get; set; }
        public string? Position { get; set; }
        public string? DepartName { get; set; }
    }
}
