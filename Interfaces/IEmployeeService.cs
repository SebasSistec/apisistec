using apisistec.Dtos;
using apisistec.Dtos.Employee;
using apisistec.Models.Parameters;

namespace apisistec.Interfaces
{
    public interface IEmployeeService
    {
        PaginationDto<EmployeeDto> Find(string companyId, QueryStringParams qParams);
    }
}
