using Microsoft.AspNetCore.Mvc;
using WSBackCityLending.aplicacion.dao;
using WSBackCityLending.dominio.dto;
using WSBackCityLending.dominio.modelos;

namespace WSBackCityLending.infraestructura.Controllers
{

    [Route("lending/AppAdmin/Ubicaciones/")]
    [ApiController]
    public class ScheduleuserController : Controller
    {

        private readonly ScheduleuserDaoImpl _servicio;
        public ScheduleuserController(ScheduleuserDaoImpl servicio)
        {
            _servicio = servicio;
        }



        [HttpGet("GetAllLocations")]
        public List<ScheduleUser> obtUsers()
        {
            return _servicio.returnAll();
        }


        [HttpPost("InsertLocations")]
        public Ansewer InserLocations(ScheduleUser datos)
        {
            return _servicio.addRecord(datos);
        }

        [HttpPost("UpdateLocations")]
        public Ansewer updateLocations(ScheduleUser datos)
        {
            return _servicio.updateRecord(datos);
        }


        [HttpGet("DeleteLocations")]
        public Ansewer updateLocations(int id)
        {
            return _servicio.dropRecord(id);
        }


        [HttpGet("FindLocationsById")]
        public List<ScheduleUser> findLocationsById(int id)
        {
            return _servicio.searchRecordById(id);
        }
    }
}
