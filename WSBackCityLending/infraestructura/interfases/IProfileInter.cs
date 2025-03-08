using WSBackCityLending.dominio.modelos;

namespace WSBackCityLending.infraestructura.interfases
{
    public interface IProfileInter
    {

        List<Profile> returnAll();
     
        public Ansewer addRecord(Profile datos);
        public Ansewer updateRecord(Profile datos);

        public Ansewer dropRecord(int id);

        public List<Profile> searchRecordById(int id);

        public List<Profile> searchRecordByName(Profile datos);
    }
}
