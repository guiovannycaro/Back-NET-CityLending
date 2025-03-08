using WSBackCityLending.dominio.dto;
using WSBackCityLending.dominio.modelos;

namespace WSBackCityLending.infraestructura.interfases
{
    public interface ISheduleUserInter
    {


        List<ScheduleUser> returnAll();
      
        public Ansewer addRecord(ScheduleUser datos);
        public Ansewer updateRecord(ScheduleUser datos);

        public Ansewer dropRecord(int id);

        public List<ScheduleUser> searchRecordById(int id);
        public List<ScheduleUser> searchRecordByUser(ScheduleUser datos);
    }
}
