
using WSBackCityLending.dominio.modelos;

namespace WSBackCityLending.infraestructura.interfases
{
    public interface ICountryInter
    {
        List<Country> returnAll();
        public Country searchRecordById(int id);
        public String addRecord(Country datos);
        public String updateRecord(Country datos);

        public String dropRecord(int id);

        public Country searchRecordByName(Country datos);
    }
}
