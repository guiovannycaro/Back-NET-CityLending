using System.Data.SqlClient;
using WSBackCityLending.dominio.modelos;
using WSBackCityLending.infraestructura.interfases;
using WSBackCityLending.infraestructura.util;
using Microsoft.AspNetCore.Http;
using Npgsql;
using System.Data;

using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WSBackCityLending.dominio.dto;
using System.Text.RegularExpressions;


namespace WSBackCityLending.aplicacion.dao
{
    public class UsersDaoImpl : IUsersInter
    {
        private executeQueryBD _conectionString;
     

        public UsersDaoImpl(executeQueryBD conectionString)
        {
            _conectionString = conectionString;
        }


        public List<Users> returnAll()
        {
            List<Users> list = new List<Users>();

            string sql =
                "SELECT"
               + " usuarios.idusuario,"
               + " usuarios.usu_nombre,"
               + " usuarios.usu_apellido,"
               + " usuarios.usu_email,"
               + " usuarios.usu_contrasena,"
               + " usuarios.usu_cambiocontrasena,"
               + " usuarios.usu_idtipodocumento,"
               + " usuarios.usu_numerodocumento,"
               + " usuarios.usu_direccion,"
               + " usuarios.usu_telefono,"
               + " usuarios.usu_ciudad,"
               + " usuarios.usu_email,"
               + " usuarios.usu_contrasena,"
               + " usuarios.usu_cambiocontrasena,"
               + " usuarios.usu_estado"
               + " FROM usuarios";
              
               

            var parametros = new Dictionary<string, object>();

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
              
                    while (dr.Read())
                    {
                        Users usuario = new Users(
                              dr.GetInt32(dr.GetOrdinal("idusuario")),
                                dr.GetString(dr.GetOrdinal("usu_nombre")),
                                dr.GetString(dr.GetOrdinal("usu_apellido")),
                                dr.GetInt32(dr.GetOrdinal("usu_idtipodocumento")),
                                dr.GetString(dr.GetOrdinal("usu_numerodocumento")),
                                dr.GetString(dr.GetOrdinal("usu_direccion")),
                                dr.GetString(dr.GetOrdinal("usu_telefono")),
                                dr.GetInt32(dr.GetOrdinal("usu_ciudad")),
                                dr.GetString(dr.GetOrdinal("usu_email")),
                                dr.GetString(dr.GetOrdinal("usu_contrasena")),
                                dr.GetBoolean(dr.GetOrdinal("usu_cambiocontrasena")),
                                dr.GetBoolean(dr.GetOrdinal("usu_estado"))
                                
                        );

                        list.Add(usuario);
                    }
                
                
            }

            return list;
        }



        public Ansewer addRecord(Users datos)
        {
            Ansewer valdIncome;

            string sql = "insert into usuarios (usu_nombre, usu_apellido, usu_idtipodocumento, "
                        + "usu_numerodocumento, usu_direccion, usu_telefono, usu_ciudad, usu_email, "
                        + "usu_contrasena, usu_cambiocontrasena,usu_estado) "
                        + "values (@name, @lastname, @iddoctype, @docnumber, @adress, @phone, "
                        + "@city, @email, @password, @cpassword,@estado)";

            var parametros = new Dictionary<string, object>
    {
        { "@name", datos.usu_nombre },
        { "@lastname", datos.usu_apellido },
        { "@iddoctype", datos.usu_idtipodocumento },
        { "@docnumber", datos.usu_numerodocumento },
        { "@adress", datos.usu_direccion },
        { "@phone", datos.usu_telefono },
        { "@city", datos.usu_ciudad },
        { "@email", datos.usu_email },
        { "@password", datos.usu_contrasena },
        { "@cpassword", datos.usu_cambiocontrasena },
        { "@estado", datos.usu_estado }
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



        public Ansewer updateRecords(Users datos)
        {
            Ansewer valdIncome;

            string sql = "UPDATE usuarios SET "
                  + "usu_nombre=@name, "
                  + "usu_apellido=@lastname, "
                  + "usu_idtipodocumento=@iddoctype, "
                  + "usu_numerodocumento=@docnumber, "
                  + "usu_direccion=@adress, "
                  + "usu_telefono=@phone, "
                  + "usu_ciudad=@city, "
                  + "usu_email=@email, "
                  + "usu_contrasena=@password, "
                  + "usu_cambiocontrasena=@cpassword, "
                  + "usu_estado=@estado "
                  + "WHERE idusuario=@id";

            var parametros = new Dictionary<string, object>
            {
              { "@id", datos.idusuario },
         { "@name", datos.usu_nombre },
        { "@lastname", datos.usu_apellido },
        { "@iddoctype", datos.usu_idtipodocumento },
        { "@docnumber", datos.usu_numerodocumento },
        { "@adress", datos.usu_direccion },
        { "@phone", datos.usu_telefono },
        { "@city", datos.usu_ciudad },
        { "@email", datos.usu_email },
        { "@password", datos.usu_contrasena },
        { "@cpassword", datos.usu_cambiocontrasena },
        { "@estado", datos.usu_estado }
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

        public Ansewer adicionarPerfiles(Users datos)
        {
            Ansewer valdIncome = new Ansewer();
            bool usuario = deleteRecordName(datos);
            int idusuario = searchRecordEmail(datos);

            if (idusuario > 0)
            {
              // int usu_perfil = 1;
              //  foreach (var perfil in datos.usu_perfil)
              //  { }
                    string sql2 = "insert into perfil_usuario (idusuario, idperfil) "
                                 + "values (@idusuario, @idperfil)";

                    var parametros2 = new Dictionary<string, object>
                     {
                       { "@idusuario", idusuario },
                //       { "@idperfil", perfil }
                     };

                    bool rpt2 = _conectionString.executeUpdateBd(sql2, parametros2);
                    if (!rpt2)
                    {

                        valdIncome = new Ansewer("500", "Informativo", "Failed to assign perfil.");
                        return valdIncome;
                    }
                
            }
            else
            {

                valdIncome = new Ansewer("500", "Informativo", "User not found by email.");
                
            }
            return valdIncome;

        }
            
            
            
            
        public bool deleteRecordName(Users datos)
        {
       
            string sql = " Delete "
            + " from usuarios"
            + " where idusuario = @Datos";

            var parametros = new Dictionary<string, object>
            {
                { "@Datos", datos.idusuario }
            };


            bool rpt = _conectionString.executeUpdateBd(sql, parametros);

            return rpt;
        }


        public Ansewer deleteRecord(int id)
        {
            Ansewer valdIncome;


            var parametros = new Dictionary<string, object>
            {
              { "@Datos", id }
            };

        


            string sql = " Delete"
          + " from usuarios"
          + " where idusuario = @Datos";

          

            bool rpt = _conectionString.executeUpdateBd(sql, parametros);

            if (rpt && rpt)
            {
                valdIncome = new Ansewer("200", "Informativo", "The Record was deleted correctly");
            }
            else
            {
                valdIncome = new Ansewer("500", "Informativo", "The Record was not deleted correctly");
            }
            return valdIncome;

        }



        public List<Users> searchRecordName(Users datos)
        {
            List<Users> list = new List<Users>();

            // Corrected SQL query
            string sql = " select "
                  + " usuarios.idusuario,"
               + " usuarios.usu_nombre,"
               + " usuarios.usu_apellido,"
               + " usuarios.usu_email,"
               + " usuarios.usu_contrasena,"
               + " usuarios.usu_cambiocontrasena,"
               + " usuarios.usu_idtipodocumento,"
               + " usuarios.usu_numerodocumento,"
               + " usuarios.usu_direccion,"
               + " usuarios.usu_telefono,"
               + " usuarios.usu_ciudad,"
               + " usuarios.usu_estado"
            + " from usuarios"

            + " where usuarios.usu_nombre = @Datos";

            var parametros = new Dictionary<string, object>
    {
        { "@Datos", datos.usu_nombre } // Pass the name of the user (usu_nombre)
    };

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                // Loop through the result set, though typically you should expect only one result here
                if (dr.Read())
                {
                    Users usuario = new Users(
                      dr.GetInt32(dr.GetOrdinal("idusuario")),
                                dr.GetString(dr.GetOrdinal("usu_nombre")),
                                dr.GetString(dr.GetOrdinal("usu_apellido")),
                                dr.GetInt32(dr.GetOrdinal("usu_idtipodocumento")),
                                dr.GetString(dr.GetOrdinal("usu_numerodocumento")),
                                dr.GetString(dr.GetOrdinal("usu_direccion")),
                                dr.GetString(dr.GetOrdinal("usu_telefono")),
                                dr.GetInt32(dr.GetOrdinal("usu_ciudad")),
                                dr.GetString(dr.GetOrdinal("usu_email")),
                                dr.GetString(dr.GetOrdinal("usu_contrasena")),
                                dr.GetBoolean(dr.GetOrdinal("usu_cambiocontrasena")),
                                dr.GetBoolean(dr.GetOrdinal("usu_estado"))
                    );

                    list.Add(usuario);
                }
            }

            return list;  // Will return null if no matching user was found
        }




        public int searchRecordEmail(Users datos)
        {
            int email = 0;  // Default value if no email is found
            string sql = " SELECT usuarios.idusuario " 
                        + " FROM usuarios " 
                        + " WHERE usuarios.usu_email = @Datos";

            var parametros = new Dictionary<string, object>
    {
        { "@Datos", datos.usu_email }
    };

            try
            {
                // Ensure the database connection is open and ready before executing the query
                Console.WriteLine("Executing SQL query: " + sql);

                // Execute the query and get the reader
                using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
                {
                    if (dr != null && dr.HasRows)  // Check if the data reader is not null and has rows
                    {
                        while (dr.Read())
                        {
                            email = dr.GetInt32(dr.GetOrdinal("idusuario"));  // Fetch the idusuario
                            Console.WriteLine($"Found idusuario: {email}");
                        }
                    }
                    else
                    {
                        // If no rows were returned or dr is null
                        Console.WriteLine("No records found or dr is null for the provided email.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (or handle it accordingly)
                Console.Error.WriteLine("Error while executing query: " + ex.Message);
            }

            return email;  // Return the idusuario (or 0 if not found)
        }

        public Users searchRecordById(int id)
        {

            Users usuario = new Users();
            string sql = " select "
                  + " usuarios.idusuario,"
               + " usuarios.usu_nombre,"
               + " usuarios.usu_apellido,"
               + " usuarios.usu_email,"
               + " usuarios.usu_contrasena,"
               + " usuarios.usu_cambiocontrasena,"
               + " usuarios.usu_idtipodocumento,"
               + " usuarios.usu_numerodocumento,"
               + " usuarios.usu_direccion,"
               + " usuarios.usu_telefono,"
               + " usuarios.usu_ciudad,"
               + " usuarios.usu_estado,"
        
            + " from usuarios"

            + " where usuarios.idusuario = @Datos";

            var parametros = new Dictionary<string, object>
            {
                { "@Datos", id }
            };

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {
                    int[] perfiles = (int[])dr["perfiles"];

                    usuario = new Users(


                       dr.GetInt32(dr.GetOrdinal("idusuario")),
                                dr.GetString(dr.GetOrdinal("usu_nombre")),
                                dr.GetString(dr.GetOrdinal("usu_apellido")),
                                dr.GetInt32(dr.GetOrdinal("usu_idtipodocumento")),
                                dr.GetString(dr.GetOrdinal("usu_numerodocumento")),
                                dr.GetString(dr.GetOrdinal("usu_direccion")),
                                dr.GetString(dr.GetOrdinal("usu_telefono")),
                                dr.GetInt32(dr.GetOrdinal("usu_ciudad")),
                                dr.GetString(dr.GetOrdinal("usu_email")),
                                dr.GetString(dr.GetOrdinal("usu_contrasena")),
                                dr.GetBoolean(dr.GetOrdinal("usu_cambiocontrasena")),
                                dr.GetBoolean(dr.GetOrdinal("usu_estado"))
                    );
                   
                }
            }

            return usuario;
        }

        public Users findRecordById(int id)
        {

            Users usuario = new Users();
            string sql = " select "
                  + " usuarios.idusuario,"
               + " usuarios.usu_nombre,"
               + " usuarios.usu_apellido,"
               + " usuarios.usu_email,"
               + " usuarios.usu_contrasena,"
               + " usuarios.usu_cambiocontrasena,"
               + " usuarios.usu_idtipodocumento,"
               + " usuarios.usu_numerodocumento,"
               + " usuarios.usu_direccion,"
               + " usuarios.usu_telefono,"
               + " usuarios.usu_ciudad,"
               + " usuarios.usu_estado"
            + " from usuarios"
            + " where usuarios.idusuario = @Datos";

            var parametros = new Dictionary<string, object>
            {
                { "@Datos", id }
            };

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {


                     usuario = new Users(


                      dr.GetInt32(dr.GetOrdinal("idusuario")),
                                dr.GetString(dr.GetOrdinal("usu_nombre")),
                                dr.GetString(dr.GetOrdinal("usu_apellido")),
                                dr.GetInt32(dr.GetOrdinal("usu_idtipodocumento")),
                                dr.GetString(dr.GetOrdinal("usu_numerodocumento")),
                                dr.GetString(dr.GetOrdinal("usu_direccion")),
                                dr.GetString(dr.GetOrdinal("usu_telefono")),
                                dr.GetInt32(dr.GetOrdinal("usu_ciudad")),
                                dr.GetString(dr.GetOrdinal("usu_email")),
                                dr.GetString(dr.GetOrdinal("usu_contrasena")),
                                dr.GetBoolean(dr.GetOrdinal("usu_cambiocontrasena")),
                                dr.GetBoolean(dr.GetOrdinal("usu_estado"))

                    );

                }
            }

            return usuario;
        }


        public Users findRecordByName(Users name)
        {

            Users usuario = new Users();
            string sql = " select "
                  + " usuarios.idusuario,"
               + " usuarios.usu_nombre,"
               + " usuarios.usu_apellido,"
               + " usuarios.usu_email,"
               + " usuarios.usu_contrasena,"
               + " usuarios.usu_cambiocontrasena,"
               + " usuarios.usu_idtipodocumento,"
               + " usuarios.usu_numerodocumento,"
               + " usuarios.usu_direccion,"
               + " usuarios.usu_telefono,"
               + " usuarios.usu_ciudad,"
               + " usuarios.usu_estado"
            + " from usuarios"
            + " where usuarios.usu_nombre = @Datos";

            var parametros = new Dictionary<string, object>
            {
                { "@Datos", name.usu_nombre }
            };

            using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
            {
                while (dr.Read())
                {


                    usuario = new Users(


                        dr.GetInt32(dr.GetOrdinal("idusuario")),
                                dr.GetString(dr.GetOrdinal("usu_nombre")),
                                dr.GetString(dr.GetOrdinal("usu_apellido")),
                                dr.GetInt32(dr.GetOrdinal("usu_idtipodocumento")),
                                dr.GetString(dr.GetOrdinal("usu_numerodocumento")),
                                dr.GetString(dr.GetOrdinal("usu_direccion")),
                                dr.GetString(dr.GetOrdinal("usu_telefono")),
                                dr.GetInt32(dr.GetOrdinal("usu_ciudad")),
                                dr.GetString(dr.GetOrdinal("usu_email")),
                                dr.GetString(dr.GetOrdinal("usu_contrasena")),
                                dr.GetBoolean(dr.GetOrdinal("usu_cambiocontrasena")),
                                dr.GetBoolean(dr.GetOrdinal("usu_estado"))

                    );

                }
            }

            return usuario;
        }

        public List<ProfileUserDto> obtRegistryProfile(string datos)
        {
            List<ProfileUserDto> list = new List<ProfileUserDto>();

           
            string sql = "SELECT perfil.idperfil,"
                        + " perfil.descripcion AS perfil,"
                        + " usuarios.usu_nombre AS nusuario,"
                        + " usuarios.usu_apellido AS ausuario"
                        + " FROM perfil_usuario"
                        + " JOIN usuarios ON perfil_usuario.idusuario = usuarios.idusuario"
                        + " JOIN perfil ON perfil_usuario.idperfil = perfil.idperfil"
                        + " WHERE usuarios.usu_email = @Datos AND perfil.estado = true";

          

           
            
            var parametros = new Dictionary<string, object>
    {
        { "@Datos", datos.Trim() } 
    };

            
               
                using (NpgsqlDataReader dr = _conectionString.ExecuteSelectBd(sql, parametros))
                {
                    while (dr.Read())
                    {
                       
                        ProfileUserDto usuarioPerfil = new ProfileUserDto(
                            dr.GetInt32(dr.GetOrdinal("idperfil")),
                            dr.GetString(dr.GetOrdinal("perfil")),
                            dr.GetString(dr.GetOrdinal("nusuario")),
                            dr.GetString(dr.GetOrdinal("ausuario"))
                        );
                        
                        list.Add(usuarioPerfil);
                    }
                }
            

            return list;
        }


    }
}
