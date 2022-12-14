namespace apisistec.Entities
{
    public class Projects
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string name { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        public List<ProjectsPerClients> clients { get; set; } = new();
        public List<Issues> issues { get; set; } = new();
    }
}
