using WSBackCityLending.dominio.modelos;

namespace WSBackCityLending.infraestructura.interfases
{
    public interface ICityInter
    {
        List<City> returnAll();
        public Profile searchRecordById(int id);
        public String addRecord(City datos);
        public String updateRecord(City datos);

        public String dropRecord(int id);

        public City searchRecordByName(City datos);
    }
}
