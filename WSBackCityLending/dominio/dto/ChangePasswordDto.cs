namespace WSBackCityLending.dominio.dto
{
    public class ChangePasswordDto
    {

       public string lastpass { get; set; }
        public string newpass { get; set; }
        public string confpassd { get; set; }

        public string usename { get; set; }
        ChangePasswordDto() { }

        ChangePasswordDto(
            string lpass,
        string npass,
        string cpassd,
        string uname
            ) {

            this.lastpass = lpass;
            this.newpass = npass;
            this.confpassd = cpassd;
            this.usename = uname;
        }
    }
}
