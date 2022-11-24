using Models;

namespace apisistec.Entities
{
    public class BillingParams // PENDING Add params in production
    {
        public Guid Id { get; set; }
        public string PuntoFacturaId { get; set; }
        public string EmpleadoId { get; set; }
        public string BodegaId { get; set; }
        public string ProductoId { get; set; }
        public int IsValidPayment { get; set; }

        //FK
        public Puntosfactura Puntosfactura { get; set; }
        public Empleado Empleado { get; set; }
        public Bodega Bodega { get; set; }
        public Producto Producto { get; set; }
    }
}
