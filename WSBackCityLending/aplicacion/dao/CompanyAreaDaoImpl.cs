using Npgsql;
using System.Data.SqlClient;
using WSBackCityLending.dominio.dto;
using WSBackCityLending.dominio.modelos;
using WSBackCityLending.infraestructura.interfases;
using WSBackCityLending.infraestructura.util;

namespace WSBackCityLending.aplicacion.dao
{
    public class CompanyAreaDaoImpl: ICompanyAreaInter
    {
        private executeQueryBD _conectionString;
     

        public CompanyAreaDaoImpl(executeQueryBD conectionString)
        {
            _conectionString = conectionString;
        }


        public List<CompanyAreasDto> returnAll()
        {
            List<CompanyAreasDto> list = new List<CompanyAreasDto>();

            string sql =
               "SELECT"
              + " companylocation.com_idcompany, "
              + " companylocation.com_name, "
              + " companylocation.com_adress, "
              + " companylocation.com_doctype, "
              + " companylocation.com_number, "
              + " companylocation.com_idciudad, "
              + " companylocation.com_status, "
              + " companylocation.com_accessschedule, "
              + " areas.are_idarea, "
              + " areas.are_description, "
              + " areas.com_status "
              + " FROM companyareas "
              + " JOIN companylocation ON companyareas.ca_idcompany = companylocation.com_idcompany"
              + " JOIN areas  ON companyareas.ca_idarea = areas.are_idarea";

            var parametros = new Dictionary<string, object>();

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    CompanyAreasDto doct = new CompanyAreasDto(
                        dr.GetInt32(dr.GetOrdinal("com_idcompany")),
                        dr.GetString(dr.GetOrdinal("com_name")),
                        dr.GetString(dr.GetOrdinal("com_adress")),
                        dr.GetInt32(dr.GetOrdinal("com_doctype")),
                        dr.GetString(dr.GetOrdinal("com_number")),
                        dr.GetInt32(dr.GetOrdinal("com_idciudad")),
                        dr.GetBoolean(dr.GetOrdinal("com_status")),
                        dr.GetString(dr.GetOrdinal("com_accessschedule")),
                        dr.GetInt32(dr.GetOrdinal("are_idarea")),
                        dr.GetString(dr.GetOrdinal("are_description")),
                        dr.GetString(dr.GetOrdinal("com_status"))
                      );
                    list.Add(doct);
                }
            }
            return list;
        }

        public Ansewer addRecord(CompanyAreasDto datos)
        {
            Ansewer valdIncome;

            string sql = " insert into companyareas"
                        + " (ca_idcompany,ca_idarea)"
                        + " values (@idcompany,@idarea)";
                 

            var parametros = new Dictionary<string, object>
             {
                { "@idcompany",datos.com_idcompany},
                { "@idarea",datos.are_idarea},
            
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


        public Ansewer updateRecord(CompanyAreasDto datos)
        {
            Ansewer valdIncome;

            string sql = " UPDATE companyareas SET "
                      + " ca_idarea = @idarea "
                      + " WHERE com_idcompany = @idcompany";

            var parametros = new Dictionary<string, object>
            {
                 { "@idcompany",datos.com_idcompany},
                { "@idarea",datos.are_idarea},
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
            + " from companyareas"
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


        public List<CompanyAreasDto> searchRecordById(int id)
        {
            List<CompanyAreasDto> list = new List<CompanyAreasDto>();

            string sql =
               "SELECT"
              + " companylocation.com_idcompany, "
              + " companylocation.com_name, "
              + " companylocation.com_adress, "
              + " companylocation.com_doctype, "
              + " companylocation.com_number, "
              + " companylocation.com_idciudad, "
              + " companylocation.com_status, "
              + " companylocation.com_accessschedule, "
              + " areas.are_idarea, "
              + " areas.are_description, "
              + " areas.com_status "
              + " FROM companyareas "
              + " JOIN companylocation ON companyareas.ca_idcompany = companylocation.com_idcompany"
              + " JOIN areas  ON companyareas.ca_idarea = areas.are_idarea"
              + " WHERE companylocation.com_idcompany = @Datos";

            var parametros = new Dictionary<string, object>
             {
                { "@Datos", id }
             };

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    CompanyAreasDto doct = new CompanyAreasDto(
                        dr.GetInt32(dr.GetOrdinal("com_idcompany")),
                        dr.GetString(dr.GetOrdinal("com_name")),
                        dr.GetString(dr.GetOrdinal("com_adress")),
                        dr.GetInt32(dr.GetOrdinal("com_doctype")),
                        dr.GetString(dr.GetOrdinal("com_number")),
                        dr.GetInt32(dr.GetOrdinal("com_idciudad")),
                        dr.GetBoolean(dr.GetOrdinal("com_status")),
                        dr.GetString(dr.GetOrdinal("com_accessschedule")),
                        dr.GetInt32(dr.GetOrdinal("are_idarea")),
                        dr.GetString(dr.GetOrdinal("are_description")),
                        dr.GetString(dr.GetOrdinal("com_status"))

                      );
                    list.Add(doct);
                }
            }
            return list;
        }

        public List<CompanyAreasDto> searchRecordByName(CompanyAreasDto datos)
        {
            List<CompanyAreasDto> list = new List<CompanyAreasDto>();

            string sql =
               "SELECT"
               + " companylocation.com_idcompany, "
              + " companylocation.com_name, "
              + " companylocation.com_adress, "
              + " companylocation.com_doctype, "
              + " companylocation.com_number, "
              + " companylocation.com_idciudad, "
              + " companylocation.com_status, "
              + " companylocation.com_accessschedule, "
              + " areas.are_idarea, "
              + " areas.are_description, "
              + " areas.com_status "
              + " FROM companylocation "
                + " JOIN companylocation ON companyareas.ca_idcompany = companylocation.com_idcompany"
              + " JOIN areas  ON companyareas.ca_idarea = areas.are_idarea"
              + " WHERE companylocation.com_name = @Datos";

            var parametros = new Dictionary<string, object>
             {
                { "@Datos", datos.com_name }
             };

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    CompanyAreasDto doct = new CompanyAreasDto(
                        dr.GetInt32(dr.GetOrdinal("com_idcompany")),
                        dr.GetString(dr.GetOrdinal("com_name")),
                        dr.GetString(dr.GetOrdinal("com_adress")),
                        dr.GetInt32(dr.GetOrdinal("com_doctype")),
                        dr.GetString(dr.GetOrdinal("com_number")),
                        dr.GetInt32(dr.GetOrdinal("com_idciudad")),
                        dr.GetBoolean(dr.GetOrdinal("com_status")),
                        dr.GetString(dr.GetOrdinal("com_accessschedule")),
                        dr.GetInt32(dr.GetOrdinal("are_idarea")),
                        dr.GetString(dr.GetOrdinal("are_description")),
                        dr.GetString(dr.GetOrdinal("com_status"))

                      );
                    list.Add(doct);
                }
            }
            return list;
        }
    }
}
