namespace WSBackCityLending.dominio.modelos
{
    public class CompanyLocation
    {
        public int com_idcompany { get; set; }

        public string com_name { get; set; }
        public string com_adress { get; set; }

        public int com_doctype { get; set; }

        public int com_number { get; set; }
        public int com_idciudad { get; set; }
        public Boolean com_status { get; set; }

        public Boolean com_AccessSchedule { get; set; }

    


        public CompanyLocation() { }


        public CompanyLocation(
             int idcompany ,
             string name ,
             string adress ,
             int doctype,
             int number,
             int idciudad ,
             Boolean status ,
            Boolean AccessSchedule
        
            ) {
            this.com_idcompany = idcompany;
            this.com_name = name;
            this.com_adress = adress;
            this.com_doctype = doctype;
            this.com_number = number;
            this.com_idciudad = idciudad;
            this.com_status = status;
            this.com_AccessSchedule = AccessSchedule;
          
        }


    }
}
