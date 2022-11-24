namespace apisistec.Interfaces
{
    public interface IMailingService
    {
        string? sendMail(string mailTo, object objectReplace, string typeMail);
    }
}
