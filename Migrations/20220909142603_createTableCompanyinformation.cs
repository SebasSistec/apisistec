using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apisistec.Migrations
{
    public partial class createTableCompanyinformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "plnp_company_information",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direction = table.Column<string>(type: "varchar(150)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(150)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    politics = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    terms_and_conditions = table.Column<string>(type: "text", nullable: false, defaultValue: "")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    faq = table.Column<string>(type: "text", nullable: false, defaultValue: "")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", nullable: false, defaultValue: "")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    about_Us = table.Column<string>(type: "text", nullable: false, defaultValue: "")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    store_address = table.Column<string>(type: "varchar(150)", nullable: false, defaultValue: "")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    whatsapp_message = table.Column<string>(type: "varchar(250)", nullable: false, defaultValue: "")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    whatsapp_number = table.Column<string>(type: "varchar(10)", nullable: false, defaultValue: "")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    youtube_url = table.Column<string>(type: "varchar(255)", nullable: false, defaultValue: "")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    facebook_url = table.Column<string>(type: "varchar(255)", nullable: false, defaultValue: "")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    devolution = table.Column<string>(type: "longtext", nullable: false, defaultValue: "")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plnp_company_information", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plnp_company_information");
        }
    }
}
