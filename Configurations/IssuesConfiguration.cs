using apisistec.Extensions;
using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class IssuesConfiguration : IEntityTypeConfiguration<Issues>
    {
        public void Configure(EntityTypeBuilder<Issues> builder)
        {
            builder.ToTable("spt_issues");
            builder.HasKey(x => x.id);

            builder.Property(x => x.id)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(36);

            builder.Property(x => x.orderNumber)
                .IsRequired()
                .HasColumnType("int")
                .HasMaxLength(10);

            builder.Property(x => x.state)
                .IsRequired()
                .HasColumnType("int")
                .HasEnumComment();

            builder.Property(x => x.priority)
               .IsRequired()
               .HasColumnType("int")
               .HasEnumComment();

            builder.Property(x => x.createdAt)
                .IsRequired()
                .HasColumnType("datetime");
            
            builder.Property(x => x.asignedById)
                .IsRequired()
                .HasColumnType("varchar");
            
            builder.Property(x => x.asignedToId)
                .IsRequired()
                .HasColumnType("varchar");
            
            builder.Property(x => x.clientId)
                .IsRequired()
                .HasColumnType("varchar");

            builder.Property(x => x.projectId)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(36);

            builder.HasOne(x => x.asignedBy)
                .WithMany(x => x.asignedIssues)
                .HasForeignKey(x => x.asignedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.asignedTo)
                .WithMany(x => x.issuesToDo)
                .HasForeignKey(x => x.asignedToId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.client)
                .WithMany(x => x.issues)
                .HasForeignKey(x => x.clientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
