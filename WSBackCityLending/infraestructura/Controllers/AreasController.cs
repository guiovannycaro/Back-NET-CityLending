using Microsoft.AspNetCore.Mvc;
using WSBackCityLending.aplicacion.dao;
using WSBackCityLending.dominio.modelos;

namespace WSBackCityLending.infraestructura.Controllers
{
    [Route("lending/AppAdmin/Area/")]
    [ApiController]
    public class AreasController : Controller
    {
        private readonly AreasDaoImpl _servicio;
        public AreasController(AreasDaoImpl servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("GetAllAreas")]
        public List<Areas> obtDocuments()
        {
            return _servicio.returnAll();
        }

        [HttpPost("InsertAreas")]
        public Ansewer insertUsers(Areas datos)
        {
            return _servicio.addRecord(datos);
        }


        [HttpPost("UpdateAreas")]
        public Ansewer updatDocuments(Areas datos)
        {
            return _servicio.updateRecord(datos);
        }

        [HttpGet("DeleteAreas")]
        public Ansewer deleteUsers(int dato)
        {
            return _servicio.dropRecord(dato);
        }

        [HttpGet("FindAreasByName")]
        public List<Areas> findUsersByName(Areas dato)
        {
            return _servicio.searchRecordByName(dato);
        }

        [HttpGet("FindAreasById")]
        public List<Areas> findUsersById(int dato)
        {
            return _servicio.searchRecordById(dato);
        }
    }
}
