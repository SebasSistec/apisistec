using Models;

namespace apisistec.Entities
{
    public class EmpresasProductos
    {
        public string EmpresasEmpresaProducto { get; set; }
        public string ProductosEmpresaProducto { get; set; }
        public decimal PrecioVentaProducto { get; set; }
        public Producto Product { get; set; }
    }
}
