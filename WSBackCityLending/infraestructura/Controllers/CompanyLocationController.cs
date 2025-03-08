using Microsoft.AspNetCore.Mvc;
using WSBackCityLending.aplicacion.dao;
using WSBackCityLending.dominio.dto;
using WSBackCityLending.dominio.modelos;

namespace WSBackCityLending.infraestructura.Controllers
{
    [Route("lending/AppAdmin/Company/")]
    [ApiController]
    public class CompanyLocationController : Controller
    {
        private readonly CompanyLocationDaoImpl _servicio;
        public CompanyLocationController(CompanyLocationDaoImpl servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("GetAllCompany")]
        public List<CompanyLocation> obtDocuments()
        {
            return _servicio.returnAll();
        }

        [HttpPost("InsertCompany")]
        public Ansewer insertUsers(CompanyLocation datos)
        {
            return _servicio.addRecord(datos);
        }


        [HttpPost("UpdateCompany")]
        public Ansewer updatDocuments(CompanyLocation datos)
        {
            return _servicio.updateRecord(datos);
        }

        [HttpGet("DeleteCompany")]
        public Ansewer deleteUsers(int dato)
        {
            return _servicio.dropRecord(dato);
        }

        [HttpGet("FindCompanyByName")]
        public List<CompanyLocation> findUsersByName(CompanyLocation dato)
        {
            return _servicio.searchRecordByName(dato);
        }

        [HttpGet("FindCompanyById")]
        public List<CompanyLocation> findUsersById(int dato)
        {
            return _servicio.searchRecordById(dato);
        }
    }
}
