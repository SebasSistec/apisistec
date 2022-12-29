using apisistec.Context;
using apisistec.Dtos;
using apisistec.Dtos.Billing;
using apisistec.Dtos.Client;
using apisistec.Entities;
using apisistec.Extensions;
using apisistec.Interfaces;
using apisistec.Models.Parameters;
using AutoMapper;

namespace apisistec.Services
{
    public class ClientService : IClientService
    {
        private DataContext _context;
        private IMapper _mapper;

        public ClientService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Cliente Create(CustomerDto customer) => _mapper.Map<Cliente>(customer);

        public Cliente? FindByIdentification(string identification) =>
            _context
            .Clients
            .FirstOrDefault(x => x.NumeroIdentificacionCliente == identification);

        public PaginationDto<ClientDto> Find(QueryParams qParams)
        {
            IEnumerable<Cliente> clients = _context.Clients
                .OrderBy(x => x.NombreComercialCliente)
                .ToList();

            if (!string.IsNullOrEmpty(qParams.search))
                clients = clients.Where(x => x.NumeroIdentificacionCliente.ToLower().Contains(qParams.search)
                    || x.NumeroIdentificacionCliente.ToLower().Contains(qParams.search)
                    || x.NombreCliente.ToLower().Contains(qParams.search)
                    || x.ApellidoCliente.ToLower().Contains(qParams.search)
                    || x.NombreComercialCliente.ToLower().Contains(qParams.search)
                );

            if (qParams.isOrderByDescending == true)
                clients = clients.OrderByDescending(x => x.NombreComercialCliente);
            
            IEnumerable<ClientDto> mapped = _mapper.Map<IEnumerable<ClientDto>>(clients);
            PaginationDto<ClientDto> paged = mapped.GetPaged(qParams);
            return paged;
        }
    }
}
