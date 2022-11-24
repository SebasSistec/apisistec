namespace apisistec.Interfaces
{
    public interface IAuthorizeBilling
    {
        Task<string> AutorizeBill(string idBill, string token);
    }
}
