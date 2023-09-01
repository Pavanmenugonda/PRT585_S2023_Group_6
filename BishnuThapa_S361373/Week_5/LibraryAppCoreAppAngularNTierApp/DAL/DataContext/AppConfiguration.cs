using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DAL.DataContext
{
    public class AppConfiguration
    {
        //CONSTRUCTOR
        public AppConfiguration()
        {
            //Configuration Builder - Used to obtain configuration settings from a config/settings file (Builds a key/value structure).
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            //Setting the path to our appsettings.json file.
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            //Pass/Add the json files (Settings file) content to the configuration builder.
            configurationBuilder.AddJsonFile(path, false);
            //The builds a object consisting of the contents of settings file and maps them to a key/value structure/object [root is our object]
            IConfigurationRoot root = configurationBuilder.Build();
            //Obtains the value we are requiring by providing the root settings object the key for the value we want. 
            IConfigurationSection appSettings = root.GetSection("ConnectionStrings:DefaultConnection");
            //Simply assigning the key value (connection string) to the SqlConnectionVariable so it can be accessed when we init this class
            SqlConnectionString = appSettings.Value;
        }

        public String SqlConnectionString { get; set; }
    }
}
