using apisistec.Interfaces;
using apisistec.Models.Common;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace apisistec.Services
{
    public class AuthorizeBillingService : IAuthorizeBilling
    {
        HttpClient client = new HttpClient();
        private readonly AppSettings _appSettings;
        public AuthorizeBillingService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<string> AutorizeBill(string idBill, string token)
        {
            InstanciarDatos(token);
            HttpResponseMessage response = await client.GetAsync($"/api/Facturacion/{idBill}");
            if (response.IsSuccessStatusCode)
                return ($"OK: Se Actualizo Correctamente la factura con id: {idBill}");
            return ($"ERROR: {response.RequestMessage}");
        }


        public void InstanciarDatos(string token)
        {
            client.BaseAddress = new Uri(_appSettings.HostWise);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

    }
}
