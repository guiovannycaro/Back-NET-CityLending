using Npgsql;
using System.Data.SqlClient;
using WSBackCityLending.dominio.dto;
using WSBackCityLending.dominio.modelos;
using WSBackCityLending.infraestructura.interfases;
using WSBackCityLending.infraestructura.util;

namespace WSBackCityLending.aplicacion.dao
{
    public class ScheduleuserDaoImpl: ISheduleUserInter
    {
        private executeQueryBD _conectionString;
      

        public ScheduleuserDaoImpl(executeQueryBD conectionString)
        {
            _conectionString = conectionString;
        }


        public List<ScheduleUser> returnAll()
        {
            List<ScheduleUser> list = new List<ScheduleUser>();

            string sql =
               "SELECT"
               + " scheduleuser.sch_idcompanylocation,"
               + " scheduleuser.sch_iduser,"
               + " scheduleuser.sch_area,"
               + " scheduleuser.sch_initialtime,"
               + " scheduleuser.sch_finaltime"
               + " FROM scheduleuser";
             

            var parametros = new Dictionary<string, object>();

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    ScheduleUser doct = new ScheduleUser(
                        dr.GetInt32(dr.GetOrdinal("sch_idcompanylocation")),
                        dr.GetInt32(dr.GetOrdinal("sch_iduser")),
                        dr.GetInt32(dr.GetOrdinal("sch_area")),
                        dr.GetString(dr.GetOrdinal("sch_initialtime")),
                        dr.GetString(dr.GetOrdinal("sch_finaltime"))
                     
                      );
                    list.Add(doct);
                }
            }
            return list;
        }

        public Ansewer addRecord(ScheduleUser datos)
        {
            Ansewer valdIncome;

            string sql = " insert into scheduleuser"
                        + " (sch_idcompanylocation,sch_iduser,sch_area," 
                        + " sch_initialtime,sch_finaltime)"
                        + " values (@idcompany,@idusuario,@idarea,@tinicial,@tfinal)";


            var parametros = new Dictionary<string, object>
             {
               
                  { "@idcompany",datos.sch_idcompanylocation},
                { "@idusuario",datos.sch_iduser},
                 { "@idarea",datos.sch_area},
                { "@tinicial",datos.sch_initialtime},
                 { "@tfinal",datos.sch_finaltime}


              };

            bool rpt = _conectionString.executeUpdateBd(sql, parametros);

            if (rpt)
            {
                valdIncome = new Ansewer("200", "Informativo", "The Record was entered correctly");
            }
            else
            {
                valdIncome = new Ansewer("500", "Informativo", "The Record was not entered correctly");
            }

            return valdIncome;
        }


        public Ansewer updateRecord(ScheduleUser datos)
        {
            Ansewer valdIncome;

            string sql = " UPDATE scheduleuser SET "
                      + " sch_initialtime = @tinicial, "
                      + " sch_finaltime = @tfinal "
                      + " WHERE sch_idcompanylocation = @idcompany";

            var parametros = new Dictionary<string, object>
            {
                 { "@idcompany",datos.sch_idcompanylocation},
                { "@idusuario",datos.sch_iduser},
                 { "@idarea",datos.sch_area},
                { "@tinicial",datos.sch_initialtime},
                 { "@tfinal",datos.sch_finaltime}
            };

            bool rpt = _conectionString.executeUpdateBd(sql, parametros);

            if (rpt)
            {
                valdIncome = new Ansewer("200", "Informativo", "The Record was updated correctly");
            }
            else
            {
                valdIncome = new Ansewer("500", "Informativo", "The Record was not updated correctly");
            }
            return valdIncome;
        }

        public Ansewer dropRecord(int id)
        {
            Ansewer valdIncome;

            string sql = " Delete "
            + " from scheduleuser"
            + " where sch_idcompanylocation = @Datos";

            var parametros = new Dictionary<string, object>
            {
                { "@Datos", id }
            };


            bool rpt = _conectionString.executeUpdateBd(sql, parametros);


            if (rpt)
            {
                valdIncome = new Ansewer("200", "Informativo", "The Record was drop correctly");
            }
            else
            {
                valdIncome = new Ansewer("500", "Informativo", "The Record was not drop correctly");
            }
            return valdIncome;

        }


        public List<ScheduleUser> searchRecordById(int id)
        {
            List<ScheduleUser> list = new List<ScheduleUser>();

            string sql =
               "SELECT"
                    + " scheduleuser.sch_idcompanylocation,"
               + " scheduleuser.sch_iduser,"
               + " scheduleuser.sch_area,"
               + " scheduleuser.sch_initialtime,"
               + " scheduleuser.sch_finaltime"
               + " FROM scheduleuser"
            +" WHERE scheduleuser.sch_idcompanylocation = @Datos";

            var parametros = new Dictionary<string, object>
             {
                { "@Datos", id }
             };

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    ScheduleUser doct = new ScheduleUser(
                        dr.GetInt32(dr.GetOrdinal("sch_idcompanylocation")),
                        dr.GetInt32(dr.GetOrdinal("sch_iduser")),
                        dr.GetInt32(dr.GetOrdinal("sch_area")),
                        dr.GetString(dr.GetOrdinal("sch_initialtime")),
                        dr.GetString(dr.GetOrdinal("sch_finaltime"))

                      );
                    list.Add(doct);
                }
            }
            return list;
        }

        public List<ScheduleUser> searchRecordByUser(ScheduleUser datos)
        {
            List<ScheduleUser> list = new List<ScheduleUser>();

            string sql =
              "SELECT"
                   + " scheduleuser.sch_idcompanylocation,"
               + " scheduleuser.sch_iduser,"
               + " scheduleuser.sch_area,"
               + " scheduleuser.sch_initialtime,"
               + " scheduleuser.sch_finaltime"
              + " FROM scheduleuser"
              + " WHERE scheduleuser.sch_iduser = @Datos";

            var parametros = new Dictionary<string, object>
             {
                { "@Datos", datos.sch_iduser }
             };

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    ScheduleUser doct = new ScheduleUser(
                         dr.GetInt32(dr.GetOrdinal("sch_idcompanylocation")),
                         dr.GetInt32(dr.GetOrdinal("sch_iduser")),
                         dr.GetInt32(dr.GetOrdinal("sch_area")),
                         dr.GetString(dr.GetOrdinal("sch_initialtime")),
                         dr.GetString(dr.GetOrdinal("sch_finaltime"))

                       );
                    list.Add(doct);
                }
            }
            return list;
        }
    }
}
