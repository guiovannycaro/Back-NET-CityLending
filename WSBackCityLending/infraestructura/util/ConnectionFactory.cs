using WSBackCityLending.infraestructura.config.properties;

namespace WSBackCityLending.infraestructura.util
{
    public class ConnectionFactory
    {

        public static String connectToBD()
        {

            var propiedad = Propiedad.GetCurrentInstance();
            String connServer = propiedad.GetBDHost();
           
            String puerto = propiedad.GetBDPort();
        
            String username = propiedad.GetBDUsuario();

            String password = propiedad.GetBDClave();
            String bd = propiedad.GetBDDataBase();

            string rutaConexion = $"Host={connServer};Port={puerto};Database={bd};Username={username};Password={password};";
           
            return rutaConexion;
	}




}
}
