using Microsoft.AspNetCore.Mvc;
using WSBackCityLending.aplicacion.dao;
using WSBackCityLending.dominio.modelos;

namespace WSBackCityLending.infraestructura.Controllers
{

    [Route("lending/AppAdmin/Profile/")]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly ProfileDaoImpl _servicio;
        public ProfileController(ProfileDaoImpl servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("GetAllProfile")]
        public List<Profile> obtDocuments()
        {
            return _servicio.returnAll();
        }

        [HttpPost("InsertProfile")]
        public Ansewer insertUsers(Profile datos)
        {
            return _servicio.addRecord(datos);
        }


        [HttpPost("UpdateProfile")]
        public Ansewer updatDocuments(Profile datos)
        {
            return _servicio.updateRecord(datos);
        }

        [HttpGet("DeleteProfile")]
        public Ansewer deleteUsers(int dato)
        {
            return _servicio.dropRecord(dato);
        }

        [HttpGet("FindProfileByName")]
        public List<Profile> findUsersByName(Profile dato)
        {
            return _servicio.searchRecordByName(dato);
        }

        [HttpGet("FindProfileById")]
        public List<Profile> findUsersById(int dato)
        {
            return _servicio.searchRecordById(dato);
        }
    }
}
