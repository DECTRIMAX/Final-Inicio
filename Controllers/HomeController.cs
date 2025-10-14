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
                    ViewBag.Message = "Dashboard de Administrador - Pr�ximamente";
                    return View("DashboardTemp");
                case "Empleado":
                    ViewBag.Message = "Dashboard de Empleado - Pr�ximamente";
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
            ViewBag.Message = "Dashboard Operativo - Sistema de Gesti�n Municipal";
            return View("DashboardEmpleado");
        }

        // ======== DASHBOARDS OPERATIVOS ESPEC�FICOS ========

        public IActionResult OperativoAlumbrado()
        {
            ViewBag.TipoUsuario = "Operativo de Alumbrado";
            ViewBag.Area = "Alumbrado P�blico";
            ViewBag.Message = "Dashboard Operativo de Alumbrado - Gesti�n de Operaciones";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult OperativoBacheo()
        {
            ViewBag.TipoUsuario = "Operativo de Bacheo";
            ViewBag.Area = "Bacheo y Pavimentaci�n";
            ViewBag.Message = "Dashboard Operativo de Bacheo - Gesti�n de Operaciones";
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
            ViewBag.TipoUsuario = "Jefe de Administraci�n";
            ViewBag.Message = "Dashboard Jefe de Administraci�n - Supervisi�n General";
            return View("DashboardTemp");
        }

        public IActionResult DashboardDirector()
        {
            ViewBag.TipoUsuario = "Director";
            ViewBag.Message = "Dashboard Director - Panel Ejecutivo";
            return View("DashboardTemp");
        }

        // ======== DASHBOARDS ESPEC�FICOS POR �REA ========

        public IActionResult DashboardAdministradorAlumbrado()
        {
            ViewBag.TipoUsuario = "Administrador de Alumbrado";
            ViewBag.Area = "Alumbrado P�blico";
            ViewBag.Message = "Dashboard Administrador de Alumbrado - Gesti�n de Luminarias";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult DashboardAdministradorBacheo()
        {
            ViewBag.TipoUsuario = "Administrador de Bacheo";
            ViewBag.Area = "Bacheo y Pavimentaci�n";
            ViewBag.Message = "Dashboard Administrador de Bacheo - Gesti�n de Pavimentaci�n";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== DASHBOARD DE RECOLECCI�N - NUEVO ========
        public IActionResult DashboardAdministradorRecoleccion()
        {
            ViewBag.TipoUsuario = "Administrador de Recolecci�n";
            ViewBag.Area = "Recolecci�n de Residuos";
            ViewBag.Message = "Dashboard Administrador de Recolecci�n - Gesti�n Integral";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult DashboardEmpleadosAlumbrado()
        {
            ViewBag.TipoUsuario = "Empleado de Alumbrado";
            ViewBag.Area = "Alumbrado P�blico";
            ViewBag.Message = "Dashboard Empleados de Alumbrado - Operaciones de Campo";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult DashboardEmpleadosBacheo()
        {
            ViewBag.TipoUsuario = "Empleado de Bacheo";
            ViewBag.Area = "Bacheo y Pavimentaci�n";
            ViewBag.Message = "Dashboard Empleados de Bacheo - Operaciones de Campo";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== SISTEMA DE ALMAC�N - NUEVO ========

        public IActionResult InicioAlmacen()
        {
            ViewBag.TipoUsuario = "Administrador de Almac�n";
            ViewBag.Area = "Almac�n de Servicios Primarios";
            ViewBag.Message = "Sistema de Gesti�n de Oficios y Almac�n";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult AlmacenRegistros()
        {
            ViewBag.TipoUsuario = "Administrador de Almac�n";
            ViewBag.Area = "Almac�n de Registros";
            ViewBag.Message = "Archivo de Oficios Completados";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult Adquisiciones()
        {
            ViewBag.TipoUsuario = "Administrador de Adquisiciones";
            ViewBag.Area = "Gesti�n de Adquisiciones";
            ViewBag.Message = "Sistema de Compras y Pedidos";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult ReportesMateriales()
        {
            ViewBag.TipoUsuario = "Administrador de Almac�n";
            ViewBag.Area = "Reportes de Materiales";
            ViewBag.Message = "Gesti�n de Entrega de Materiales a Departamentos";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // Obtener el departamento del query string si existe
            var dept = Request.Query["dept"].ToString();
            if (!string.IsNullOrEmpty(dept))
            {
                ViewBag.Departamento = dept switch
                {
                    "alumbrado" => "Alumbrado P�blico",
                    "bacheo" => "Bacheo",
                    "recoleccion" => "Recolecci�n de Basura",
                    _ => "Departamento"
                };
            }

            return View();
        }

        public IActionResult AlumbradoSolicitudes()
        {
            ViewBag.TipoUsuario = "Alumbrado P�blico";
            ViewBag.Area = "Solicitudes de Material";
            ViewBag.Message = "Solicitudes de Material - Alumbrado P�blico";
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
            ViewBag.TipoUsuario = "Recolecci�n de Basura";
            ViewBag.Area = "Solicitudes de Material";
            ViewBag.Message = "Solicitudes de Material - Recolecci�n de Basura";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== M�TODOS ESPEC�FICOS DE ALUMBRADO P�BLICO ========

        public IActionResult ProgramacionAlumbrado()
        {
            ViewBag.TipoUsuario = "Administrador de Alumbrado";
            ViewBag.Area = "Programaci�n de Horarios";
            ViewBag.Message = "Sistema de Programaci�n de Alumbrado P�blico";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult CapturaAlumbrado()
        {
            ViewBag.TipoUsuario = "T�cnico de Alumbrado";
            ViewBag.Area = "Captura de Incidencias";
            ViewBag.Message = "Sistema de Captura de Reportes de Alumbrado P�blico";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult MapaAlumbrado()
        {
            ViewBag.TipoUsuario = "Operador de Alumbrado";
            ViewBag.Area = "Mapa Interactivo";
            ViewBag.Message = "Mapa Interactivo de Luminarias - Alumbrado P�blico";
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
            ViewBag.Message = "Dashboard Estad�stico - Alumbrado P�blico";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult ReportesAlumbrado()
        {
            ViewBag.TipoUsuario = "Coordinador de Alumbrado";
            ViewBag.Area = "Reportes Ciudadanos";
            ViewBag.Message = "Gesti�n de Reportes Ciudadanos - Alumbrado P�blico";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult MaterialUtilizadoAlumbrado()
        {
            ViewBag.TipoUsuario = "Almacenista de Alumbrado";
            ViewBag.Area = "Control de Inventario";
            ViewBag.Message = "Sistema de Control de Material - Alumbrado P�blico";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult AsistenciaPersonalAlumbrado()
        {
            ViewBag.TipoUsuario = "Recursos Humanos Alumbrado";
            ViewBag.Area = "Control de Asistencia";
            ViewBag.Message = "Sistema de Asistencia Personal - Alumbrado P�blico";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== M�TODOS ESPEC�FICOS DE BACHEO ========

        public IActionResult ProgramacionBacheo()
        {
            ViewBag.TipoUsuario = "Administrador de Bacheo";
            ViewBag.Area = "Programaci�n de Obras";
            ViewBag.Message = "Sistema de Programaci�n de Obras de Bacheo";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult CapturaBacheo()
        {
            ViewBag.TipoUsuario = "T�cnico de Bacheo";
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
            ViewBag.Message = "Dashboard Estad�stico - Bacheo";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult ReportesBacheo()
        {
            ViewBag.TipoUsuario = "Coordinador de Bacheo";
            ViewBag.Area = "Reportes Ciudadanos";
            ViewBag.Message = "Gesti�n de Reportes Ciudadanos - Bacheo";
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

        // ======== M�TODOS ESPEC�FICOS DE RECOLECCI�N - NUEVOS ========

        public IActionResult CapturaRecoleccion()
        {
            ViewBag.TipoUsuario = "T�cnico de Recolecci�n";
            ViewBag.Area = "Captura de Recolecci�n";
            ViewBag.Message = "Sistema de Captura de Recolecci�n de Residuos";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult AsistenciaPersonalRecoleccion()
        {
            ViewBag.TipoUsuario = "Recursos Humanos Recolecci�n";
            ViewBag.Area = "Control de Asistencia";
            ViewBag.Message = "Sistema de Asistencia Personal - Recolecci�n";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult GPSRecoleccion()
        {
            ViewBag.TipoUsuario = "Supervisor de Recolecci�n";
            ViewBag.Area = "Rastreo GPS";
            ViewBag.Message = "Sistema de Rastreo GPS - Unidades de Recolecci�n";
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
            ViewBag.TipoUsuario = "T�cnico de Contenedores";
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
            ViewBag.TipoUsuario = "T�cnico de Mantenimiento";
            ViewBag.Area = "Mantenimiento de Contenedores";
            ViewBag.Message = "Sistema de Mantenimiento de Contenedores";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult RutasRecoleccion()
        {
            ViewBag.TipoUsuario = "Coordinador de Rutas";
            ViewBag.Area = "Rutas de Recolecci�n";
            ViewBag.Message = "Sistema de Planificaci�n de Rutas";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult DashboardRecoleccion()
        {
            ViewBag.TipoUsuario = "Analista de Recolecci�n";
            ViewBag.Area = "Dashboard de Recolecci�n";
            ViewBag.Message = "Panel de Control - Recolecci�n de Residuos";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult ReportesRecoleccion()
        {
            ViewBag.TipoUsuario = "Coordinador de Reportes";
            ViewBag.Area = "Reportes de Recolecci�n";
            ViewBag.Message = "Sistema de Reportes - Recolecci�n";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult ConfiguracionSistema()
        {
            ViewBag.TipoUsuario = "Administrador del Sistema";
            ViewBag.Area = "Configuraci�n";
            ViewBag.Message = "Panel de Configuraci�n del Sistema";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== M�TODOS ESPEC�FICOS DE PIPAS - NUEVOS ========

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
            ViewBag.Message = "Dashboard Administrador de Limpia - Gesti�n de Recolecci�n";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult DashboardAdministradorObras()
        {
            ViewBag.TipoUsuario = "Administrador de Obras";
            ViewBag.Area = "Obras P�blicas";
            ViewBag.Message = "Dashboard Administrador de Obras - Gesti�n de Proyectos";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== HERRAMIENTAS GENERALES - NUEVOS M�TODOS ========

        public IActionResult PanelGeneralJefeAdministracion()
        {
            ViewBag.TipoUsuario = "Jefe Administrativo";
            ViewBag.Area = "Panel General";
            ViewBag.Message = "Panel General de Jefe de Administraci�n";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== ALMAC�N DE OFICIOS - NUEVO M�TODO ========

        public IActionResult AlmacenOficios()
        {
            ViewBag.TipoUsuario = "Administrador de Almac�n";
            ViewBag.Area = "Almac�n de Oficios";
            ViewBag.Message = "Sistema de Gesti�n y Control de Oficios Administrativos";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== CONTINUACI�N HERRAMIENTAS GENERALES ========

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
            ViewBag.Area = "Configuraci�n de Auxiliares";
            ViewBag.Message = "Panel de Configuraci�n de Auxiliares";
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
            ViewBag.TipoUsuario = "Director de Alumbrado P�blico";
            ViewBag.Area = "Panel Director de Alumbrado";
            ViewBag.Message = "Panel de Control - Director de Alumbrado P�blico";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult InicioDirectorRecoleccion()
        {
            ViewBag.TipoUsuario = "Director de Recolecci�n";
            ViewBag.Area = "Panel Director de Recolecci�n";
            ViewBag.Message = "Panel de Control - Director de Recolecci�n";
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
            ViewBag.Message = "Sistema de Gesti�n de Citas y Reuniones";
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

        // ======== M�TODOS COMUNES ========

        // ======== PANEL TALLER MEC�NICO - NUEVO ========

        public IActionResult PanelTallerMecanico()
        {
            ViewBag.TipoUsuario = "Jefe de Taller Mec�nico";
            ViewBag.Area = "Taller Mec�nico";
            ViewBag.Message = "Panel de Control - Taller Mec�nico y Mantenimiento Vehicular";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== SISTEMA DE CITAS TALLER MEC�NICO - NUEVOS ========

        public IActionResult AgendarCitasMantenimiento()
        {
            ViewBag.TipoUsuario = "Jefe de Taller Mec�nico";
            ViewBag.Area = "Agenda de Citas";
            ViewBag.Message = "Sistema de Agendamiento de Citas - Taller Mec�nico";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult RegistroCitasCompletadas()
        {
            ViewBag.TipoUsuario = "Jefe de Taller Mec�nico";
            ViewBag.Area = "Historial de Citas";
            ViewBag.Message = "Registro de Citas Completadas - Taller Mec�nico";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== PANELES DE ATENCI�N - NUEVOS ========

        public IActionResult PanelAtencionServiciosPrimarios()
        {
            ViewBag.TipoUsuario = "Administrador de Atenci�n Servicios Primarios";
            ViewBag.Area = "Atenci�n a Servicios Primarios";
            ViewBag.Message = "Panel de Control - Atenci�n a Servicios Primarios";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult PanelAtencionCiudadana()
        {
            ViewBag.TipoUsuario = "Administrador de Atenci�n Ciudadana";
            ViewBag.Area = "Atenci�n Ciudadana";
            ViewBag.Message = "Panel de Control - Atenci�n Ciudadana";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== PANEL GENERAL ATENCI�N CIUDADANA - NUEVO ========
        public IActionResult PanelGeneralAtencionCiudadana()
        {
            ViewBag.TipoUsuario = "Coordinador General de Atenci�n Ciudadana";
            ViewBag.Area = "Panel General de Atenci�n Ciudadana";
            ViewBag.Message = "Panel de Control General - Atenci�n Ciudadana";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult PanelDirectoraGeneralAtencionCiudadana()
        {
            ViewBag.TipoUsuario = "Director de Atenci�n Ciudadana";
            ViewBag.Area = "Panel General de Atenci�n Ciudadana";
            ViewBag.Message = "Dashboard General - Director de Atenci�n Ciudadana";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== HERRAMIENTAS DE REPORTER�A SERVICIOS PRIMARIOS - NUEVOS ========

        public IActionResult ReportesGeneralesServiciosPrimarios()
        {
            ViewBag.TipoUsuario = "Administrador de Reporter�a";
            ViewBag.Area = "Reportes Generales";
            ViewBag.Message = "Sistema de Reportes Generales - Servicios Primarios";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult GeneradorReportesServiciosPrimarios()
        {
            ViewBag.TipoUsuario = "Administrador de Reporter�a";
            ViewBag.Area = "Generador de Reportes";
            ViewBag.Message = "Generador de Reportes Personalizados - Servicios Primarios";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult DashboardReportesServiciosPrimarios()
        {
            ViewBag.TipoUsuario = "Administrador de Reporter�a";
            ViewBag.Area = "Dashboard de Reportes";
            ViewBag.Message = "Panel de Control y An�lisis de Reportes - Servicios Primarios";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== M�TODOS PARA ATENCI�N CIUDADANA - REPORTES ========

        public IActionResult AtencionCiudadanoGenerarReportes()
        {
            ViewBag.TipoUsuario = "Ciudadano";
            ViewBag.Area = "Crear Reportes";
            ViewBag.Message = "Sistema de Generaci�n de Reportes Ciudadanos";
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
            ViewBag.Area = "Gr�ficas de Reportes";
            ViewBag.Message = "Estad�sticas y Gr�ficas de Reportes del Sistema";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult OperativoTaller()
        {
            ViewBag.TipoUsuario = "Operativo de Taller Mec�nico";
            ViewBag.Area = "Taller Mec�nico";
            ViewBag.Message = "Dashboard Operativo de Taller Mec�nico - Gesti�n de Operaciones";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult PanelGeneralAlmacen()
        {
            ViewBag.TipoUsuario = "Administrador General de Almac�n";
            ViewBag.Area = "Panel General de Almac�n";
            ViewBag.Message = "Dashboard General - Administraci�n de Almac�n y Servicios Primarios";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }
        public IActionResult RegistroMantenimientoCitasDireccionGeneral()
        {
            ViewBag.TipoUsuario = "Director de Servicios Primarios";
            ViewBag.Area = "Registro de Mantenimiento";
            ViewBag.Message = "Registro Completo de Mantenimiento y Citas - Direcci�n General";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }
        public IActionResult RepositorioPlacasRecoleccion()
        {
            ViewBag.TipoUsuario = "Administrador de Recolecci�n";
            ViewBag.Area = "Repositorio de Placas";
            ViewBag.Message = "Sistema de Consulta de Placas Vehiculares - Recolecci�n";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== ENV�O DE OFICIOS ALMAC�N A RECOLECCI�N - NUEVO ========

        public IActionResult EnviarOficiosAlmacenRecoleccion()
        {
            ViewBag.TipoUsuario = "Administrador de Almac�n";
            ViewBag.Area = "Env�o de Oficios - Recolecci�n";
            ViewBag.Message = "Sistema de Env�o de Oficios - Almac�n a Recolecci�n de Residuos";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }
        // ======== AGENDAMIENTO DE CITAS MANTENIMIENTO RECOLECCI�N - NUEVO ========

        public IActionResult AgendarCitasMantenimientoRecoleccion()
        {
            ViewBag.TipoUsuario = "Administrador de Recolecci�n";
            ViewBag.Area = "Agenda de Mantenimiento";
            ViewBag.Message = "Sistema de Agendamiento de Citas de Mantenimiento - Recolecci�n";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        public IActionResult EnviarOficiosAlmacenTaller()
        {
            ViewBag.TipoUsuario = "Administrador de Almac�n";
            ViewBag.Area = "Env�o de Oficios - Taller Mec�nico";
            ViewBag.Message = "Sistema de Env�o de Oficios - Almac�n a Taller Mec�nico";
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
            ViewBag.TipoUsuario = "Administrador de Almac�n";
            ViewBag.Area = "Env�o de Oficios - Alumbrado P�blico";
            ViewBag.Message = "Sistema de Env�o de Oficios - Almac�n a Alumbrado P�blico";
            ViewBag.FechaAcceso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return View();
        }

        // ======== NUEVOS M�TODOS ESPEC�FICOS DE BACHEO ========

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
            ViewBag.Message = "Sistema de Generaci�n de Oficios - Departamento de Bacheo";
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