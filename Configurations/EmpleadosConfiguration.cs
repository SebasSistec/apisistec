using apisistec.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apisistec.Configurations
{
    public class EmpleadosConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> entity)
        {
            entity.HasKey(e => e.CodigoEmpleado).HasName("PRIMARY");

            entity.ToTable("empleados", x => x.ExcludeFromMigrations());

            entity.HasComment("Empleado;NombreEmpleado,ApellidoEmpleado");

            entity.HasIndex(e => e.CodigoEmpleado, "CodigoEmpleado");

            entity.HasIndex(e => e.TipoIdentificacionReemplazaEmpleado, "FK_TipoIdentificacionReemplaza_Empleado");

            entity.HasIndex(e => e.TiposIdentificacionEmpleado, "FK_TipoIdentificacion_Empleado");

            entity.HasIndex(e => e.TiposEmpleadosEmpleado, "FK_empleados_TipoEmpleado");

            entity.HasIndex(e => e.TitulosEmpleado, "FK_empleados_Titulos");

            entity.HasIndex(e => e.ApellidoEmpleado, "Index_Apellido");

            entity.HasIndex(e => e.CedulaEmpleado, "Index_Cedula");

            entity.HasIndex(e => e.NombreEmpleado, "Index_Nombre");

            entity.HasIndex(e => new { e.NombreEmpleado, e.ApellidoEmpleado }, "NombreApellido").IsUnique();

            entity.HasIndex(e => e.PerfilesEmpleado, "PerfilesEmpleado");

            entity.HasIndex(e => e.NombreUsuarioEmpleado, "Usuario").IsUnique();

            entity.HasIndex(e => e.SucursalesEmpleado, "sucursales_fk");

            entity.Property(e => e.CodigoEmpleado).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Codigo;text;true;false;Administracion;180;left");

            entity.Property(e => e.AdelantoQuincenalEmpleado).HasColumnType("double(16,4)").HasDefaultValueSql("'0.0000'");

            entity.Property(e => e.ApellidoEmpleado).HasMaxLength(100).HasDefaultValueSql("''").HasComment("Apellidos;text;true;true;Administracion;180;left");

            entity.Property(e => e.BonoAlimentacionEmpleado).HasColumnType("double(16,4)");

            entity.Property(e => e.BonoFijoEmpleado).HasColumnType("double(16,4)");

            entity.Property(e => e.BonoVariableEmpleado).HasColumnType("double(16,4)");

            entity.Property(e => e.CalcularFondosReservaEmpleado).HasMaxLength(1).HasDefaultValueSql("''");

            entity.Property(e => e.CambiadoClaveEmpleado).HasMaxLength(1).HasDefaultValueSql("''").HasComment("0 No ha cambiado 1 Cambio clave");

            entity.Property(e => e.CambiarPrimeraVezEmpleado).HasMaxLength(1).HasDefaultValueSql("''").HasComment("1 Cambiar 0 No Cambiar");

            entity.Property(e => e.CargaFamiliarEmpleado).HasColumnType("int(11)").HasComment("Numero de Cargas Familiares;text;true;true;Datos Personales;180;left");

            entity.Property(e => e.CedulaEmpleado).HasMaxLength(10).HasDefaultValueSql("''").HasComment("Número de Cédula;text;true;true;Datos Personales;180;left");

            entity.Property(e => e.CedulaRemplazoDiscapacidadEmplead).HasMaxLength(10).HasDefaultValueSql("''");

            entity.Property(e => e.ClaveCaducaEmpleado).HasMaxLength(1).HasDefaultValueSql("''").HasComment("0 No Caduca 1 Si Caduca");

            entity.Property(e => e.ClaveUsuarioEmpleado).HasColumnType("blob").HasComment("Clave Personal;txt;true;true;Administracion;180;left");

            entity.Property(e => e.ConvenioEvitarDobleImposicionEmpleado).HasMaxLength(2).HasDefaultValueSql("'NA'");

            entity.Property(e => e.CostaEmpleado).HasMaxLength(1).HasDefaultValueSql("''").HasComment("Determina si un empleado trabaja en la costa");

            entity.Property(e => e.CuentaBancariaEmpleado).HasMaxLength(30).HasComment("numero de cta bancaria del empleado");

            entity.Property(e => e.CuentasBancariasOrigenEmpleado).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.CuentasContabilidadAnticipoEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadAtrazoEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadBonoAlimenticio).HasMaxLength(20).HasDefaultValueSql("'0.00.00.000.000'");

            entity.Property(e => e.CuentasContabilidadBonoFijo).HasMaxLength(20).HasDefaultValueSql("'0.00.00.000.000'");

            entity.Property(e => e.CuentasContabilidadBonoVariable).HasMaxLength(20).HasDefaultValueSql("'0.00.00.000.000'");

            entity.Property(e => e.CuentasContabilidadComisionesEmpleado).HasMaxLength(20).HasDefaultValueSql("'5.01.02.005.001'");

            entity.Property(e => e.CuentasContabilidadDesahucioEmpleado).HasMaxLength(20);

            entity.Property(e => e.CuentasContabilidadDespidoEmpleado).HasMaxLength(20);

            entity.Property(e => e.CuentasContabilidadEmpleado).HasMaxLength(18).HasDefaultValueSql("''").HasComment("Cuenta Contable Asignada;cmd;true;true;Contabilidad;180;left;Select CodigoCuentaContable, NombreCuentaContable from cuentascontabilidad");

            entity.Property(e => e.CuentasContabilidadFondoReservaEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadGastoDesahucioEmpleado).HasMaxLength(20);

            entity.Property(e => e.CuentasContabilidadGastoEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadHoraExtraordinariaEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadHoraJornadaNocturna).HasMaxLength(20);

            entity.Property(e => e.CuentasContabilidadHoraSuplementariaEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadIessEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadIessGastoPatronalEmpleado).HasMaxLength(20).HasDefaultValueSql("'5.01.02.002.002'");

            entity.Property(e => e.CuentasContabilidadIessPatronalEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadMultaEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadNominasEmpleado).HasMaxLength(20).HasDefaultValueSql("'2.01.07.003.001'");

            entity.Property(e => e.CuentasContabilidadOtrosEgresosEmpleado).HasMaxLength(20);

            entity.Property(e => e.CuentasContabilidadOtrosIngresosEmpleado).HasMaxLength(20);

            entity.Property(e => e.CuentasContabilidadPrestamoEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadPrestamosIess).HasMaxLength(20).HasDefaultValueSql("'2.01.07.001.003'");

            entity.Property(e => e.CuentasContabilidadProvisionDecimoXiiiempleado).HasMaxLength(20).HasColumnName("CuentasContabilidadProvisionDecimoXIIIEmpleado").HasDefaultValueSql("'2.01.07.001.001'");

            entity.Property(e => e.CuentasContabilidadProvisionDecimoXivempleado).HasMaxLength(20).HasColumnName("CuentasContabilidadProvisionDecimoXIVEmpleado").HasDefaultValueSql("'2.01.07.001.002'");

            entity.Property(e => e.CuentasContabilidadProvisionFondoReservaEmpleado).HasMaxLength(20).HasDefaultValueSql("'2.01.07.001.004'");

            entity.Property(e => e.CuentasContabilidadProvisionVacacionesEmpleado).HasMaxLength(20).HasDefaultValueSql("'2.01.07.001.003'");

            entity.Property(e => e.CuentasContabilidadQuincena).HasMaxLength(20).HasDefaultValueSql("'1.01.02.010.160'");

            entity.Property(e => e.CuentasContabilidadRubrosEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadSaldoEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadVacacionEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadViaticoEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadXiiiEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.CuentasContabilidadXivEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.DiasLaboraTiempoParcialEmpleado).HasMaxLength(3).HasDefaultValueSql("'0'").HasComment("indica los dias que el empleado labora si trabaja a tiempo parcial.");

            entity.Property(e => e.DireccionDosEmpleado).HasMaxLength(255).HasDefaultValueSql("''").HasComment("Direccion Adicional;text;true;true;Datos Personales;180;left");

            entity.Property(e => e.DireccionUnoEmpleado).HasMaxLength(255).HasDefaultValueSql("''").HasComment("Domicilio;text;true;true;Datos Personales;180;left");

            entity.Property(e => e.DiscapacidadEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.DuracionContratoEmpleado).HasMaxLength(3).HasComment("numero de meses que dura el contrato del empleado con la empresa");

            entity.Property(e => e.EmailEmpleado).HasMaxLength(255).HasDefaultValueSql("''").HasComment("Email Oficina;text;true;true;Administracion;180;left");

            entity.Property(e => e.EmailEmpleadoPersonal).HasMaxLength(255).HasDefaultValueSql("'NA'").HasComment("Email Personal;text;true;true;Datos Personales;180;left");

            entity.Property(e => e.EmpresasEmpleado).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.EntregarDecimoEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("indica si el empleado quiere recibir el decimo en el salario mensual. 1 mensual, 0 no mensual.");

            entity.Property(e => e.EntregarDecimoIvempleado).HasMaxLength(1).HasColumnName("EntregarDecimoIVEmpleado").HasDefaultValueSql("'0'");

            entity.Property(e => e.EspecialidadesMedicasEmpleado).HasMaxLength(20).HasDefaultValueSql("'0'");

            entity.Property(e => e.EstadosCivilesPersonasEmpleados).HasMaxLength(20);

            entity.Property(e => e.FechaCaducaClaveEmpleado).HasDefaultValueSql("'1900-01-01'");

            entity.Property(e => e.FechaCaducaUsuarioEmpleado).HasDefaultValueSql("'1900-01-01'");

            entity.Property(e => e.FechaCalculoVacacionesEmpleado).HasDefaultValueSql("'1900-01-01'");

            entity.Property(e => e.FechaNacimientoEmpleado).HasDefaultValueSql("'1900-01-01'").HasComment("Fecha de Nacimiento;cal;true;true;Datos Personales;180;left");

            entity.Property(e => e.FondosReservaEmpleado).HasMaxLength(1).HasDefaultValueSql("''").HasComment("Determina si a un empleado se le entrega directamente los fondo de reserva");

            entity.Property(e => e.FormularioInicialEmpleado).HasMaxLength(255).HasDefaultValueSql("'frmmarcacion.aspx'");

            entity.Property(e => e.GeneroEmpleado).HasMaxLength(1);

            entity.Property(e => e.HoraExtraEmpleado).HasMaxLength(1).HasDefaultValueSql("''");

            entity.Property(e => e.HoraIngresoEmpleado).HasColumnType("time").HasDefaultValueSql("'08:30:00'").HasComment("Almacena la hora de ingreso en la mañana");

            entity.Property(e => e.HoraSalidaEmpleado).HasColumnType("time").HasDefaultValueSql("'18:00:00'").HasComment("Almacena la hora de la salida en la tarde");

            entity.Property(e => e.IesscodigosSectorialesEmpleado).HasMaxLength(20).HasColumnName("IESSCodigosSectorialesEmpleado");

            entity.Property(e => e.ImagenEmpleado).HasMaxLength(100).HasDefaultValueSql("'General/Avatar.svg'");

            entity.Property(e => e.Ip).HasMaxLength(52).HasColumnName("IP").HasDefaultValueSql("''");

            entity.Property(e => e.LetraCambioEmpleado).HasColumnType("double(16,2)");

            entity.Property(e => e.MarcarEmpleado).HasMaxLength(1).HasDefaultValueSql("''");

            entity.Property(e => e.NoCalculaBeneficiosEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("indica si el empleado calculo beneficios sociales");

            entity.Property(e => e.NombreEmpleado).HasMaxLength(150).HasDefaultValueSql("''").HasComment("Nombres;text;true;true;Administracion;180;left");

            entity.Property(e => e.NombreUsuarioEmpleado).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Nombre de Usuario;text;true;true;Administracion;180;left");

            entity.Property(e => e.NumeroCarnetConadisEmpleado).HasMaxLength(20);

            entity.Property(e => e.NumeroDiasFinSemanaVacacionTomadosEmpleado).HasColumnType("int(3)");

            entity.Property(e => e.NumeroDiasHabilesVacacionTomadosEmpleado).HasColumnType("int(3)");

            entity.Property(e => e.PaisResidenciaEmpleado).HasMaxLength(20).HasDefaultValueSql("'593'");

            entity.Property(e => e.PerfilesEmpleado).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Perfil de Usuario;cmb;true;true;Administracion;180;left;select CodigoPerfil, NombrePerfil from perfiles");

            entity.Property(e => e.PermiteAgendamientoEmpleados).HasColumnType("int(1)").HasComment("Parámetro que sirve para filtrar los empleados en el módulo de agendamiento");

            entity.Property(e => e.PlantillaCuentasEmpleados).HasMaxLength(36).HasDefaultValueSql("''");

            entity.Property(e => e.PorcentajeAnticipoEmpleado).HasColumnType("double(16,4)").HasDefaultValueSql("'70.0000'");

            entity.Property(e => e.PorcentajeDiscapacidadEmpleado).HasPrecision(10, 2);

            entity.Property(e => e.PorcentajeIessEmpleados).HasPrecision(8, 2).HasDefaultValueSql("'9.45'");

            entity.Property(e => e.PorcentajeIessPatronoEmpleados).HasPrecision(16, 2).HasDefaultValueSql("'12.15'");

            entity.Property(e => e.PresupuestarEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("indica si al empleado se le debe crear un presupuesto de ventas.");

            entity.Property(e => e.RepresentanteLegalEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("indica si el empleado es el representante legal de la empresa");

            entity.Property(e => e.RolPagoEmpleado).HasMaxLength(1).HasDefaultValueSql("''");

            entity.Property(e => e.SeleccionaEmpresaEmpleado).HasColumnType("int(5)").HasDefaultValueSql("'1'").HasComment("Debe Elegir Empresa?;chk;true;true;Administracion;180;left");

            entity.Property(e => e.SeleccionaSucursalEmpleado).HasColumnType("int(5)").HasDefaultValueSql("'1'").HasComment("Debe elegir Sucursal?;chk;true;true;Administracion;180;left");

            entity.Property(e => e.SistemaSalarioNetoEmpleado).HasMaxLength(1).HasDefaultValueSql("'1'");

            entity.Property(e => e.SucursalesEmpleado).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Sucursal de Pertenencia;cmb;true;true;Administracion;180;left;select CodigoSucursal, NombreSucursal from sucursales");

            entity.Property(e => e.SueldoNominalEmpleado).HasColumnType("double(16,4)").HasComment("Sueldo Nominal;text;true;true;Contabilidad;180;left");

            entity.Property(e => e.SustitutoEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("indii el empleado es empleado sustituto de un miembro de la familia discapacitado");

            entity.Property(e => e.TelefonoDosEmpleado).HasMaxLength(12).HasDefaultValueSql("''").HasComment("Teléfono Adicional;text;true;true;Datos Personales;180;left");

            entity.Property(e => e.TelefonoTresEmpleado).HasMaxLength(12).HasDefaultValueSql("''").HasComment("Celular;text;true;true;Datos Personales;180;left");

            entity.Property(e => e.TelefonoUnoEmpleado).HasMaxLength(12).HasDefaultValueSql("''").HasComment("Teléfono;text;true;true;Datos Personales;180;left");

            entity.Property(e => e.TiempoAlmuerzoEmpleado).HasColumnType("int(3)").HasDefaultValueSql("'90'").HasComment("Almacena el numero de minutos de tiempo de almuerzo del empleado");

            entity.Property(e => e.TipoCuentaBancariaEmpleado).HasMaxLength(2).HasComment("indica el tipo de cta bancaria del empleado");

            entity.Property(e => e.TipoIdentificacionReemplazaEmpleado).HasMaxLength(20);

            entity.Property(e => e.TipoResidenciaEmpleado).HasMaxLength(45).HasDefaultValueSql("'01'");

            entity.Property(e => e.TipoSincronizacionEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'").IsFixedLength();

            entity.Property(e => e.TiposEmpleadosEmpleado).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Cargo de Empleado;cmb;true;true;Administracion;180;left;select CodigoTipoEmpleado, NombreTipoEmpleado from tiposempleados");

            entity.Property(e => e.TiposIdentificacionEmpleado).HasMaxLength(20).HasDefaultValueSql("'1'");

            entity.Property(e => e.TiposRubroEmpleados).HasMaxLength(20).HasDefaultValueSql("''");

            entity.Property(e => e.TiposSangrePersonasEmpleados).HasMaxLength(20);

            entity.Property(e => e.TitulosEmpleado).HasMaxLength(20).HasDefaultValueSql("''").HasComment("Titulo - Profesion;cmb;true;true;Administracion;180;left;select CodigoTitulo, NombreTitulo from titulos");

            entity.Property(e => e.TrabajaConstruccionEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'");

            entity.Property(e => e.TrabajaTiempoParcialEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("indica si el empleado trabaja a tiempo parcial, 1 parcial, 0 completo");

            entity.Property(e => e.UsuarioCaducaEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'").HasComment("0 No Caduca 1 Caduca");

            entity.Property(e => e.UsuariosEmpleado).HasMaxLength(20).HasDefaultValueSql("'fmaldonado'");

            entity.Property(e => e.ValorFondoReservaEmpleado).HasColumnType("double(16,4)");

            entity.Property(e => e.VerCostoEmpleado).HasMaxLength(1).HasDefaultValueSql("'1'");

            entity.Property(e => e.WebUsuarioEmpleado).HasMaxLength(1).HasDefaultValueSql("'0'");
        }
    }
}
