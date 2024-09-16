using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SalesTeam.Common
{
    public class GeneralConfiguration
    {
        public GeneralConfiguration() { }

        public List<string> CSVFilePaths { get; set; }

        // Write Configuration to File
        public void WriteConfigurationToFile(string path)
        {
            string json = JsonSerializer.Serialize(this);
            using (var writer = new StreamWriter(path, append: false, encoding: Encoding.UTF8))
            {
                writer.Write(json);
            }
        }

        // Read Configuration from File
        public static GeneralConfiguration ReadConfigurationFromFile(string path)
        {
            using StreamReader reader = new(path);
            string json = reader.ReadToEnd();
            GeneralConfiguration config = JsonSerializer.Deserialize<GeneralConfiguration>(json)
                                          ?? throw new InvalidOperationException("Failed to deserialize configuration.");
            return config;
        }
    }
}
