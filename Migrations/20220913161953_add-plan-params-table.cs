using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apisistec.Migrations
{
    public partial class addplanparamstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plnp_planheadersxdetails_plnp_plandetail_FK_plan_detail",
                table: "plnp_planheadersxdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_plnp_planheadersxdetails_plnp_planheader_FK_plan_header",
                table: "plnp_planheadersxdetails");

            migrationBuilder.DropTable(
                name: "plnp_senderMailsConfig");

            migrationBuilder.DropPrimaryKey(
                name: "PK_plnp_TemplateMails",
                table: "plnp_TemplateMails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_plnp_planheader",
                table: "plnp_planheader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_plnp_plandetail",
                table: "plnp_plandetail");

            migrationBuilder.RenameTable(
                name: "plnp_TemplateMails",
                newName: "plnp_template_mails");

            migrationBuilder.RenameTable(
                name: "plnp_planheadersxdetails",
                newName: "plnp_plan_per_details");

            migrationBuilder.RenameTable(
                name: "plnp_planheader",
                newName: "plnp_plans");

            migrationBuilder.RenameTable(
                name: "plnp_plandetail",
                newName: "plnp_plan_details");

            migrationBuilder.RenameIndex(
                name: "IX_plnp_planheadersxdetails_FK_plan_detail",
                table: "plnp_plan_per_details",
                newName: "IX_plnp_plan_per_details_FK_plan_detail");

            migrationBuilder.AddColumn<string>(
                name: "FK_product",
                table: "plnp_plans",
                type: "VARCHAR(20)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_plnp_template_mails",
                table: "plnp_template_mails",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_plnp_plans",
                table: "plnp_plans",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_plnp_plan_details",
                table: "plnp_plan_details",
                column: "id");

            migrationBuilder.CreateTable(
                name: "plnp_billing_params",
                columns: table => new
                {
                    id = table.Column<string>(type: "VARCHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FK_punto_factura_id = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FK_empleado_id = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FK_bodega_id = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FK_producto_id = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plnp_billing_params", x => x.id);
                    table.ForeignKey(
                        name: "FK_plnp_billing_params_bodegas_FK_bodega_id",
                        column: x => x.FK_bodega_id,
                        principalTable: "bodegas",
                        principalColumn: "CodigoBodega",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_plnp_billing_params_empleados_FK_empleado_id",
                        column: x => x.FK_empleado_id,
                        principalTable: "empleados",
                        principalColumn: "CodigoEmpleado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_plnp_billing_params_productos_FK_producto_id",
                        column: x => x.FK_producto_id,
                        principalTable: "productos",
                        principalColumn: "CodigoProducto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_plnp_billing_params_puntosfacturas_FK_punto_factura_id",
                        column: x => x.FK_punto_factura_id,
                        principalTable: "puntosfacturas",
                        principalColumn: "CodigoPuntoFactura",
                        onDelete: ReferentialAction.Restrict);
                })
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

            migrationBuilder.CreateIndex(
                name: "IX_plnp_plans_FK_product",
                table: "plnp_plans",
                column: "FK_product");

            migrationBuilder.CreateIndex(
                name: "IX_plnp_billing_params_FK_bodega_id",
                table: "plnp_billing_params",
                column: "FK_bodega_id");

            migrationBuilder.CreateIndex(
                name: "IX_plnp_billing_params_FK_empleado_id",
                table: "plnp_billing_params",
                column: "FK_empleado_id");

            migrationBuilder.CreateIndex(
                name: "IX_plnp_billing_params_FK_producto_id",
                table: "plnp_billing_params",
                column: "FK_producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_plnp_billing_params_FK_punto_factura_id",
                table: "plnp_billing_params",
                column: "FK_punto_factura_id");

            migrationBuilder.AddForeignKey(
                name: "FK_plnp_plan_per_details_plnp_plan_details_FK_plan_detail",
                table: "plnp_plan_per_details",
                column: "FK_plan_detail",
                principalTable: "plnp_plan_details",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_plnp_plan_per_details_plnp_plans_FK_plan_header",
                table: "plnp_plan_per_details",
                column: "FK_plan_header",
                principalTable: "plnp_plans",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_plnp_plans_productos_FK_product",
                table: "plnp_plans",
                column: "FK_product",
                principalTable: "productos",
                principalColumn: "CodigoProducto",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plnp_plan_per_details_plnp_plan_details_FK_plan_detail",
                table: "plnp_plan_per_details");

            migrationBuilder.DropForeignKey(
                name: "FK_plnp_plan_per_details_plnp_plans_FK_plan_header",
                table: "plnp_plan_per_details");

            migrationBuilder.DropForeignKey(
                name: "FK_plnp_plans_productos_FK_product",
                table: "plnp_plans");

            migrationBuilder.DropTable(
                name: "plnp_billing_params");

            migrationBuilder.DropTable(
                name: "plnp_mailing");

            migrationBuilder.DropTable(
                name: "plnp_restore_passwords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_plnp_template_mails",
                table: "plnp_template_mails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_plnp_plans",
                table: "plnp_plans");

            migrationBuilder.DropIndex(
                name: "IX_plnp_plans_FK_product",
                table: "plnp_plans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_plnp_plan_details",
                table: "plnp_plan_details");

            migrationBuilder.DropColumn(
                name: "FK_product",
                table: "plnp_plans");

            migrationBuilder.RenameTable(
                name: "plnp_template_mails",
                newName: "plnp_TemplateMails");

            migrationBuilder.RenameTable(
                name: "plnp_plans",
                newName: "plnp_planheader");

            migrationBuilder.RenameTable(
                name: "plnp_plan_per_details",
                newName: "plnp_planheadersxdetails");

            migrationBuilder.RenameTable(
                name: "plnp_plan_details",
                newName: "plnp_plandetail");

            migrationBuilder.RenameIndex(
                name: "IX_plnp_plan_per_details_FK_plan_detail",
                table: "plnp_planheadersxdetails",
                newName: "IX_plnp_planheadersxdetails_FK_plan_detail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_plnp_TemplateMails",
                table: "plnp_TemplateMails",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_plnp_planheader",
                table: "plnp_planheader",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_plnp_plandetail",
                table: "plnp_plandetail",
                column: "id");

            migrationBuilder.CreateTable(
                name: "plnp_senderMailsConfig",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    host = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    port = table.Column<int>(type: "int(3)", nullable: false),
                    ssl = table.Column<int>(type: "int(1)", nullable: false),
                    username = table.Column<string>(type: "varchar(80)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plnp_senderMailsConfig", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_plnp_planheadersxdetails_plnp_plandetail_FK_plan_detail",
                table: "plnp_planheadersxdetails",
                column: "FK_plan_detail",
                principalTable: "plnp_plandetail",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_plnp_planheadersxdetails_plnp_planheader_FK_plan_header",
                table: "plnp_planheadersxdetails",
                column: "FK_plan_header",
                principalTable: "plnp_planheader",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
