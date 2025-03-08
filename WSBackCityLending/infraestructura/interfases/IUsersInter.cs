using WSBackCityLending.dominio.dto;
using WSBackCityLending.dominio.modelos;



namespace WSBackCityLending.infraestructura.interfases
{
    public interface IUsersInter
    {

        List<Users> returnAll();
        public Users searchRecordById(int id);
        public Ansewer addRecord(Users datos);
        public Ansewer updateRecords(Users datos);
        public Ansewer deleteRecord(int id);
        public List<Users> searchRecordName(Users datos);
        public List<ProfileUserDto> obtRegistryProfile(String datos);
    }
}
