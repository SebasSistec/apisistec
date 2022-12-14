using apisistec.Dtos;
using apisistec.Dtos.Project;
using apisistec.Entities;
using apisistec.Models.Parameters;

namespace apisistec.Interfaces
{
    public interface IProjectService
    {
        PaginationDto<Projects> GetProjectsPerCompany(QueryParams qParams, string? clientId);
        Projects Create(ProjectRequestDto project);
        Modules CreateModule(ProjectOrModuleDto module);
        PaginationDto<Modules> GetModules(QueryParams qParams);
    }
}
