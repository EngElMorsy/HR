using HR.Core.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HR.Core.Features.EmployeF.Command.Model
{
    public class AddEmployeeCommand : IRequest<Response<string>>
    {

        public int Code { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }

        public bool IsActive { get; set; }
        public DateTime? DTBrith { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        [Required]
        public string NationID { get; set; }
        public DateTime? DTexp { get; set; }
        public string? Gender { get; set; }
        public string? Religion { get; set; }
        public string? Social { get; set; }
        public string? Position { get; set; }
        public int DepartId { get; set; }
        public int DistrictId { get; set; }
    }
}
