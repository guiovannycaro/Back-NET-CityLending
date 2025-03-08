using Microsoft.AspNetCore.Mvc;
using WSBackCityLending.aplicacion.dao;
using WSBackCityLending.dominio.dto;
using WSBackCityLending.dominio.modelos;

namespace WSBackCityLending.infraestructura.Controllers
{
    [Route("lending/AppAdmin/Users/")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UsersDaoImpl _servicio;
        public UsersController(UsersDaoImpl servicio)
        {
            _servicio = servicio;
        }



        [HttpGet("GetAllusers")]
        public List<Users> obtUsers()
        {
            return _servicio.returnAll();
        }

        [HttpPost("InsertUsers")]
        public Ansewer insertUsers(Users datos)
        {
            return _servicio.addRecord(datos);
        }

        [HttpPost("UpdateUsers")]
        public Ansewer updatUsers(Users datos)
        {
            return _servicio.updateRecords(datos);
        }

        [HttpGet("DeleteUsers")]
        public Ansewer deleteUsers(int dato)
        {
            return _servicio.deleteRecord(dato);
        }


        [HttpGet("FindUsersByName")]
        public Users findUsersByName(Users datos)
        {
            return _servicio.findRecordByName(datos);
        }

        [HttpGet("FindUsersById")]
        public Users findUsersById(int dato)
        {
            return _servicio.findRecordById(dato);
        }


        [HttpGet("GetRegistryProfile")]
        public List<ProfileUserDto> getRegistryProfile(string datos)
        {
            return _servicio.obtRegistryProfile(datos);
        }


       

    }
}
