using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class TemplateMailsConfiguration : IEntityTypeConfiguration<TemplateMails>
    {
        public void Configure(EntityTypeBuilder<TemplateMails> builder)
        {
            builder.ToTable("plnp_template_mails");
            builder.HasKey(x => x.id);
            builder.Property(x => x.name)
                .HasColumnName("id")
                .IsRequired()
                .HasColumnType("varchar(36)");
            builder.Property(x => x.name)
                .HasColumnName("name")
                .IsRequired()
                .HasColumnType("varchar(36)");
            builder.Property(x => x.template)
                .HasColumnName("template")
                .IsRequired()
                .HasColumnType("text");

        }
    }
}
