using apisistec.Entities;
using apisistec.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class IssueTimingsConfiguration : IEntityTypeConfiguration<IssueTimings>
    {
        public void Configure(EntityTypeBuilder<IssueTimings> builder)
        {
            builder.ToTable("spt_issue_timing");
            builder.HasKey(x => x.id);

            builder.Property(x => x.id)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(36);

            builder.Property(x => x.state)
               .IsRequired()
               .HasEnumComment();

            builder.Property(x => x.startAt)
               .HasColumnType("datetime");
            
            builder.Property(x => x.endAt)
               .HasColumnType("datetime");
            
            builder.Property(x => x.pauseDescription)
               .HasColumnType("varchar")
               .HasMaxLength(100);


            builder.Property(x => x.createdAt)
               .HasColumnType("datetime");

            builder.Property(x => x.employeeId)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(36);

            builder.Property(x => x.issueDetailId)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(36);

            builder.HasOne(x => x.detail)
                .WithMany(x => x.timings)
                .HasForeignKey(x => x.issueDetailId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.employee)
               .WithMany(x => x.issueTimings)
               .HasForeignKey(x => x.employeeId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
