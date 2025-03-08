namespace WSBackCityLending.dominio.dto
{
    public class ProfileUserDto
    {
     

       public int idperfil { get; set; }

        public string perfil { get; set; }
        public string nusuario { get; set; }
        public string ausuario { get; set; }
         public ProfileUserDto() { }

        public ProfileUserDto(
           int     id,
           string idprofile,
           string nusuario,
           string ausuario
         )
        {
            this.idperfil = id;
            this.perfil = idprofile;
            this.nusuario = nusuario;
            this.ausuario = ausuario;
    

        }
    }
}
