using apisistec.Configurations;
using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Models;

namespace apisistec.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<PlanHeader> PlanHeader { get; set; }
        public DbSet<PlanDetail> PlanDetal { get; set; }
        public DbSet<PlanHeaderXDetail> PlanHeaderXDetail { get; set; }
        public DbSet<TemplateMails> TemplateMails { get; set; }
        public DbSet<Mailing> Mailing { get; set; }
        public DbSet<RestorePassword> RestorePassword { get; set; }
        public DbSet<CompanyInformation> CompanyInformation { get; set; }
        public DbSet<Facturascabecera> FacturasCabeceras { get; set; } = null!;
        public DbSet<Bodega> Bodegas { get; set; } = null!;
        public DbSet<Producto> Productos { get; set; } = null!;
        public DbSet<Empleado> Empleados { get; set; } = null!;
        public DbSet<Puntosfactura> PuntosFactura { get; set; } = null!;
        public DbSet<BillingParams> BillingParams { get; set; } = null!;
        public DbSet<Facturasdetalle> FacturaDetalles { get; set; } = null!;
        public DbSet<Cliente> Clients { get; set; } = null!;
        public DbSet<ContractedPlans> ContractedPlans { get; set; } = null!;
        public DbSet<Provincias> Provinces { get; set; } = null!;
        public DbSet<Cantones> Cantons { get; set; } = null!;
        public DbSet<Guests> Guests { get; set; } = null!;
        public DbSet<Issues> Issues { get; set; } = null!;
        public DbSet<EmpresasProductos> EmpresasProductos { get; set; } = null!;
        public DbSet<IssueDetails> IssueDetails { get; set; } = null!;
        public DbSet<IssueTimings> IssueTimings { get; set; } = null!;
        public DbSet<IssueFiles> IssueFiles { get; set; } = null!;
        public DbSet<Projects> Projects { get; set; } = null!;
        public DbSet<ProjectsPerClients> ProjectsPerClients { get; set; } = null!;
        public virtual DbSet<Facturaspago> FacturaPagos { get; set; } = null!;
        public virtual DbSet<Facturastarjetacredito> FacturasTarjetaCredito { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new PlanHeaderConfiguration());
            modelBuilder.ApplyConfiguration(new PlanDetailConfiguration());
            modelBuilder.ApplyConfiguration(new PlanHeaderXDetailConfiguration());
            modelBuilder.ApplyConfiguration(new TemplateMailsConfiguration());
            modelBuilder.ApplyConfiguration(new MailingConfiguration());
            modelBuilder.ApplyConfiguration(new RestorePasswordConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyInformationConfiguration());
            modelBuilder.ApplyConfiguration(new FacturasCabeceraConfiguration());
            modelBuilder.ApplyConfiguration(new FacturasDetalleConfiguration());
            modelBuilder.ApplyConfiguration(new FacturasPagoConfiguration());
            modelBuilder.ApplyConfiguration(new FacturasTarjetaCreditoConfiguration());
            modelBuilder.ApplyConfiguration(new BodegasConfiguration());
            modelBuilder.ApplyConfiguration(new ProductosConfiguration());
            modelBuilder.ApplyConfiguration(new EmpleadosConfiguration());
            modelBuilder.ApplyConfiguration(new PuntosFacturaConfiguration());
            modelBuilder.ApplyConfiguration(new BillingParamsConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new ContractedPlansConfiguration());
            modelBuilder.ApplyConfiguration(new ProvinciaConfiguration());
            modelBuilder.ApplyConfiguration(new GuestConfiguration());
            modelBuilder.ApplyConfiguration(new CantonConfiguration());
            modelBuilder.ApplyConfiguration(new IssuesConfiguration());
            modelBuilder.ApplyConfiguration(new IssueDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new IssueTimingsConfiguration());
            modelBuilder.ApplyConfiguration(new IssueFilesConfiguration());
            modelBuilder.ApplyConfiguration(new EmpresasProductosConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectsConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectsPerClientsConfiguration());
        }
    }
}
