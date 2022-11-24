using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apisistec.Migrations
{
    public partial class add_users_plans_mailing_password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "plnp_mailing",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    host = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    username = table.Column<string>(type: "varchar(80)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    port = table.Column<int>(type: "int(3)", nullable: false),
                    ssl = table.Column<int>(type: "int(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plnp_mailing", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "plnp_plan_details",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plnp_plan_details", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "plnp_plans",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "'1990-01-01 00:00:00'"),
                    start_at = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "'1990-01-01 00:00:00'"),
                    end_at = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "'1990-01-01 00:00:00'"),
                    state = table.Column<int>(type: "int(1)", nullable: false, comment: "0: DISABLED, 1: ENABLED"),
                    price = table.Column<decimal>(type: "DECIMAL(16,4)", nullable: false),
                    past_price = table.Column<decimal>(type: "DECIMAL(16,4)", nullable: false),
                    discount_percent = table.Column<decimal>(type: "DECIMAL(16,4)", nullable: false),
                    past_discount_percent = table.Column<decimal>(type: "DECIMAL(16,4)", nullable: false),
                    transacction_qty = table.Column<int>(type: "int(4)", nullable: false),
                    ruc_qty = table.Column<int>(type: "int(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plnp_plans", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "plnp_restore_passwords",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plnp_restore_passwords", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "plnp_template_mails",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    template = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plnp_template_mails", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "plnp_users",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "VARCHAR(25)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    first_name = table.Column<string>(type: "VARCHAR(25)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "VARCHAR(25)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password_hash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    password_salt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    phone = table.Column<string>(type: "VARCHAR(15)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "'1990-01-01 00:00:00'"),
                    state = table.Column<int>(type: "int(1)", nullable: false, comment: "0: DISABLED, 1: ENABLED"),
                    email_verified = table.Column<int>(type: "int(1)", nullable: false, comment: "0: DISABLED, 1: ENABLED")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plnp_users", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "plnp_plan_per_details",
                columns: table => new
                {
                    FK_plan_header = table.Column<string>(type: "VARCHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FK_plan_detail = table.Column<string>(type: "VARCHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    order = table.Column<int>(type: "int(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("foreign_keys", x => new { x.FK_plan_header, x.FK_plan_detail });
                    table.ForeignKey(
                        name: "FK_plnp_plan_per_details_plnp_plan_details_FK_plan_detail",
                        column: x => x.FK_plan_detail,
                        principalTable: "plnp_plan_details",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_plnp_plan_per_details_plnp_plans_FK_plan_header",
                        column: x => x.FK_plan_header,
                        principalTable: "plnp_plans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_plnp_plan_per_details_FK_plan_detail",
                table: "plnp_plan_per_details",
                column: "FK_plan_detail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plnp_mailing");

            migrationBuilder.DropTable(
                name: "plnp_plan_per_details");

            migrationBuilder.DropTable(
                name: "plnp_restore_passwords");

            migrationBuilder.DropTable(
                name: "plnp_template_mails");

            migrationBuilder.DropTable(
                name: "plnp_users");

            migrationBuilder.DropTable(
                name: "plnp_plan_details");

            migrationBuilder.DropTable(
                name: "plnp_plans");
        }
    }
}
