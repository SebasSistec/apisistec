namespace apisistec.Entities
{
    public class Cantones
    {
        public string CodigoLocalizacionCanton { get; set; } = string.Empty;
        public string CodigoInecLocalizacionCanton { get; set; } = string.Empty;
        public string NombreLocalizacionCanton { get; set; } = string.Empty;
        public string ProvinciasLocalizacionCanton { get; set; } = string.Empty;
        public string AbreviadoLocalizacionCanton { get; set; } = string.Empty;
        public string UsuariosLocalizacionCanton { get; set; } = string.Empty;
        public Provincias Provincia { get; set; } = null!;
    }
}
