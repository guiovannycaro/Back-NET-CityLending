namespace WSBackCityLending.dominio.modelos
{
    public class UserProfile
    {
        int perusu_idpu { get; set; }

        int perusu_idprofile { get; set; }

        int perusu_iduser { get; set; }


        public UserProfile() { }

        public UserProfile(
           int id,
          int idprofile,
           int iduser

         )
        {
            this.perusu_idpu = id;
            this.perusu_idprofile = idprofile;
            this.perusu_iduser = iduser;

        }
    }
}
