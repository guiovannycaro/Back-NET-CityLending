using WSBackCityLending.dominio.modelos;

namespace WSBackCityLending.infraestructura.interfases
{
    public interface IAreasInter
    {
        List<Areas> returnAll();
       
        public Ansewer addRecord(Areas datos);
        public Ansewer updateRecord(Areas datos);

        public Ansewer dropRecord(int id);


        public List<Areas> searchRecordById(int id);
        public List<Areas> searchRecordByName(Areas datos);
    }
}
