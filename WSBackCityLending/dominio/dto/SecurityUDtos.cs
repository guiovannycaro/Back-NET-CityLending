namespace WSBackCityLending.dominio.dto
{
    public class SecurityUDtos
    {

        public string username { get; set; }

        public string password { get; set; }


       public  SecurityUDtos() { }


        public SecurityUDtos(
            string usuario,
        string clave
            ) {

            this.username = usuario;
            this.password = clave; }
    }
}
