using apisistec.Context;
using apisistec.Dtos;
using apisistec.Dtos.Project;
using apisistec.Entities;
using apisistec.Extensions;
using apisistec.Interfaces;
using apisistec.Models.Parameters;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace apisistec.Services
{
    public class ProjectService : IProjectService
    {
        private DataContext _context;
        private IMapper _mapper;

        public ProjectService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Projects Create(ProjectRequestDto data)
        {
            Projects project = new()
            {
                name = data.Name,
                description = data.Description,
            };

            _context.Projects.Add(project);
            _context.SaveChanges();
            return project;
        }

        public PaginationDto<Projects> GetProjectsPerCompany(QueryParams qParams, string? clientId)
        {
            IEnumerable<Projects> projects = _context.Projects
                .Include(x => x.clients)
                .OrderBy(x => x.name)
                .ToList();

            if (!string.IsNullOrEmpty(qParams.search))
                projects = projects.Where(x => x.name.ToLower().Contains(qParams.search)
                    || x.description.ToLower().Contains(qParams.search)
                );

            if (qParams.isOrderByDescending == true)
                projects = projects.OrderByDescending(x => x.name);

            PaginationDto<Projects> paged = projects.GetPaged(qParams);
            return paged;
        }

        public Modules CreateModule(ProjectOrModuleDto data)
        {
            Modules module = new()
            {
                name = data.Name,
                description = data.Description ?? string.Empty,
            };

            _context.Modules.Add(module);
            _context.SaveChanges();
            return module;
        }

        public PaginationDto<Modules> GetModules(QueryParams qParams)
        {
            IEnumerable<Modules> projects = _context.Modules
                .OrderBy(x => x.name)
                .ToList();

            if (!string.IsNullOrEmpty(qParams.search))
                projects = projects.Where(x => x.name.ToLower().Contains(qParams.search)
                    || x.description.ToLower().Contains(qParams.search)
                );

            if (qParams.isOrderByDescending == true)
                projects = projects.OrderByDescending(x => x.name);

            PaginationDto<Modules> paged = projects.GetPaged(qParams);
            return paged;
        }
    }
}
