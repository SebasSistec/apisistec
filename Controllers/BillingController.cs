using apisistec.Context;
using apisistec.Dtos;
using apisistec.Dtos.Billing;
using apisistec.Entities;
using apisistec.Enums;
using apisistec.Helpers;
using apisistec.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Text.Json;

namespace apisistec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private IBillingService _billingService;
        private IClientService _clientService;
        private IUserService _userService;
        private IContractedPlansService _contractService;
        private DataContext _context;
        private IAuthorizeBilling _authorizeBilling;
        private IMailingService _mailingService;
        private ILoggerManager _logs;

        DefaultResponses response = new();

        public BillingController(
                IBillingService billingService,
                IClientService clientService,
                IUserService userService,
                DataContext dataContext,
                IAuthorizeBilling authorizeBilling,
                IContractedPlansService contractService,
                IMailingService mailingService,
                ILoggerManager logs
            )
        {
            _billingService = billingService;
            _clientService = clientService;
            _context = dataContext;
            _mailingService = mailingService;
            _authorizeBilling = authorizeBilling;
            _contractService = contractService;
            _userService = userService;
            _logs = logs;
        }

        [HttpPost]
        public IActionResult Billing([FromBody] BillingDto billingData)
        {
            _logs.LogInformation(JsonSerializer.Serialize(billingData));
            string? userId = _userService.GetUserLoggedId();

            Users? user = null;
            
            if (userId is not null)
                user = _userService.FindUserById(userId);
            
            if (userId is null && user is null)
            {
                user = _userService.Register(new UserRegisterDto
                {
                    Email = billingData.Customer.Email,
                    FirstName = billingData.Customer.FirstName,
                    LastName = billingData.Customer.LastName,
                    Password = billingData.Customer.Password!,
                    Phone = billingData.Customer.Phone,
                    State = StateEnum.ENABLED
                });
                userId = user.Id.ToString();
                user.PasswordTemp = _userService.RamdomPassword();
                _context.Users.Add(user);
            }

            Cliente? client = _clientService.FindByIdentification(billingData.Customer.Identification);
            if (client is null)
            {
                client = _clientService.Create(billingData.Customer);
                _context.Clients.Add(client);
            }

            PlanHeader planHeader = _context.PlanHeader.Where(x => x.Id.ToString() == billingData.PlanId.ToString()).FirstOrDefault()!;

            Facturascabecera? facturascabecera = new();
            if (billingData.Payment.PaymentState == PaymentState.PAID)
            {
                _billingService.Billing(billingData, client.CodigoCliente, out Facturascabecera billingSaved);
                facturascabecera = billingSaved;
            }

            ContractedPlans contract = _contractService.Save(planHeader, billingData.Payment, Guid.Parse(userId!), client.CodigoCliente, facturascabecera.CodigoFacturaCabecera);

            contract.ProvinceInec = billingData.Customer.ProvinceInec;
            contract.CantonInec = billingData.Customer.CantonInec;
            _context.ContractedPlans.Add(contract);
            _context.SaveChanges();
            _mailingService.sendMail(
                billingData.Customer.Email,
                new
                {
                    username = user.Email,
                    password = user.PasswordTemp,
                    title = contract.Plan.Title,
                    price = contract.Plan.Price,
                    TransacctionQty = contract.Plan.TransacctionQty,
                    RucQty = contract.Plan.RucQty
                },
                TypesMail.BUY_PLAN
            );
            if(!string.IsNullOrEmpty(facturascabecera.CodigoFacturaCabecera))
            {
                string token = _userService.GetToken(Guid.Parse(userId), billingData.Customer.Email);
                _authorizeBilling.AutorizeBill(facturascabecera.CodigoFacturaCabecera, token);
            }
            return Ok(response.SuccessResponse("Compra realizada con éxito", billingData.Customer));
        }
    }
}
