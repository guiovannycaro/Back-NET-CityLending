namespace WSBackCityLending.dominio.modelos
{
    public class Ansewer
    {


        public string code { get; set; }
        public string message { get; set; }
        public string description { get; set; }

        public Ansewer() { } // Constructor sin parámetros (obligatorio para la serialización)

        public Ansewer(string code, string message, string description)
        {
            this.code = code;
            this.message = message;
            this.description = description;
        }
    }
}
