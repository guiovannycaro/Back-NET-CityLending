using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Npgsql;

namespace WSBackCityLending.infraestructura.util
{
    public class executeQueryBD
    {



        public NpgsqlDataReader ExecuteSelectBd(string sql, Dictionary<string, object> parameters)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(ConnectionFactory.connectToBD());
                connection.Open();

                var cmd = new NpgsqlCommand(sql, connection);

                // Agregar parámetros si existen
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                return cmd.ExecuteReader();// El lector cerrará la conexión automáticamente
            }
            catch (NpgsqlException ex)
            {
                Console.Error.WriteLine($"SQLException: {ex.Message}");
                return null;
            }
        }


        public Boolean executeUpdateBd(String sql, Dictionary<string, object> parameters) {
            Boolean resultado;
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionFactory.connectToBD()))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(sql, connection))
                    {

                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }

                        cmd.ExecuteNonQuery();
                        resultado = true;
                    }
                }
            } catch (SqlException ex)
            {
                Console.Error.WriteLine("SQLException:\n " + ex + " Errror al actualizar el valor");
                resultado = false;
            }
            return resultado;

        }
      }

}
