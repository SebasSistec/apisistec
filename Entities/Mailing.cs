namespace apisistec.Entities
{
    public class Mailing
    {
        public string Id { get; set; }
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public int Ssl { get; set; }
    }
}
