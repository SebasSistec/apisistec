using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class ProjectsPerClientsConfiguration : IEntityTypeConfiguration<ProjectsPerClients>
    {
        public void Configure(EntityTypeBuilder<ProjectsPerClients> builder)
        {
            builder.ToTable("spt_projects_per_clients");

            builder.HasKey(x => new { x.ClientId, x.ProjectId });

            builder.Property(x => x.ClientId)
                .HasColumnName("client_id")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(36);

            builder.HasOne(x => x.Client)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.ProjectId)
                .HasColumnName("project_id")
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(36);

            builder.HasOne(x => x.Project)
                .WithMany(x => x.Clients)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
