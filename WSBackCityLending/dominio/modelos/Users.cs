namespace WSBackCityLending.dominio.modelos
{
    public class Users
    {
        public int idusuario { get; set; }
        public string usu_nombre { get; set; }
        public string usu_apellido { get; set; }
        public int usu_idtipodocumento { get; set; }
        public string usu_numerodocumento { get; set; }
        public string usu_direccion { get; set; }
        public string usu_telefono { get; set; }
        public int usu_ciudad { get; set; }
        public String usu_email { get; set; }
        public String usu_contrasena { get; set; }
       
        public Boolean usu_cambiocontrasena { get; set; }

        public Boolean usu_estado { get; set; }

     

        public Users() { }

        public Users(
           int idusuario,
           string firstname,
           string lastname,
           int iddoctype,
           string iddocnumber,
           string adress,
           string phone,
           int idciudad,
           string email,
           string password,
           Boolean cambiocontrasena,
              Boolean status
        
         )
        {
            this.idusuario = idusuario;
            this.usu_nombre = firstname;
            this.usu_apellido = lastname;
            this.usu_idtipodocumento = iddoctype;
            this.usu_numerodocumento = iddocnumber;
            this.usu_direccion = adress;
            this.usu_telefono = phone;
            this.usu_ciudad = idciudad;
            this.usu_email = email;
            this.usu_contrasena = password;
            this.usu_cambiocontrasena = cambiocontrasena;
            this.usu_estado = status;
           
        }





    }
}
