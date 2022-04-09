namespace SehirRehberi.API
{
    static public class Configuration
    {
        static public string ConfigurationString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("DefaultConnection");
            }
        }

        static public string ConfigurationTokenString
        {
            get
            {
                
                ConfigurationManager configurationManager = new();
                /*configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetSection("Token").Value;
                */
                return configurationManager.GetValue<string>("AppSettings:Token", "gizli/*-+?&% anahtar");
            }
        }
    }
}
