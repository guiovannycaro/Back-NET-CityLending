using Npgsql;
using System.Data.SqlClient;
using System.Text.Json;
using WSBackCityLending.dominio.dto;
using WSBackCityLending.dominio.modelos;
using WSBackCityLending.infraestructura.interfases;
using WSBackCityLending.infraestructura.util;

namespace WSBackCityLending.aplicacion.dao
{
    public class ServicioSeguridadDaoImpl : IServicioSeguridadInter
    {
        private executeQueryBD _conectionString;
   

        public ServicioSeguridadDaoImpl(executeQueryBD conectionString)
        {
            _conectionString = conectionString;
        }

        public Boolean autenticacion(SecurityUDtos datos)
        {
            string sql = "SELECT usuarios.usu_email AS nombre FROM usuarios WHERE usu_email = @username AND usu_contrasena = @contrasena";

            var parametros = new Dictionary<string, object>
             {
                { "@username", datos.username },
                { "@contrasena", datos.password }
             };

            String vusuario = "";

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    vusuario = dr.GetString(dr.GetOrdinal("nombre")) ;
                }
            }

            if (string.IsNullOrEmpty(vusuario))
            {
                return false;
            }
            return true;
        }


        public string getRoles(string datos)
        {

            string perfil = "";
            string sql = "SELECT perfil.idperfil AS perfil " +
                         "FROM perfil_usuario " +
                         "JOIN usuarios ON perfil_usuario.idusuario = usuarios.idusuario " +
                         "JOIN perfil ON perfil_usuario.idperfil = perfil.idperfil " +
                         "WHERE usuarios.usu_email = @datos AND perfil.estado = true";


            var parametros = new Dictionary<string, object>
    {
        { "@datos", datos.Trim() }
    };

            try
            {
                using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
                {
                    if (dr.Read())
                    {
                        perfil = dr.GetInt32(dr.GetOrdinal("perfil")).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta: " + ex.Message);
                return JsonSerializer.Serialize(new { error = "Error en la consulta", detalle = ex.Message });
            }

            if (string.IsNullOrEmpty(perfil))
            {

                Ansewer respuesta = new Ansewer("404", "error", "No se encontro el rol del usuario");
                return JsonSerializer.Serialize(respuesta);

            }

            string jsonRespuesta = JsonSerializer.Serialize(new { perfil }, new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return jsonRespuesta;
        }

        public String getUserName(String datos)
        {
            String per_nombres = "";
            String sql = " select " 
                       + " usuarios.usu_nombre as nombre," 
                       + " usuarios.usu_apellido as apellido " 
                       + " from usuarios "
                       + " where usuario.usu_email = @datos";

            var parametros = new Dictionary<string, object>
            {
              { "@datos", datos.Trim() }
            };

            try
            {
                using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
                {
                    if (dr.Read())
                    {
                        per_nombres = dr.GetString(dr.GetOrdinal("nombre")) + " " + dr.GetString(dr.GetOrdinal("apellidos"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta: " + ex.Message);
                return JsonSerializer.Serialize(new { error = "Error en la consulta", detalle = ex.Message });
            }

            if (string.IsNullOrEmpty(per_nombres))
            {

                Ansewer respuesta = new Ansewer("404", "error", "No se encontro el rol del usuario");
                return JsonSerializer.Serialize(respuesta);

            }

            string jsonRespuesta = JsonSerializer.Serialize(new { per_nombres }, new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return jsonRespuesta;

        }


       
        public Ansewer cambiarPassword(ChangePasswordDto datos)
        {
            Ansewer valRpt;
             string per_lpass="";
             var parametros = new Dictionary<string, object>
             {
               { "@email", datos.usename },
               { "@password", datos.newpass },
               { "@lpassword", datos.lastpass }
             };

            if (string.IsNullOrWhiteSpace(datos.usename) || string.IsNullOrWhiteSpace(datos.newpass) || string.IsNullOrWhiteSpace(datos.confpassd))
            {
                valRpt = new Ansewer("400", "Error", "Los campos no pueden estar vacíos");
            }

            if (datos.newpass != datos.confpassd)
            {
                valRpt = new Ansewer("400", "Error", "Las contraseñas no coinciden");
            }

              string sqla = " SELECT usu_contrasena as lastpassword from usuarios " +
                         " WHERE" +
                         "  usu_contrasena = @lpassword";

              using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sqla, parametros))
              {
                  if (dr.Read())
                  {
                    per_lpass = dr.GetString(dr.GetOrdinal("lastpassword"));
                  }
              }

              if (per_lpass !=  datos.lastpass)
              {
                      string sql = "UPDATE usuarios SET "
                           + "usu_contrasena=@password, "
                           + "usu_cambiocontrasena=true "
                           + "WHERE usu_email=@email";
                      bool rpt = _conectionString.executeUpdateBd(sql, parametros);

                   if (rpt)
                     {
                       valRpt = new Ansewer("200", "Éxito", "La contraseña fue actualizada correctamente");
                     }
                      else
                     {
                    valRpt = new Ansewer("500", "Error", "No se pudo actualizar la contraseña");
                     }
                 } else {
                 valRpt = new Ansewer("500", "Error", "No se pudo actualizar la contraseña por que la antigua contrasena no coincide");
              }

            return valRpt;
        }



        public bool logOut(string datos)
        {
            throw new NotImplementedException();
        }

  
    }
}
