using apisistec.Models;
using Microsoft.EntityFrameworkCore;

namespace apisistec.Context
{
    public class DataContextProcedures : DbContext
    {
        public DataContextProcedures(DbContextOptions<DataContextProcedures> options) : base(options) { }
        public DbSet<AsientosCabecera> AsientoCabecera { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AsientosCabecera>(entity =>
            {
                entity.HasNoKey();
                entity.Property(x => x.Asientos);
            });
        }
    }
}
