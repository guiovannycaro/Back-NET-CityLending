namespace WSBackCityLending.dominio.modelos
{
    public class ScheduleUser
    {
        public int sch_idcompanylocation { get; set; }
        public int sch_iduser { get; set; }
        public int sch_area { get; set; }
        public string sch_initialtime { get; set; }
        public string sch_finaltime { get; set; }

        public ScheduleUser() { }

       
        public ScheduleUser(
            int sch_idcompanylocation,
            int sch_iduser,
            int sch_area,
            string sch_initialtime,
            string sch_finaltime
        )
        {
            this.sch_idcompanylocation = sch_idcompanylocation;
            this.sch_iduser = sch_iduser;
            this.sch_area = sch_area;
            this.sch_initialtime = sch_initialtime;
            this.sch_finaltime = sch_finaltime;
        }
    }
}