
using WSBackCityLending.dominio.dto;
using WSBackCityLending.dominio.modelos;

namespace WSBackCityLending.infraestructura.interfases
{
    public interface ICompanyLocationInter
    {
        List<CompanyLocation> returnAll();
 
        public Ansewer addRecord(CompanyLocation datos);
        public Ansewer updateRecord(CompanyLocation datos);

        public Ansewer dropRecord(int id);


        public List<CompanyLocation> searchRecordById(int id);
        public List<CompanyLocation> searchRecordByName(CompanyLocation datos);
    }
}
