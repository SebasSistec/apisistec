namespace apisistec.Entities
{
    public class ProjectsPerClients
    {
        public string ClientId { get; set; }
        public Guid ProjectId { get; set; }
        public Cliente Client { get; set; }
        public Projects Project { get; set; }
    }
}
