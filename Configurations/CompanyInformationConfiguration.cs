using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class CompanyInformationConfiguration : IEntityTypeConfiguration<CompanyInformation>
    {
        public void Configure(EntityTypeBuilder<CompanyInformation> builder)
        {
            builder.ToTable("plnp_company_information");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired()
                .HasColumnType("varchar(36)");
            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasColumnType("varchar(36)");
            builder.Property(x => x.Address)
                .HasColumnName("address") // PENDING change direction x address in db
                .IsRequired()
                .HasColumnType("varchar(150)");
            builder.Property(x => x.Phone)
                .HasColumnName("phone")
                .IsRequired()
                .HasColumnType("varchar(150)");
            builder.Property(x => x.Politics)
                .HasColumnName("politics")
                .IsRequired()
                .HasColumnType("text");
            builder.Property(x => x.TermsAndConditions)
                .HasColumnName("terms_and_conditions")
                .HasDefaultValue("")
                .HasColumnType("text");
            builder.Property(x => x.Faq)
                .HasColumnName("faq")
                .HasDefaultValue("")
                .HasColumnType("text");
            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasDefaultValue("")
                .HasColumnType("varchar(100)");
            builder.Property(x => x.AboutUs)
                .HasColumnName("about_Us")
                .HasDefaultValue("")
                .HasColumnType("text");
            builder.Property(x => x.StoreAddress)
                .HasColumnName("store_address")
                .HasDefaultValue("")
                .HasColumnType("varchar(150)");
            builder.Property(x => x.WhatsappMessage)
                .HasColumnName("whatsapp_message")
                .HasDefaultValue("")
                .HasColumnType("varchar(250)");
            builder.Property(x => x.whatsappNumber)
                .HasColumnName("whatsapp_number")
                .HasDefaultValue("")
                .HasColumnType("varchar(10)");
            builder.Property(x => x.YoutubeUrl)
                .HasColumnName("youtube_url")
                .HasDefaultValue("")
                .HasColumnType("varchar(255)");
            builder.Property(x => x.FacebookUrl)
                .HasColumnName("facebook_url")
                .HasDefaultValue("")
                .HasColumnType("varchar(255)");
            builder.Property(x => x.Devolution)
                .HasColumnName("devolution")
                .HasDefaultValue("")
                .HasColumnType("longtext");
        }
    }
}

