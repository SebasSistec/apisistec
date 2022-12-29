using apisistec.Context;
using apisistec.Dtos;
using apisistec.Dtos.Employee;
using apisistec.Entities;
using apisistec.Extensions;
using apisistec.Interfaces;
using apisistec.Models.Parameters;
using AutoMapper;

namespace apisistec.Services
{
    public class EmployeeService : IEmployeeService
    {
        private DataContext _context;
        private IMapper _mapper;

        public EmployeeService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PaginationDto<EmployeeDto> Find(string companyId, QueryParams qParams)
        {
            IEnumerable<Empleado> employees = _context.Empleados
                .OrderBy(x => x.NombreEmpleado)
                .Where(x => x.EmpresasEmpleado.Equals(companyId))
                .ToList();

            if (!string.IsNullOrEmpty(qParams.search))
                employees = employees.Where(x => x.NombreEmpleado.ToLower().Contains(qParams.search)
                    || x.ApellidoEmpleado.ToLower().Contains(qParams.search)
                    || x.CedulaEmpleado.ToLower().Contains(qParams.search)
                    || x.EmailEmpleado.ToLower().Contains(qParams.search)
                );

            if (qParams.isOrderByDescending == true)
                employees = employees.OrderByDescending(x => x.NombreEmpleado);

            IEnumerable<EmployeeDto> mapped = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            PaginationDto<EmployeeDto> paged = mapped.GetPaged(qParams);
            return paged;
        }
    }
}
