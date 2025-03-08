using WSBackCityLending.dominio.modelos;

namespace WSBackCityLending.infraestructura.interfases
{
    public interface IProfileUserInter
    {


        List<UserProfile> returnAll();
        public UserProfile searchRecordById(int id);
        public String addRecord(UserProfile datos);
        public String updateRecord(UserProfile datos);

        public String dropRecord(int id);

        public UserProfile searchRecordByName(UserProfile datos);
    }
}
