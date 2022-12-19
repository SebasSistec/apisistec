namespace apisistec.Entities
{
    public class Projects
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<ProjectsPerClients> Clients { get; set; } = new();
        public List<Issues> Issues { get; set; } = new();
    }
}
