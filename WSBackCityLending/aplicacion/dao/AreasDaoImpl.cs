using Npgsql;
using System.Data;
using System.Data.SqlClient;
using WSBackCityLending.dominio.modelos;
using WSBackCityLending.infraestructura.interfases;
using WSBackCityLending.infraestructura.util;

namespace WSBackCityLending.aplicacion.dao
{
    public class AreasDaoImpl : IAreasInter
    {
        private executeQueryBD _conectionString;
       

        public AreasDaoImpl(executeQueryBD conectionString)
        {
            _conectionString = conectionString;
        }


        public List<Areas> returnAll()
        {
            List<Areas> list = new List<Areas>();

            string sql =
               "SELECT"
              + " areas.are_idarea, "
              + " areas.are_description, "
              + " areas.com_status "
              + " FROM areas ";

            

            var parametros = new Dictionary<string, object>();

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                  
                    Areas doct = new Areas(
                        dr.GetInt32(dr.GetOrdinal("are_idarea")),
                        dr.GetString(dr.GetOrdinal("are_description")),
                        dr.GetBoolean(dr.GetOrdinal("com_status"))
                        
                      );
                    list.Add(doct);
                }
            }
            return list;
        }

        public Ansewer addRecord(Areas datos)
        {
            Ansewer valdIncome;

            string sql = " insert into areas"
                        + " (are_description,com_status) "
                        + " values (@descripcion,@status) ";

            Console.WriteLine(datos);
            var parametros = new Dictionary<string, object>
             {
                { "@descripcion",datos.are_description},
                { "@status",datos.com_status }
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


        public Ansewer updateRecord(Areas datos)
        {
            Ansewer valdIncome;

            string sql = " UPDATE areas SET "
                      + " are_description = @descripcion, "
                      + " com_status = @status "
                      + " WHERE are_idarea = @id";

            var parametros = new Dictionary<string, object>
            {
                 { "@id",datos.are_idarea},
               { "@descripcion",datos.are_description},
                { "@status",datos.com_status }
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
            + " from areas"
            + " where are_idarea = @Datos";
            Console.WriteLine(sql);
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


        public List<Areas> searchRecordById(int id)
        {
            List<Areas> list = new List<Areas>();

            string sql =
              "SELECT"
             + " areas.are_idarea, "
             + " areas.are_description, "
             + " areas.com_status "
             + " FROM areas "
             + " WHERE are_idarea = @Datos";

            var parametros = new Dictionary<string, object>
             {
                { "@Datos", id }
             };

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    Areas doct = new Areas(
                           dr.GetInt32(dr.GetOrdinal("are_idarea")),
                        dr.GetString(dr.GetOrdinal("are_description")),
                        dr.GetBoolean(dr.GetOrdinal("com_status"))

                      );
                    list.Add(doct);
                }
            }
            return list;
        }

        public List<Areas> searchRecordByName(Areas datos)
        {
            List<Areas> list = new List<Areas>();

            string sql =
              "SELECT"
             + " areas.are_idarea, "
             + " areas.are_description, "
             + " areas.com_status "
             + " FROM areas "
             + " WHERE are_description = @Datos";

            var parametros = new Dictionary<string, object>
             {
                { "@Datos", datos.are_description }
             };

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    Areas doct = new Areas(
                       dr.GetInt32(dr.GetOrdinal("are_idarea")),
                        dr.GetString(dr.GetOrdinal("are_description")),
                        dr.GetBoolean(dr.GetOrdinal("com_status"))

                      );
                    list.Add(doct);
                }
            }
            return list;
        }

    }
}
