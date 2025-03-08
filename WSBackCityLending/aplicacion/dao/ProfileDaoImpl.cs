using Npgsql;
using System.Data.SqlClient;
using WSBackCityLending.dominio.modelos;
using WSBackCityLending.infraestructura.interfases;
using WSBackCityLending.infraestructura.util;

namespace WSBackCityLending.aplicacion.dao
{
    public class ProfileDaoImpl: IProfileInter
    {
        private executeQueryBD _conectionString;
        

        public ProfileDaoImpl(executeQueryBD conectionString)
        {
            _conectionString = conectionString;
        }


        public List<Profile> returnAll()
        {
            List<Profile> list = new List<Profile>();

            string sql =
               "SELECT"
              + " perfil.idperfil,"
              + " perfil.descripcion,"
              + " perfil.estado"
              + " FROM perfil";

            var parametros = new Dictionary<string, object>();

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    Profile doct = new Profile(
                        dr.GetInt32(dr.GetOrdinal("idperfil")),
                        dr.GetString(dr.GetOrdinal("descripcion")),
                        dr.GetBoolean(dr.GetOrdinal("estado"))

                      );
                    list.Add(doct);
                }
            }
            return list;
        }

        public Ansewer addRecord(Profile datos)
        {
            Ansewer valdIncome;

            string sql = "insert into perfil (descripcion, estado)"
                       + "values (@descripcion, @estado)";

            var parametros = new Dictionary<string, object>
             {
               { "@descripcion", datos.descripcion },
               { "@estado", datos.estado },

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


        public Ansewer updateRecord(Profile datos)
        {
            Ansewer valdIncome;

            string sql = " UPDATE perfil SET "
                  + " descripcion = @descripcion, "
                  + " estado = @estado "
                  + " WHERE idperfil = @id";

            var parametros = new Dictionary<string, object>
            {
              { "@descripcion", datos.descripcion },
              { "@estado", datos.estado },
              { "@id", datos.idperfil }
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
            + " from perfil"
            + " where idperfil = @Datos";

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


        public List<Profile> searchRecordById(int id)
        {
            List<Profile> list = new List<Profile>();

            string sql =
            "SELECT"
           + " perfil.idperfil,"
           + " perfil.descripcion,"
           + " perfil.estado"
           + " FROM perfil"
           + " WHERE idperfil = @Datos";

            var parametros = new Dictionary<string, object>
             {
                { "@Datos", id }
             };

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    Profile doct = new Profile(
                        dr.GetInt32(dr.GetOrdinal("idperfil")),
                        dr.GetString(dr.GetOrdinal("descripcion")),
                        dr.GetBoolean(dr.GetOrdinal("estado"))

                      );
                    list.Add(doct);
                }
            }
            return list;
        }

        public List<Profile> searchRecordByName(Profile datos)
        {
            List<Profile> list = new List<Profile>();

            string sql =
             "SELECT"
            + " perfil.idperfil,"
            + " perfil.descripcion,"
            + " perfil.estado"
            + " FROM perfil"
            + " WHERE descripcion = @Datos";

            var parametros = new Dictionary<string, object>
             {
                { "@Datos", datos.descripcion }
             };

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    Profile doct = new Profile(
                        dr.GetInt32(dr.GetOrdinal("idperfil")),
                        dr.GetString(dr.GetOrdinal("descripcion")),
                        dr.GetBoolean(dr.GetOrdinal("estado"))

                      );
                    list.Add(doct);
                }
            }
            return list;
        }

      
    }
}
