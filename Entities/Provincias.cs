namespace apisistec.Entities
{
    public class Provincias
    {
        public string CodigoLocalizacionProvincia { get; set; } = string.Empty;
        public string CodigoInecLocalizacionProvincia { get; set; } = string.Empty;
        public string NombreLocalizacionProvincia { get; set; } = string.Empty;
        public string AbreviadoLocalizacionProvincia { get; set; } = string.Empty;
        public string PaisesLocalizacionProvincia { get; set; } = string.Empty;
        public string CodigoMatriculacionLocalizacionProvincia { get; set; } = string.Empty;
        public string UsuariosLocalizacionProvincia { get; set; } = string.Empty;
        public List<Cantones> Cantones { get; set; } = new();
    }
}
