
using WSBackCityLending.dominio.dto;
using WSBackCityLending.dominio.modelos;

namespace WSBackCityLending.infraestructura.interfases
{
    public interface ICompanyAreaInter
    {
        List<CompanyAreasDto> returnAll();
       
        public Ansewer addRecord(CompanyAreasDto datos);
        public Ansewer updateRecord(CompanyAreasDto datos);

        public Ansewer dropRecord(int id);

        public List<CompanyAreasDto> searchRecordById(int id);

        public List<CompanyAreasDto> searchRecordByName(CompanyAreasDto datos);
    }
}
