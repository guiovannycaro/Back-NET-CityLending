namespace WSBackCityLending.dominio.modelos
{
    public class Areas
    {

       public  int are_idarea { get; set; }
       public  string are_description { get; set; }
       public Boolean com_status { get; set; }



        public Areas() { }


        public Areas(int idcarea,
        string description,
        Boolean status ) {
            this.are_idarea = idcarea;
            this.are_description = description;
            this.com_status = status;

        }



    }
}
