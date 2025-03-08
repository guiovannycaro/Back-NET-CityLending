namespace WSBackCityLending.dominio.modelos
{
    public class Profile
    {

        public int idperfil { get; set; }

        public String descripcion { get; set; }

        public Boolean estado { get; set; }


        public Profile() { }

        public Profile(
           int id,
           String decripcion,
           Boolean estado
         
         )
        {
            this.idperfil = id;
            this.descripcion = decripcion;
            this.estado = estado;
           
        }

    }
}
