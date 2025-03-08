namespace WSBackCityLending.dominio.dto
{
    public class ScheduleUserDto
    {

        public int com_idcompany { get; set; }
        public string com_name { get; set; }
        public string com_adress { get; set; }

        public int com_doctype { get; set; }

        public string com_number { get; set; }
        public int com_idciudad { get; set; }
        public Boolean com_status { get; set; }

        public string com_AccessSchedule { get; set; }

        public int are_idarea { get; set; }
        public string are_description { get; set; }
        public string are_status { get; set; }

        public int usu_idusuario { get; set; }
        public string usu_firstname { get; set; }
        public string usu_lastname { get; set; }
        public int usu_iddoctype { get; set; }
        public string usu_iddocnumber { get; set; }
        public string usu_adress { get; set; }
        public string usu_phone { get; set; }
        public int usu_idciudad { get; set; }
        public String usu_email { get; set; }
        public String usu_password { get; set; }

        public Boolean usu_cambiocontrasena { get; set; }

        public Boolean usu_status { get; set; }

        public string sch_initialtime { get; set; }

        public string sch_finaltime { get; set; }

        public ScheduleUserDto() { }

        public ScheduleUserDto(
           int idcompany,
           string name,
           string adress,
           int doctype,
           string number,
           int idciudad,
           Boolean statusc,
           string AccessSchedule,

           int idarea,
           string description,
           string status,

           int idusuario,
           string firstname,
           string lastname,
           int iddoctype,
           string iddocnumber,
           string adressu,
           string phone,
           int idciudadu,
           string email,
           string password,
           Boolean cambiocontrasena,
           Boolean statusu,

           string initialtime ,
           string finaltime 

            )
        {
            this.com_idcompany = idcompany;
            this.com_name = name;
            this.com_adress = adress;
            this.com_doctype = doctype;
            this.com_number = number;
            this.com_idciudad = idciudad;
            this.com_status = statusc;
            this.com_AccessSchedule = AccessSchedule;

            this.are_idarea = idarea;
            this.are_description = description;
            this.are_status = status;

            this.usu_idusuario = idusuario;
            this.usu_firstname = firstname;
            this.usu_lastname = lastname;
            this.usu_iddoctype = iddoctype;
            this.usu_iddocnumber = iddocnumber;
            this.usu_adress = adressu;
            this.usu_phone = phone;
            this.usu_idciudad = idciudadu;
            this.usu_email = email;
            this.usu_password = password;
            this.usu_cambiocontrasena = cambiocontrasena;
            this.usu_status = statusu;

            this.sch_initialtime = initialtime;
            this.sch_finaltime = finaltime;
    }
    }
}
