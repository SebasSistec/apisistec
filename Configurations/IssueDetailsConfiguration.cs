using apisistec.Entities;
using apisistec.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class IssueDetailsConfiguration : IEntityTypeConfiguration<IssueDetails>
    {
        public void Configure(EntityTypeBuilder<IssueDetails> builder)
        {
            builder.ToTable("spt_issues_details");
            builder.HasKey(x => x.id);

            builder.Property(x => x.id)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(36);

            builder.Property(x => x.title)
               .IsRequired()
               .HasColumnType("varchar");

            builder.Property(x => x.description)
               .IsRequired()
               .HasColumnType("text");

            builder.Property(x => x.estimatedHours)
               .IsRequired()
               .HasColumnName("estimated_hours")
               .HasColumnType("int");

            builder.Property(x => x.productId)
               .IsRequired()
               .HasColumnName("product_id")
               .HasColumnType("varchar")
               .HasMaxLength(36);

            builder.Property(x => x.solution)
               .HasColumnType("text");

            builder.Property(x => x.createdAt)
               .IsRequired()
               .HasColumnType("datetime");

            builder.Property(x => x.issueId)
               .HasColumnName("issue_id")
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(36);

            builder.Property(x => x.moduleId)
               .HasColumnName("module_id")
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(36);

            builder.HasOne(x => x.issue)
               .WithMany(x => x.issueDetails)
               .HasForeignKey(x => x.issueId)
               .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(x => x.producto)
               .WithMany(x => x.issues)
               .HasForeignKey(x => x.productId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.module)
               .WithMany(x => x.issueDetails)
               .HasForeignKey(x => x.moduleId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
