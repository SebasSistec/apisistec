using apisistec.Context;
using apisistec.Dtos.Company;
using apisistec.Entities;
using apisistec.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace apisistec.Controllers
{
    [Route("api/company-information")]
    [ApiController]
    public class CompanyInformationController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _autoMapper;
        DefaultResponses response = new();
        public CompanyInformationController(DataContext context,
                                            IMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        public IActionResult GetCompanyInformations()
        {
            CompanyInformation? companyInformation = _context.CompanyInformation.FirstOrDefault();
            if (companyInformation == null)
                return BadRequest(response.ErrorResponse($"No se encontro informacion de la empresa", "")); ;
            return Ok(response.SuccessResponse("OK", companyInformation));
        }

        [HttpGet("contact-info")]
        public IActionResult GetCompanyContact()
        {
            CompanyInformation? companyInformation = _context.CompanyInformation.FirstOrDefault();
            if (companyInformation == null)
                return BadRequest(response.ErrorResponse($"No se pudo encontrar datos de la Empresa", ""));

            return Ok(response.SuccessResponse("Ok", new
            {
                email = companyInformation.Email,
                phone = companyInformation.Phone,
                whatsappMessage = companyInformation.WhatsappMessage,
                whatsappNumber = companyInformation.whatsappNumber
            }));
        }

        [HttpGet("privacy-polices")]
        public IActionResult getPrivacyPolicesInfo()
        {
            CompanyInformation? companyInformation = _context.CompanyInformation.FirstOrDefault();
            if (companyInformation == null)
                return BadRequest(response.ErrorResponse($"No se pudo encontrar datos de la Empresa", ""));
            return Ok(response.SuccessResponse("Ok", new { info = companyInformation.Politics }));
        }

        [HttpGet("about-us")]
        public IActionResult getAboutUs()
        {
            CompanyInformation? companyInformation = _context.CompanyInformation.FirstOrDefault();
            if (companyInformation == null)
                return BadRequest(response.ErrorResponse($"No se pudo encontrar datos de la Empresa", ""));
            return Ok(response.SuccessResponse("Ok", new { info = companyInformation.AboutUs }));
        }

        [HttpGet("faq")]
        public IActionResult getFaqs()
        {
            CompanyInformation? companyInformation = _context.CompanyInformation.FirstOrDefault();
            if (companyInformation == null)
                return BadRequest(response.ErrorResponse($"No se pudo encontrar datos de la Empres", ""));
            return Ok(response.SuccessResponse("Ok", new { info = companyInformation.Faq }));
        }

        [HttpGet("devolutions")]
        public IActionResult getDevolution()
        {
            CompanyInformation? companyInformation = _context.CompanyInformation.FirstOrDefault();
            if (companyInformation == null)
                return BadRequest(response.ErrorResponse($"No se pudo encontrar datos de la Empresa", ""));
            return Ok(response.SuccessResponse("Ok", new { info = companyInformation.Devolution }));
        }

        [HttpGet("terms-conditions")]
        public IActionResult getTermsConditionsInfo()
        {
            CompanyInformation? companyInformation = _context.CompanyInformation.FirstOrDefault();
            if (companyInformation == null)
                return BadRequest(response.ErrorResponse($"No se pudo encontrar datos de la Empresa", ""));
            return Ok(response.SuccessResponse("Ok", new { info = companyInformation.TermsAndConditions }));
        }

        [HttpPost("contact")]
        public IActionResult SendEmailContact([FromBody] ContactDto contact)
        {
            //Aqui va el correo de contact
            return Ok(response.SuccessResponse("Ok", contact));
        }
        
        [HttpGet("valid-payment")]
        public IActionResult IsValidPayment()
        {
            bool isValidPayment = _context.BillingParams.Select(x => x.IsValidPayment).FirstOrDefault() == 1;
            return Ok(response.SuccessResponse("Ok", new
            {
                isValidPayment
            }));
        }

    }
}
