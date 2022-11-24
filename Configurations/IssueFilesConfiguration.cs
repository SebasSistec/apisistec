using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class IssueFilesConfiguration : IEntityTypeConfiguration<IssueFiles>
    {
        public void Configure(EntityTypeBuilder<IssueFiles> builder)
        {
            builder.ToTable("spt_issue_files");

            builder.HasKey(x => x.id);

            builder.Property(x => x.id)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(36);

            builder.Property(x => x.path)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(255);

            builder.Property(x => x.extension)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(6);

            builder.Property(x => x.name)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(100);

            builder.Property(x => x.createdAt)
               .IsRequired()
               .HasColumnName("created_at")
               .HasColumnType("datetime");

            builder.Property(x => x.issueDetailId)
               .IsRequired()
               .HasColumnName("issue_detail_id")
               .HasColumnType("varchar")
               .HasMaxLength(36);

            builder.HasOne(x => x.detail)
               .WithMany(x => x.files)
               .HasForeignKey(x => x.issueDetailId);
        }
    }
}
