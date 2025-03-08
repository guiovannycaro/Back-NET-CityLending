namespace WSBackCityLending.dominio.dto
{
    public class CompanyAreasDto
    {



        public  int com_idcompany { get; set; }
        public  string com_name { get; set; }
        public string com_adress { get; set; }

        public int com_doctype { get; set; }

        public string com_number { get; set; }
        public int com_idciudad { get; set; }
        public Boolean com_status { get; set; }

        public string com_AccessSchedule { get; set; }

        public  int are_idarea { get; set; }
        public string are_description { get; set; }
        public string are_status { get; set; }

        public CompanyAreasDto() { }

        public CompanyAreasDto(
             int idcompany,
              string name,
             string adress,
             int doctype,
             string number,
             int idciudad,
             Boolean statusc,
             string AccessSchedule,
             int idarea ,
             string description,
             string status
            ) {
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
        }

    }
}
