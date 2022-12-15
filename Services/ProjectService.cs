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

        public Projects Create(ProjectDto data)
        {
            Projects project = new()
            {
                Name = data.Name,
                Description = data.Description,
            };

            ProjectsPerClients projectsPerClients = new()
            {
                ClientId = data.ClientId,
                ProjectId = project.Id
            };

            _context.Projects.Add(project);
            _context.ProjectsPerClients.Add(projectsPerClients);
            _context.SaveChanges();
            return project;
        }

        public PaginationDto<Projects> GetProjectsPerCompany(QueryParams qParams, string clientId)
        {
            IEnumerable<Projects> projects = _context.Projects
                .Include(x => x.Clients)
                .OrderBy(x => x.Name)
                .ToList();

            if (!string.IsNullOrEmpty(qParams.search))
                projects = projects.Where(x => x.Name.ToLower().Contains(qParams.search)
                    || x.Description.ToLower().Contains(qParams.search)
                    //|| x.Clients.Any(x => x.ClientId.Equals(clientId))
                );

            if (qParams.orderBy == "desc")
                projects = projects.OrderByDescending(x => x.Name);

            PaginationDto<Projects> paged = projects.GetPaged(qParams);
            return paged;
        }
    }
}
