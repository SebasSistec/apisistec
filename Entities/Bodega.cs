using apisistec.Entities;

namespace Models
{
    /// <summary>
    /// Bodega;like NombreBodegas
    /// </summary>
    public partial class Bodega
    {
        /// <summary>
        /// Codigo Bodega;text;true;false;Datos;180;left
        /// </summary>
        public string CodigoBodega { get; set; } = null!;
        /// <summary>
        /// Nombre Bodega;text;true;true;Datos;180;left
        /// </summary>
        public string NombreBodega { get; set; } = null!;
        /// <summary>
        /// Bodega para facturar;chk;true;true;Datos;180;left
        /// </summary>
        public string FacturaBodega { get; set; } = null!;
        /// <summary>
        /// Bodega consignar;chk;true;true;Datos;180;left
        /// </summary>
        public string ConsignacionBodega { get; set; } = null!;
        /// <summary>
        /// Considera Inventario;chk;true;true;Datos;180;left
        /// </summary>
        public string InventarioBodega { get; set; } = null!;
        /// <summary>
        /// Considera para reposicion;chk;true;true;Datos;180;left
        /// </summary>
        public string? ReposicionBodega { get; set; }
        /// <summary>
        /// Bodega Deshabilitada;chk;true;true;Datos;180;left
        /// </summary>
        public string DeshabilitadaBodega { get; set; } = null!;
        /// <summary>
        /// Bodega de Activos;chk;true;true;Datos;180;left
        /// </summary>
        public string ActivosBodega { get; set; } = null!;
        /// <summary>
        /// Empresa a la que pertenece;cmb;true;true;Datos;180;left;select codigoempresa,nombreempresa from empresas
        /// </summary>
        public string EmpresasBodega { get; set; } = null!;
        /// <summary>
        /// Sucursal a la que pertenece;cmb;true;true;Datos;180;left;select codigosucursal,nombresucursal from sucursales
        /// </summary>
        public string SucursalesBodega { get; set; } = null!;
        public string SincronizarBodega { get; set; } = null!;
        /// <summary>
        /// Generar Pendientes Despacho;chk;true;true;Datos;180;left
        /// </summary>
        public int GenerarPendienteDespachoBodega { get; set; }
        /// <summary>
        /// Sincronizar Ecommerce;chk;true;true;Datos;180;left
        /// </summary>
        public int SincronizarEcommerceBodega { get; set; }
        public string CodigoEcommerceBodega { get; set; } = null!;
        /// <summary>
        /// Secuencia Devolucion Mercaderia;text;true;true;Datos;180;left
        /// </summary>
        public int SecuenciaDevolucionBodega { get; set; }
        public int NumeroOrdenBodega { get; set; }
        public int Activarparaxadis { get; set; }
        public string UsuariosBodega { get; set; } = null!;
        public List<BillingParams> BillingParams { get; set; } = new();

    }
}
