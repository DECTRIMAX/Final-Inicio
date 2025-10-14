using Final_Inicio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Final_Inicio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            switch (userRole)
            {
                case "Ciudadano":
                    return View("DashboardCiudadano", new DashboardViewModel
                    {
                        UserName = userName,
                        UserId = userId,
                        UserRole = userRole
                    });
                case "Administrador":
                    ViewBag.Message = "Dashboard de Administrador - Próximamente";
                    return View("DashboardTemp");
                case "Empleado":
                    ViewBag.Message = "Dashboard de Empleado - Próximamente";
                    return View("DashboardTemp");
                default:
                    return RedirectToAction("AccessDenied", "Account");
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DashboardCiudadano()
        {
            var model = new DashboardViewModel
            {
                UserName = "Ciudadano",
                UserId = Guid.NewGuid().ToString(),
                UserRole = "Ciudadano"
            };
            ViewBag.Nombre = "Ciudadano";
            ViewBag.TipoAcceso = "Acceso Directo";
            ViewBag.FechaRegistro = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View(model);
        }

        public IActionResult DashboardOperativo()
        {
            ViewBag.TipoUsuario = "Operativo";
            ViewBag.Message = "Dashboard Operativo - Sistema de Gestión Municipal";
            return View("DashboardEmpleado");
        }

        // ======== DASHBOARDS OPERATIVOS ESPECÍFICOS ========

        public IActionResult OperativoAlumbrado()
        {
            ViewBag.TipoUsuario = "Operativo de Alumbrado";
            ViewBag.Area = "Alumbrado Público";
            ViewBag.Message = "Dashboard Operativo de Alumbrado - Gestión de Operaciones";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult OperativoBacheo()
        {
            ViewBag.TipoUsuario = "Operativo de Bacheo";
            ViewBag.Area = "Bacheo y Pavimentación";
            ViewBag.Message = "Dashboard Operativo de Bacheo - Gestión de Operaciones";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== DASHBOARDS ADMINISTRATIVOS ========

        public IActionResult DashboardAdmin()
        {
            ViewBag.TipoUsuario = "Administrador";
            ViewBag.Message = "Dashboard de Administrador - Panel de Control";
            return View("DashboardTemp");
        }

        public IActionResult DashboardJefeAdmin()
        {
            ViewBag.TipoUsuario = "Jefe de Administración";
            ViewBag.Message = "Dashboard Jefe de Administración - Supervisión General";
            return View("DashboardTemp");
        }

        public IActionResult DashboardDirector()
        {
            ViewBag.TipoUsuario = "Director";
            ViewBag.Message = "Dashboard Director - Panel Ejecutivo";
            return View("DashboardTemp");
        }

        // ======== DASHBOARDS ESPECÍFICOS POR ÁREA ========

        public IActionResult DashboardAdministradorAlumbrado()
        {
            ViewBag.TipoUsuario = "Administrador de Alumbrado";
            ViewBag.Area = "Alumbrado Público";
            ViewBag.Message = "Dashboard Administrador de Alumbrado - Gestión de Luminarias";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult DashboardAdministradorBacheo()
        {
            ViewBag.TipoUsuario = "Administrador de Bacheo";
            ViewBag.Area = "Bacheo y Pavimentación";
            ViewBag.Message = "Dashboard Administrador de Bacheo - Gestión de Pavimentación";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== DASHBOARD DE RECOLECCIÓN - NUEVO ========
        public IActionResult DashboardAdministradorRecoleccion()
        {
            ViewBag.TipoUsuario = "Administrador de Recolección";
            ViewBag.Area = "Recolección de Residuos";
            ViewBag.Message = "Dashboard Administrador de Recolección - Gestión Integral";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult DashboardEmpleadosAlumbrado()
        {
            ViewBag.TipoUsuario = "Empleado de Alumbrado";
            ViewBag.Area = "Alumbrado Público";
            ViewBag.Message = "Dashboard Empleados de Alumbrado - Operaciones de Campo";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult DashboardEmpleadosBacheo()
        {
            ViewBag.TipoUsuario = "Empleado de Bacheo";
            ViewBag.Area = "Bacheo y Pavimentación";
            ViewBag.Message = "Dashboard Empleados de Bacheo - Operaciones de Campo";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== SISTEMA DE ALMACÉN - NUEVO ========

        public IActionResult InicioAlmacen()
        {
            ViewBag.TipoUsuario = "Administrador de Almacén";
            ViewBag.Area = "Almacén de Servicios Primarios";
            ViewBag.Message = "Sistema de Gestión de Oficios y Almacén";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult AlmacenRegistros()
        {
            ViewBag.TipoUsuario = "Administrador de Almacén";
            ViewBag.Area = "Almacén de Registros";
            ViewBag.Message = "Archivo de Oficios Completados";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult Adquisiciones()
        {
            ViewBag.TipoUsuario = "Administrador de Adquisiciones";
            ViewBag.Area = "Gestión de Adquisiciones";
            ViewBag.Message = "Sistema de Compras y Pedidos";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult ReportesMateriales()
        {
            ViewBag.TipoUsuario = "Administrador de Almacén";
            ViewBag.Area = "Reportes de Materiales";
            ViewBag.Message = "Gestión de Entrega de Materiales a Departamentos";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // Obtener el departamento del query string si existe
            var dept = Request.Query["dept"].ToString();
            if (!string.IsNullOrEmpty(dept))
            {
                ViewBag.Departamento = dept switch
                {
                    "alumbrado" => "Alumbrado Público",
                    "bacheo" => "Bacheo",
                    "recoleccion" => "Recolección de Basura",
                    _ => "Departamento"
                };
            }

            return View();
        }

        public IActionResult AlumbradoSolicitudes()
        {
            ViewBag.TipoUsuario = "Alumbrado Público";
            ViewBag.Area = "Solicitudes de Material";
            ViewBag.Message = "Solicitudes de Material - Alumbrado Público";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult BacheoSolicitudes()
        {
            ViewBag.TipoUsuario = "Bacheo";
            ViewBag.Area = "Solicitudes de Material";
            ViewBag.Message = "Solicitudes de Material - Bacheo";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult RecoleccionSolicitudes()
        {
            ViewBag.TipoUsuario = "Recolección de Basura";
            ViewBag.Area = "Solicitudes de Material";
            ViewBag.Message = "Solicitudes de Material - Recolección de Basura";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== MÉTODOS ESPECÍFICOS DE ALUMBRADO PÚBLICO ========

        public IActionResult ProgramacionAlumbrado()
        {
            ViewBag.TipoUsuario = "Administrador de Alumbrado";
            ViewBag.Area = "Programación de Horarios";
            ViewBag.Message = "Sistema de Programación de Alumbrado Público";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult CapturaAlumbrado()
        {
            ViewBag.TipoUsuario = "Técnico de Alumbrado";
            ViewBag.Area = "Captura de Incidencias";
            ViewBag.Message = "Sistema de Captura de Reportes de Alumbrado Público";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult MapaAlumbrado()
        {
            ViewBag.TipoUsuario = "Operador de Alumbrado";
            ViewBag.Area = "Mapa Interactivo";
            ViewBag.Message = "Mapa Interactivo de Luminarias - Alumbrado Público";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult RastreoAlumbrado()
        {
            ViewBag.TipoUsuario = "Supervisor de Alumbrado";
            ViewBag.Area = "Rastreo de Unidades";
            ViewBag.Message = "Sistema de Rastreo GPS - Unidades de Alumbrado";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult DashboardAlumbrado()
        {
            ViewBag.TipoUsuario = "Analista de Alumbrado";
            ViewBag.Area = "Panel de Control";
            ViewBag.Message = "Dashboard Estadístico - Alumbrado Público";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult ReportesAlumbrado()
        {
            ViewBag.TipoUsuario = "Coordinador de Alumbrado";
            ViewBag.Area = "Reportes Ciudadanos";
            ViewBag.Message = "Gestión de Reportes Ciudadanos - Alumbrado Público";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult MaterialUtilizadoAlumbrado()
        {
            ViewBag.TipoUsuario = "Almacenista de Alumbrado";
            ViewBag.Area = "Control de Inventario";
            ViewBag.Message = "Sistema de Control de Material - Alumbrado Público";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult AsistenciaPersonalAlumbrado()
        {
            ViewBag.TipoUsuario = "Recursos Humanos Alumbrado";
            ViewBag.Area = "Control de Asistencia";
            ViewBag.Message = "Sistema de Asistencia Personal - Alumbrado Público";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== MÉTODOS ESPECÍFICOS DE BACHEO ========

        public IActionResult ProgramacionBacheo()
        {
            ViewBag.TipoUsuario = "Administrador de Bacheo";
            ViewBag.Area = "Programación de Obras";
            ViewBag.Message = "Sistema de Programación de Obras de Bacheo";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult CapturaBacheo()
        {
            ViewBag.TipoUsuario = "Técnico de Bacheo";
            ViewBag.Area = "Captura de Obras";
            ViewBag.Message = "Sistema de Captura de Obras de Bacheo";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult MapaBacheo()
        {
            ViewBag.TipoUsuario = "Operador de Bacheo";
            ViewBag.Area = "Mapa Interactivo";
            ViewBag.Message = "Mapa Interactivo de Obras - Bacheo";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult RastreoBacheo()
        {
            ViewBag.TipoUsuario = "Supervisor de Bacheo";
            ViewBag.Area = "Rastreo de Unidades";
            ViewBag.Message = "Sistema de Rastreo GPS - Unidades de Bacheo";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult DashboardBacheo()
        {
            ViewBag.TipoUsuario = "Analista de Bacheo";
            ViewBag.Area = "Panel de Control";
            ViewBag.Message = "Dashboard Estadístico - Bacheo";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult ReportesBacheo()
        {
            ViewBag.TipoUsuario = "Coordinador de Bacheo";
            ViewBag.Area = "Reportes Ciudadanos";
            ViewBag.Message = "Gestión de Reportes Ciudadanos - Bacheo";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult MaterialUtilizadoBacheo()
        {
            ViewBag.TipoUsuario = "Almacenista de Bacheo";
            ViewBag.Area = "Control de Inventario";
            ViewBag.Message = "Sistema de Control de Material - Bacheo";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult AsistenciaPersonalBacheo()
        {
            ViewBag.TipoUsuario = "Recursos Humanos Bacheo";
            ViewBag.Area = "Control de Asistencia";
            ViewBag.Message = "Sistema de Asistencia Personal - Bacheo";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== MÉTODOS ESPECÍFICOS DE RECOLECCIÓN - NUEVOS ========

        public IActionResult CapturaRecoleccion()
        {
            ViewBag.TipoUsuario = "Técnico de Recolección";
            ViewBag.Area = "Captura de Recolección";
            ViewBag.Message = "Sistema de Captura de Recolección de Residuos";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult AsistenciaPersonalRecoleccion()
        {
            ViewBag.TipoUsuario = "Recursos Humanos Recolección";
            ViewBag.Area = "Control de Asistencia";
            ViewBag.Message = "Sistema de Asistencia Personal - Recolección";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult GPSRecoleccion()
        {
            ViewBag.TipoUsuario = "Supervisor de Recolección";
            ViewBag.Area = "Rastreo GPS";
            ViewBag.Message = "Sistema de Rastreo GPS - Unidades de Recolección";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult MantenimientoUnidadesRecoleccion()
        {
            ViewBag.TipoUsuario = "Jefe de Mantenimiento";
            ViewBag.Area = "Mantenimiento de Unidades";
            ViewBag.Message = "Sistema de Mantenimiento - Camiones Recolectores";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult CapturaContenedores()
        {
            ViewBag.TipoUsuario = "Técnico de Contenedores";
            ViewBag.Area = "Captura de Contenedores";
            ViewBag.Message = "Sistema de Captura y Registro de Contenedores";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult GPSContenedores()
        {
            ViewBag.TipoUsuario = "Operador de Contenedores";
            ViewBag.Area = "GPS Contenedores";
            ViewBag.Message = "Sistema de Monitoreo GPS de Contenedores";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult MantenimientoContenedores()
        {
            ViewBag.TipoUsuario = "Técnico de Mantenimiento";
            ViewBag.Area = "Mantenimiento de Contenedores";
            ViewBag.Message = "Sistema de Mantenimiento de Contenedores";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult RutasRecoleccion()
        {
            ViewBag.TipoUsuario = "Coordinador de Rutas";
            ViewBag.Area = "Rutas de Recolección";
            ViewBag.Message = "Sistema de Planificación de Rutas";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult DashboardRecoleccion()
        {
            ViewBag.TipoUsuario = "Analista de Recolección";
            ViewBag.Area = "Dashboard de Recolección";
            ViewBag.Message = "Panel de Control - Recolección de Residuos";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult ReportesRecoleccion()
        {
            ViewBag.TipoUsuario = "Coordinador de Reportes";
            ViewBag.Area = "Reportes de Recolección";
            ViewBag.Message = "Sistema de Reportes - Recolección";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult ConfiguracionSistema()
        {
            ViewBag.TipoUsuario = "Administrador del Sistema";
            ViewBag.Area = "Configuración";
            ViewBag.Message = "Panel de Configuración del Sistema";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== MÉTODOS ESPECÍFICOS DE PIPAS - NUEVOS ========

        public IActionResult GPSPipas()
        {
            ViewBag.TipoUsuario = "Supervisor de Pipas";
            ViewBag.Area = "GPS Pipas";
            ViewBag.Message = "Sistema de Monitoreo GPS - Pipas de Agua";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult AsistenciaPersonalContenedores()
        {
            ViewBag.TipoUsuario = "Recursos Humanos Contenedores";
            ViewBag.Area = "Control de Asistencia";
            ViewBag.Message = "Sistema de Asistencia Personal - Contenedores";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== DASHBOARD GENERAL JEFE ADMINISTRATIVO - CORREGIDO ========

        public IActionResult GeneralJefeAdministrivo()
        {
            ViewBag.TipoUsuario = "Jefe Administrativo de Auxiliares";
            ViewBag.Area = "Panel de Control General";
            ViewBag.Message = "Dashboard General - Jefe Administrativo de Auxiliares";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== DASHBOARD GENERAL DIRECTOR SERVICIOS PRIMARIOS - NUEVO ========

        public IActionResult PanelGeneralDirectorServiciosPrimarios()
        {
            ViewBag.TipoUsuario = "Director de Servicios Primarios";
            ViewBag.Area = "Panel de Control General";
            ViewBag.Message = "Dashboard General - Director de Servicios Primarios";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== OTROS DASHBOARDS ========

        public IActionResult DashboardAdministradorLimpia()
        {
            ViewBag.TipoUsuario = "Administrador de Limpia";
            ViewBag.Area = "Servicios de Limpia";
            ViewBag.Message = "Dashboard Administrador de Limpia - Gestión de Recolección";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult DashboardAdministradorObras()
        {
            ViewBag.TipoUsuario = "Administrador de Obras";
            ViewBag.Area = "Obras Públicas";
            ViewBag.Message = "Dashboard Administrador de Obras - Gestión de Proyectos";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== HERRAMIENTAS GENERALES - NUEVOS MÉTODOS ========

        public IActionResult PanelGeneralJefeAdministracion()
        {
            ViewBag.TipoUsuario = "Jefe Administrativo";
            ViewBag.Area = "Panel General";
            ViewBag.Message = "Panel General de Jefe de Administración";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== ALMACÉN DE OFICIOS - NUEVO MÉTODO ========

        public IActionResult AlmacenOficios()
        {
            ViewBag.TipoUsuario = "Administrador de Almacén";
            ViewBag.Area = "Almacén de Oficios";
            ViewBag.Message = "Sistema de Gestión y Control de Oficios Administrativos";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== CONTINUACIÓN HERRAMIENTAS GENERALES ========

        public IActionResult RepositorioPlacas()
        {
            ViewBag.TipoUsuario = "Jefe Administrativo";
            ViewBag.Area = "Repositorio de Placas";
            ViewBag.Message = "Sistema de Consulta de Placas Vehiculares";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult ReportesGenerales()
        {
            ViewBag.TipoUsuario = "Jefe Administrativo";
            ViewBag.Area = "Reportes Generales";
            ViewBag.Message = "Sistema de Reportes Generales";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult ConfiguracionAuxiliares()
        {
            ViewBag.TipoUsuario = "Administrador del Sistema";
            ViewBag.Area = "Configuración de Auxiliares";
            ViewBag.Message = "Panel de Configuración de Auxiliares";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== PANELES DE DIRECTORES - NUEVOS ========

        public IActionResult InicioDirectorBacheo()
        {
            ViewBag.TipoUsuario = "Director de Bacheo";
            ViewBag.Area = "Panel Director de Bacheo";
            ViewBag.Message = "Panel de Control - Director de Bacheo";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult InicioDirectorAlumbrado()
        {
            ViewBag.TipoUsuario = "Director de Alumbrado Público";
            ViewBag.Area = "Panel Director de Alumbrado";
            ViewBag.Message = "Panel de Control - Director de Alumbrado Público";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult InicioDirectorRecoleccion()
        {
            ViewBag.TipoUsuario = "Director de Recolección";
            ViewBag.Area = "Panel Director de Recolección";
            ViewBag.Message = "Panel de Control - Director de Recolección";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== HERRAMIENTAS PARA DIRECTORES - NUEVOS ========

        public IActionResult AgendarDirectores()
        {
            ViewBag.TipoUsuario = "Director";
            ViewBag.Area = "Agenda de Directores";
            ViewBag.Message = "Sistema de Agenda para Directores";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult AgendaCitasProximas()
        {
            ViewBag.TipoUsuario = "Director";
            ViewBag.Area = "Agenda de Citas";
            ViewBag.Message = "Sistema de Gestión de Citas y Reuniones";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult ReportesSolicitados()
        {
            ViewBag.TipoUsuario = "Director";
            ViewBag.Area = "Reportes Solicitados";
            ViewBag.Message = "Sistema de Reportes Solicitados por Jefatura";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== MÉTODOS COMUNES ========

        // ======== PANEL TALLER MECÁNICO - NUEVO ========

        public IActionResult PanelTallerMecanico()
        {
            ViewBag.TipoUsuario = "Jefe de Taller Mecánico";
            ViewBag.Area = "Taller Mecánico";
            ViewBag.Message = "Panel de Control - Taller Mecánico y Mantenimiento Vehicular";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== SISTEMA DE CITAS TALLER MECÁNICO - NUEVOS ========

        public IActionResult AgendarCitasMantenimiento()
        {
            ViewBag.TipoUsuario = "Jefe de Taller Mecánico";
            ViewBag.Area = "Agenda de Citas";
            ViewBag.Message = "Sistema de Agendamiento de Citas - Taller Mecánico";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult RegistroCitasCompletadas()
        {
            ViewBag.TipoUsuario = "Jefe de Taller Mecánico";
            ViewBag.Area = "Historial de Citas";
            ViewBag.Message = "Registro de Citas Completadas - Taller Mecánico";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== PANELES DE ATENCIÓN - NUEVOS ========

        public IActionResult PanelAtencionServiciosPrimarios()
        {
            ViewBag.TipoUsuario = "Administrador de Atención Servicios Primarios";
            ViewBag.Area = "Atención a Servicios Primarios";
            ViewBag.Message = "Panel de Control - Atención a Servicios Primarios";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult PanelAtencionCiudadana()
        {
            ViewBag.TipoUsuario = "Administrador de Atención Ciudadana";
            ViewBag.Area = "Atención Ciudadana";
            ViewBag.Message = "Panel de Control - Atención Ciudadana";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== PANEL GENERAL ATENCIÓN CIUDADANA - NUEVO ========
        public IActionResult PanelGeneralAtencionCiudadana()
        {
            ViewBag.TipoUsuario = "Coordinador General de Atención Ciudadana";
            ViewBag.Area = "Panel General de Atención Ciudadana";
            ViewBag.Message = "Panel de Control General - Atención Ciudadana";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult PanelDirectoraGeneralAtencionCiudadana()
        {
            ViewBag.TipoUsuario = "Director de Atención Ciudadana";
            ViewBag.Area = "Panel General de Atención Ciudadana";
            ViewBag.Message = "Dashboard General - Director de Atención Ciudadana";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== HERRAMIENTAS DE REPORTERÍA SERVICIOS PRIMARIOS - NUEVOS ========

        public IActionResult ReportesGeneralesServiciosPrimarios()
        {
            ViewBag.TipoUsuario = "Administrador de Reportería";
            ViewBag.Area = "Reportes Generales";
            ViewBag.Message = "Sistema de Reportes Generales - Servicios Primarios";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult GeneradorReportesServiciosPrimarios()
        {
            ViewBag.TipoUsuario = "Administrador de Reportería";
            ViewBag.Area = "Generador de Reportes";
            ViewBag.Message = "Generador de Reportes Personalizados - Servicios Primarios";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult DashboardReportesServiciosPrimarios()
        {
            ViewBag.TipoUsuario = "Administrador de Reportería";
            ViewBag.Area = "Dashboard de Reportes";
            ViewBag.Message = "Panel de Control y Análisis de Reportes - Servicios Primarios";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== MÉTODOS PARA ATENCIÓN CIUDADANA - REPORTES ========

        public IActionResult AtencionCiudadanoGenerarReportes()
        {
            ViewBag.TipoUsuario = "Ciudadano";
            ViewBag.Area = "Crear Reportes";
            ViewBag.Message = "Sistema de Generación de Reportes Ciudadanos";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult AtencionCiudadanoTotalReportes()
        {
            ViewBag.TipoUsuario = "Ciudadano";
            ViewBag.Area = "Total de Reportes";
            ViewBag.Message = "Consulta de Todos los Reportes - Todos los Departamentos";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult AtencionGraficasReportes()
        {
            ViewBag.TipoUsuario = "Ciudadano";
            ViewBag.Area = "Gráficas de Reportes";
            ViewBag.Message = "Estadísticas y Gráficas de Reportes del Sistema";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult OperativoTaller()
        {
            ViewBag.TipoUsuario = "Operativo de Taller Mecánico";
            ViewBag.Area = "Taller Mecánico";
            ViewBag.Message = "Dashboard Operativo de Taller Mecánico - Gestión de Operaciones";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult PanelGeneralAlmacen()
        {
            ViewBag.TipoUsuario = "Administrador General de Almacén";
            ViewBag.Area = "Panel General de Almacén";
            ViewBag.Message = "Dashboard General - Administración de Almacén y Servicios Primarios";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }
        public IActionResult RegistroMantenimientoCitasDireccionGeneral()
        {
            ViewBag.TipoUsuario = "Director de Servicios Primarios";
            ViewBag.Area = "Registro de Mantenimiento";
            ViewBag.Message = "Registro Completo de Mantenimiento y Citas - Dirección General";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }
        public IActionResult RepositorioPlacasRecoleccion()
        {
            ViewBag.TipoUsuario = "Administrador de Recolección";
            ViewBag.Area = "Repositorio de Placas";
            ViewBag.Message = "Sistema de Consulta de Placas Vehiculares - Recolección";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== ENVÍO DE OFICIOS ALMACÉN A RECOLECCIÓN - NUEVO ========

        public IActionResult EnviarOficiosAlmacenRecoleccion()
        {
            ViewBag.TipoUsuario = "Administrador de Almacén";
            ViewBag.Area = "Envío de Oficios - Recolección";
            ViewBag.Message = "Sistema de Envío de Oficios - Almacén a Recolección de Residuos";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }
        // ======== AGENDAMIENTO DE CITAS MANTENIMIENTO RECOLECCIÓN - NUEVO ========

        public IActionResult AgendarCitasMantenimientoRecoleccion()
        {
            ViewBag.TipoUsuario = "Administrador de Recolección";
            ViewBag.Area = "Agenda de Mantenimiento";
            ViewBag.Message = "Sistema de Agendamiento de Citas de Mantenimiento - Recolección";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult EnviarOficiosAlmacenTaller()
        {
            ViewBag.TipoUsuario = "Administrador de Almacén";
            ViewBag.Area = "Envío de Oficios - Taller Mecánico";
            ViewBag.Message = "Sistema de Envío de Oficios - Almacén a Taller Mecánico";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult RepositorioPlacasAlumbrado()
        {
            ViewBag.TipoUsuario = "Administrador de Alumbrado";
            ViewBag.Area = "Repositorio de Placas";
            ViewBag.Message = "Sistema de Consulta de Placas Vehiculares - Alumbrado";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }
        public IActionResult EnviarOficiosAlmacenAlumbrado()
        {
            ViewBag.TipoUsuario = "Administrador de Almacén";
            ViewBag.Area = "Envío de Oficios - Alumbrado Público";
            ViewBag.Message = "Sistema de Envío de Oficios - Almacén a Alumbrado Público";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== NUEVOS MÉTODOS ESPECÍFICOS DE BACHEO ========

        public IActionResult RepositorioPlacasBacheo()
        {
            ViewBag.TipoUsuario = "Administrador de Bacheo";
            ViewBag.Area = "Repositorio de Unidades";
            ViewBag.Message = "Sistema de Consulta de Unidades de Bacheo - Repositorio Vehicular";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult EnviarOficiosAlmacenBacheo()
        {
            ViewBag.TipoUsuario = "Administrador de Bacheo";
            ViewBag.Area = "Oficios de Bacheo";
            ViewBag.Message = "Sistema de Generación de Oficios - Departamento de Bacheo";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }






        [HttpPost]
        public IActionResult CerrarSesionCiudadano()
        {
            TempData.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}