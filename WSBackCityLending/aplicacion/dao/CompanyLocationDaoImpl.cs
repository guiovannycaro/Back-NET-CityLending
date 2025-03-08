using Npgsql;
using System.Data.SqlClient;
using WSBackCityLending.dominio.dto;
using WSBackCityLending.dominio.modelos;
using WSBackCityLending.infraestructura.interfases;
using WSBackCityLending.infraestructura.util;

namespace WSBackCityLending.aplicacion.dao
{
    public class CompanyLocationDaoImpl: ICompanyLocationInter
    {
        private executeQueryBD _conectionString;
      

        public CompanyLocationDaoImpl(executeQueryBD conectionString)
        {
            _conectionString = conectionString;
        }


        public List<CompanyLocation> returnAll()
        {
            List<CompanyLocation> list = new List<CompanyLocation>();

            string sql =
               "SELECT"
              + " companylocation.com_idcompany, "
              + " companylocation.com_name, "
              + " companylocation.com_adress, "
              + " companylocation.com_doctype, "
              + " companylocation.com_number, "
              + " companylocation.com_idciudad, "
              + " companylocation.com_status, "
              + " companylocation.com_AccessSchedule "
            
              + " FROM companylocation ";
             
            Console.WriteLine(sql);
            var parametros = new Dictionary<string, object>();

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    CompanyLocation doct = new CompanyLocation(
                        dr.GetInt32(dr.GetOrdinal("com_idcompany")),
                        dr.GetString(dr.GetOrdinal("com_name")),
                        dr.GetString(dr.GetOrdinal("com_adress")),
                        dr.GetInt32(dr.GetOrdinal("com_doctype")),
                        dr.GetInt32(dr.GetOrdinal("com_number")),
                        dr.GetInt32(dr.GetOrdinal("com_idciudad")),
                        dr.GetBoolean(dr.GetOrdinal("com_status")),
                        dr.GetBoolean(dr.GetOrdinal("com_AccessSchedule"))
                      );
                    list.Add(doct);
                }
            }
            return list;
        }

        public Ansewer addRecord(CompanyLocation datos)
        {
            Ansewer valdIncome;

            string sql = " insert into companylocation"
                        +  " (com_name,com_adress,com_doctype," 
                        +  " com_number,com_idciudad,com_status,com_accessschedule)"
                        + " values (@name,@adress,@doctype,@number,"
                        + "@idciudad,@status,@accessschedule)";

            var parametros = new Dictionary<string, object>
             {
                { "@name",datos.com_name},
                { "@adress",datos.com_adress},
                { "@doctype",datos.com_doctype},
                { "@number",datos.com_number},
                { "@idciudad",datos.com_idciudad},
                { "@status",datos.com_status},
                { "@accessschedule",datos.com_AccessSchedule  }
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


        public Ansewer updateRecord(CompanyLocation datos)
        {
            Ansewer valdIncome;

            string sql = " UPDATE companylocation SET "
                      + " com_name = @name, "
                      + " com_adress = @adress, "
                      + " com_doctype = @doctype, "
                      + " com_number = @number, "
                      + " com_idciudad = @idciudad, "
                      + " com_status = @status, "
                      + " com_accessschedule = @accessschedule "
                      + " WHERE com_idcompany = @id";

            var parametros = new Dictionary<string, object>
            {
                 { "@id",datos.com_idcompany},
                { "@name",datos.com_name},
                { "@adress",datos.com_adress},
                { "@doctype",datos.com_doctype},
                { "@number",datos.com_number},
                { "@idciudad",datos.com_idciudad},
                { "@status",datos.com_status},
                { "@accessschedule",datos.com_AccessSchedule  }
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
            + " from companylocation"
            + " where com_idcompany = @Datos";

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


        public List<CompanyLocation> searchRecordById(int id)
        {
            List<CompanyLocation> list = new List<CompanyLocation>();

            string sql = "SELECT"
                   + " companylocation.com_idcompany, "
              + " companylocation.com_name, "
              + " companylocation.com_adress, "
              + " companylocation.com_doctype, "
              + " companylocation.com_number, "
              + " companylocation.com_idciudad, "
              + " companylocation.com_status, "
              + " companylocation.com_AccessSchedule "
             + " FROM companylocation "
              + " WHERE com_idcompany = @Datos";

            var parametros = new Dictionary<string, object>
             {
                { "@Datos", id }
             };

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    CompanyLocation doct = new CompanyLocation(
                         dr.GetInt32(dr.GetOrdinal("com_idcompany")),
                        dr.GetString(dr.GetOrdinal("com_name")),
                        dr.GetString(dr.GetOrdinal("com_adress")),
                        dr.GetInt32(dr.GetOrdinal("com_doctype")),
                        dr.GetInt32(dr.GetOrdinal("com_number")),
                        dr.GetInt32(dr.GetOrdinal("com_idciudad")),
                        dr.GetBoolean(dr.GetOrdinal("com_status")),
                        dr.GetBoolean(dr.GetOrdinal("com_AccessSchedule"))

                      );
                    list.Add(doct);
                }
            }
            return list;
        }

        public List<CompanyLocation> searchRecordByName(CompanyLocation datos)
        {
            List<CompanyLocation> list = new List<CompanyLocation>();

            string sql =
               "SELECT"
                  + " companylocation.com_idcompany, "
              + " companylocation.com_name, "
              + " companylocation.com_adress, "
              + " companylocation.com_doctype, "
              + " companylocation.com_number, "
              + " companylocation.com_idciudad, "
              + " companylocation.com_status, "
              + " companylocation.com_AccessSchedule "
              + " FROM companylocation "
              + " WHERE com_name = @Datos";

            var parametros = new Dictionary<string, object>
             {
                { "@Datos", datos.com_name }
             };

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    CompanyLocation doct = new CompanyLocation(
                         dr.GetInt32(dr.GetOrdinal("com_idcompany")),
                        dr.GetString(dr.GetOrdinal("com_name")),
                        dr.GetString(dr.GetOrdinal("com_adress")),
                        dr.GetInt32(dr.GetOrdinal("com_doctype")),
                        dr.GetInt32(dr.GetOrdinal("com_number")),
                        dr.GetInt32(dr.GetOrdinal("com_idciudad")),
                        dr.GetBoolean(dr.GetOrdinal("com_status")),
                        dr.GetBoolean(dr.GetOrdinal("com_AccessSchedule"))
                 

                      );
                    list.Add(doct);
                }
            }
            return list;
        }

    }
}
