using Microsoft.AspNetCore.Mvc;
using WSBackCityLending.aplicacion.dao;
using WSBackCityLending.dominio.dto;
using WSBackCityLending.dominio.modelos;

namespace WSBackCityLending.infraestructura.seguridad
{
    [Route("lending/AppAdmin/Security/")]
    [ApiController]
    public class ServicioSeguridadController : Controller
    {
        private readonly ServicioSeguridadDaoImpl _servicio;

        public ServicioSeguridadController(ServicioSeguridadDaoImpl servicio)
        {
            _servicio = servicio;
        }

        [HttpPost("Autenticacion")]
        public Boolean autenticacion(SecurityUDtos u)
        {
            try
            {
                return _servicio.autenticacion(u);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"SQLException: {e.Message}");
                return false;
            }
        }

        [HttpGet("GetProfile")]
        public String getPerfil(String datos)
        {
            String mensaje;
            try
            {
                mensaje = _servicio.getRoles(datos);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"SQLException: {e.Message}");
                mensaje = "{\"codigo\":\"500\",\"mensaje\":\"Mensaje Informativo\",\"descripcion\":\"no fue se encontrario registros asociados \"}";
            }
            return mensaje;
        }

        [HttpGet("ObtNameUser")]
        public String obtenerNombreUsuario(String u)
        {
            String p = "";
            try
            {
                p = _servicio.getUserName(u);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"SQLException: {e.Message}");

            }
            return p;
        }

        [HttpGet("ChangePassword")]
        public Ansewer changePassword(ChangePasswordDto u)
        {
            Ansewer r = new Ansewer();
            try
            {
                r = _servicio.cambiarPassword(u);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"SQLException: {e.Message}");

            }
            return r;
        }



    }
}
