namespace apisistec.Entities
{
    /// <summary>
    /// Empleado;NombreEmpleado,ApellidoEmpleado
    /// </summary>
    public partial class Empleado
    {
        /// <summary>
        /// Codigo;text;true;false;Administracion;180;left
        /// </summary>
        public string CodigoEmpleado { get; set; } = null!;
        /// <summary>
        /// Nombres;text;true;true;Administracion;180;left
        /// </summary>
        public string NombreEmpleado { get; set; } = null!;
        /// <summary>
        /// Apellidos;text;true;true;Administracion;180;left
        /// </summary>
        public string ApellidoEmpleado { get; set; } = null!;
        /// <summary>
        /// Email Oficina;text;true;true;Administracion;180;left
        /// </summary>
        public string EmailEmpleado { get; set; } = null!;
        /// <summary>
        /// Cargo de Empleado;cmb;true;true;Administracion;180;left;select CodigoTipoEmpleado, NombreTipoEmpleado from tiposempleados
        /// </summary>
        public string TiposEmpleadosEmpleado { get; set; } = null!;
        /// <summary>
        /// Perfil de Usuario;cmb;true;true;Administracion;180;left;select CodigoPerfil, NombrePerfil from perfiles
        /// </summary>
        public string PerfilesEmpleado { get; set; } = null!;
        /// <summary>
        /// Nombre de Usuario;text;true;true;Administracion;180;left
        /// </summary>
        public string NombreUsuarioEmpleado { get; set; } = null!;
        /// <summary>
        /// Clave Personal;txt;true;true;Administracion;180;left
        /// </summary>
        public byte[] ClaveUsuarioEmpleado { get; set; } = null!;
        /// <summary>
        /// 1 Cambiar 0 No Cambiar
        /// </summary>
        public string CambiarPrimeraVezEmpleado { get; set; } = null!;
        /// <summary>
        /// 0 No Caduca 1 Si Caduca
        /// </summary>
        public string ClaveCaducaEmpleado { get; set; } = null!;
        public DateTime FechaCaducaClaveEmpleado { get; set; }
        /// <summary>
        /// 0 No Caduca 1 Caduca
        /// </summary>
        public string UsuarioCaducaEmpleado { get; set; } = null!;
        public DateTime FechaCaducaUsuarioEmpleado { get; set; }
        /// <summary>
        /// Debe Elegir Empresa?;chk;true;true;Administracion;180;left
        /// </summary>
        public int SeleccionaEmpresaEmpleado { get; set; }
        /// <summary>
        /// Debe elegir Sucursal?;chk;true;true;Administracion;180;left
        /// </summary>
        public int SeleccionaSucursalEmpleado { get; set; }
        public string EmpresasEmpleado { get; set; } = null!;
        /// <summary>
        /// Sucursal de Pertenencia;cmb;true;true;Administracion;180;left;select CodigoSucursal, NombreSucursal from sucursales
        /// </summary>
        public string SucursalesEmpleado { get; set; } = null!;
        public string TiposIdentificacionEmpleado { get; set; } = null!;
        /// <summary>
        /// Número de Cédula;text;true;true;Datos Personales;180;left
        /// </summary>
        public string CedulaEmpleado { get; set; } = null!;
        /// <summary>
        /// Titulo - Profesion;cmb;true;true;Administracion;180;left;select CodigoTitulo, NombreTitulo from titulos
        /// </summary>
        public string TitulosEmpleado { get; set; } = null!;
        public string EspecialidadesMedicasEmpleado { get; set; } = null!;
        /// <summary>
        /// Domicilio;text;true;true;Datos Personales;180;left
        /// </summary>
        public string DireccionUnoEmpleado { get; set; } = null!;
        /// <summary>
        /// Direccion Adicional;text;true;true;Datos Personales;180;left
        /// </summary>
        public string DireccionDosEmpleado { get; set; } = null!;
        /// <summary>
        /// Teléfono;text;true;true;Datos Personales;180;left
        /// </summary>
        public string TelefonoUnoEmpleado { get; set; } = null!;
        /// <summary>
        /// Teléfono Adicional;text;true;true;Datos Personales;180;left
        /// </summary>
        public string TelefonoDosEmpleado { get; set; } = null!;
        /// <summary>
        /// Celular;text;true;true;Datos Personales;180;left
        /// </summary>
        public string TelefonoTresEmpleado { get; set; } = null!;
        /// <summary>
        /// Email Personal;text;true;true;Datos Personales;180;left
        /// </summary>
        public string EmailEmpleadoPersonal { get; set; } = null!;
        /// <summary>
        /// Fecha de Nacimiento;cal;true;true;Datos Personales;180;left
        /// </summary>
        public DateTime? FechaNacimientoEmpleado { get; set; }
        /// <summary>
        /// Numero de Cargas Familiares;text;true;true;Datos Personales;180;left
        /// </summary>
        public int CargaFamiliarEmpleado { get; set; }
        /// <summary>
        /// Cuenta Contable Asignada;cmd;true;true;Contabilidad;180;left;Select CodigoCuentaContable, NombreCuentaContable from cuentascontabilidad
        /// </summary>
        public string CuentasContabilidadEmpleado { get; set; } = null!;
        public string CuentasContabilidadAnticipoEmpleado { get; set; } = null!;
        public string CuentasContabilidadViaticoEmpleado { get; set; } = null!;
        public string CuentasContabilidadPrestamoEmpleado { get; set; } = null!;
        public string CuentasContabilidadSaldoEmpleado { get; set; } = null!;
        public string CuentasContabilidadGastoEmpleado { get; set; } = null!;
        public string CuentasContabilidadIessEmpleado { get; set; } = null!;
        public string CuentasContabilidadIessPatronalEmpleado { get; set; } = null!;
        public string CuentasContabilidadIessGastoPatronalEmpleado { get; set; } = null!;
        public string CuentasContabilidadXiiiEmpleado { get; set; } = null!;
        public string CuentasContabilidadXivEmpleado { get; set; } = null!;
        public string CuentasContabilidadFondoReservaEmpleado { get; set; } = null!;
        public string CuentasContabilidadHoraJornadaNocturna { get; set; } = null!;
        public string CuentasContabilidadHoraSuplementariaEmpleado { get; set; } = null!;
        public string CuentasContabilidadHoraExtraordinariaEmpleado { get; set; } = null!;
        public string CuentasContabilidadRubrosEmpleado { get; set; } = null!;
        public string CuentasContabilidadAtrazoEmpleado { get; set; } = null!;
        public string CuentasContabilidadMultaEmpleado { get; set; } = null!;
        public string CuentasContabilidadVacacionEmpleado { get; set; } = null!;
        public string CuentasContabilidadComisionesEmpleado { get; set; } = null!;
        public string CuentasContabilidadNominasEmpleado { get; set; } = null!;
        public string CuentasContabilidadProvisionFondoReservaEmpleado { get; set; } = null!;
        public string CuentasContabilidadProvisionDecimoXiiiempleado { get; set; } = null!;
        public string CuentasContabilidadProvisionDecimoXivempleado { get; set; } = null!;
        public string CuentasContabilidadProvisionVacacionesEmpleado { get; set; } = null!;
        public string CuentasContabilidadPrestamosIess { get; set; } = null!;
        public string CuentasContabilidadQuincena { get; set; } = null!;
        public string CuentasContabilidadBonoFijo { get; set; } = null!;
        public string CuentasContabilidadBonoVariable { get; set; } = null!;
        public string CuentasContabilidadBonoAlimenticio { get; set; } = null!;
        /// <summary>
        /// Sueldo Nominal;text;true;true;Contabilidad;180;left
        /// </summary>
        public double SueldoNominalEmpleado { get; set; }
        public double? AdelantoQuincenalEmpleado { get; set; }
        /// <summary>
        /// Almacena la hora de ingreso en la mañana
        /// </summary>
        public TimeSpan HoraIngresoEmpleado { get; set; }
        /// <summary>
        /// Almacena la hora de la salida en la tarde
        /// </summary>
        public TimeSpan HoraSalidaEmpleado { get; set; }
        /// <summary>
        /// Almacena el numero de minutos de tiempo de almuerzo del empleado
        /// </summary>
        public int TiempoAlmuerzoEmpleado { get; set; }
        public double LetraCambioEmpleado { get; set; }
        /// <summary>
        /// Determina si un empleado trabaja en la costa
        /// </summary>
        public string CostaEmpleado { get; set; } = null!;
        /// <summary>
        /// Determina si a un empleado se le entrega directamente los fondo de reserva
        /// </summary>
        public string FondosReservaEmpleado { get; set; } = null!;
        public string RolPagoEmpleado { get; set; } = null!;
        public string HoraExtraEmpleado { get; set; } = null!;
        public string MarcarEmpleado { get; set; } = null!;
        public string CalcularFondosReservaEmpleado { get; set; } = null!;
        /// <summary>
        /// 0 No ha cambiado 1 Cambio clave
        /// </summary>
        public string CambiadoClaveEmpleado { get; set; } = null!;
        public string FormularioInicialEmpleado { get; set; } = null!;
        public double PorcentajeAnticipoEmpleado { get; set; }
        public int NumeroDiasHabilesVacacionTomadosEmpleado { get; set; }
        public int NumeroDiasFinSemanaVacacionTomadosEmpleado { get; set; }
        public string TipoSincronizacionEmpleado { get; set; } = null!;
        /// <summary>
        /// indica si el empleado quiere recibir el decimo en el salario mensual. 1 mensual, 0 no mensual.
        /// </summary>
        public string EntregarDecimoEmpleado { get; set; } = null!;
        public string EntregarDecimoIvempleado { get; set; } = null!;
        public double BonoFijoEmpleado { get; set; }
        public double BonoVariableEmpleado { get; set; }
        public double BonoAlimentacionEmpleado { get; set; }
        public double ValorFondoReservaEmpleado { get; set; }
        public string TipoResidenciaEmpleado { get; set; } = null!;
        public string? PaisResidenciaEmpleado { get; set; }
        public string DiscapacidadEmpleado { get; set; } = null!;
        public string ConvenioEvitarDobleImposicionEmpleado { get; set; } = null!;
        public decimal PorcentajeDiscapacidadEmpleado { get; set; }
        public string? TipoIdentificacionReemplazaEmpleado { get; set; }
        public string CedulaRemplazoDiscapacidadEmplead { get; set; } = null!;
        public string SistemaSalarioNetoEmpleado { get; set; } = null!;
        /// <summary>
        /// indica si el empleado trabaja a tiempo parcial, 1 parcial, 0 completo
        /// </summary>
        public string TrabajaTiempoParcialEmpleado { get; set; } = null!;
        /// <summary>
        /// indica si al empleado se le debe crear un presupuesto de ventas.
        /// </summary>
        public string PresupuestarEmpleado { get; set; } = null!;
        /// <summary>
        /// indica si el empleado es el representante legal de la empresa
        /// </summary>
        public string RepresentanteLegalEmpleado { get; set; } = null!;
        /// <summary>
        /// numero de cta bancaria del empleado
        /// </summary>
        public string CuentaBancariaEmpleado { get; set; } = null!;
        /// <summary>
        /// indica el tipo de cta bancaria del empleado
        /// </summary>
        public string TipoCuentaBancariaEmpleado { get; set; } = null!;
        /// <summary>
        /// numero de meses que dura el contrato del empleado con la empresa
        /// </summary>
        public string DuracionContratoEmpleado { get; set; } = null!;
        /// <summary>
        /// indica si el empleado calculo beneficios sociales
        /// </summary>
        public string NoCalculaBeneficiosEmpleado { get; set; } = null!;
        /// <summary>
        /// indica los dias que el empleado labora si trabaja a tiempo parcial.
        /// </summary>
        public string DiasLaboraTiempoParcialEmpleado { get; set; } = null!;
        public string VerCostoEmpleado { get; set; } = null!;
        public string ImagenEmpleado { get; set; } = null!;
        public string NumeroCarnetConadisEmpleado { get; set; } = null!;
        /// <summary>
        /// indii el empleado es empleado sustituto de un miembro de la familia discapacitado
        /// </summary>
        public string SustitutoEmpleado { get; set; } = null!;
        public string UsuariosEmpleado { get; set; } = null!;
        public string IesscodigosSectorialesEmpleado { get; set; } = null!;
        public string EstadosCivilesPersonasEmpleados { get; set; } = null!;
        public string TiposSangrePersonasEmpleados { get; set; } = null!;
        public string GeneroEmpleado { get; set; } = null!;
        public string CuentasBancariasOrigenEmpleado { get; set; } = null!;
        public DateTime FechaCalculoVacacionesEmpleado { get; set; }
        public string CuentasContabilidadDesahucioEmpleado { get; set; } = null!;
        public string CuentasContabilidadGastoDesahucioEmpleado { get; set; } = null!;
        public string CuentasContabilidadDespidoEmpleado { get; set; } = null!;
        public string CuentasContabilidadOtrosIngresosEmpleado { get; set; } = null!;
        public string CuentasContabilidadOtrosEgresosEmpleado { get; set; } = null!;
        public string WebUsuarioEmpleado { get; set; } = null!;
        public string TrabajaConstruccionEmpleado { get; set; } = null!;
        public string TiposRubroEmpleados { get; set; } = null!;
        public decimal PorcentajeIessEmpleados { get; set; }
        public decimal PorcentajeIessPatronoEmpleados { get; set; }
        /// <summary>
        /// Parámetro que sirve para filtrar los empleados en el módulo de agendamiento
        /// </summary>
        public int PermiteAgendamientoEmpleados { get; set; }
        public string PlantillaCuentasEmpleados { get; set; } = null!;
        public string Ip { get; set; } = null!;
        public List<BillingParams> BillingParams { get; set; } = new();
        public List<Issues> issuesToDo { get; set; } = new();
        public List<Issues> asignedIssues { get; set; } = new();
        public List<IssueDetails> issueDetails { get; set; } = new();
    }
}
