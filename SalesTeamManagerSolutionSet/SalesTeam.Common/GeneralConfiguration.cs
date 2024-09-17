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
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true, NewLine = "\n" };
        private static GeneralConfiguration? _currentConfiguration;

        public GeneralConfiguration()
        {
        }

        /// <summary>
        /// The path to the CSV file - Initial System Data Population.
        /// </summary>
        public string CsvFilePath { get; set; }



        public static GeneralConfiguration Current()
        {
            // Get configuration path from appsettings.json
            if (_currentConfiguration == null)
            {

                // .NET App Settings Reader
                // https://docs.microsoft.com/en-us/dotnet/core/extensions/configuration

                if (_currentConfiguration == null)
                {
                    _currentConfiguration = DefaultConfiguration();
                }
            }
            return _currentConfiguration;
        }

        /// <summary>
        /// Provide a default configuration - a base populator, then writer to initialize the system.
        /// </summary>
        /// <param name="path"></param>
        public static GeneralConfiguration DefaultConfiguration()
        {
            GeneralConfiguration config = new GeneralConfiguration
            {
                CsvFilePath = "SalesRecords.csv"
            };
            return config;
        }

        /// <summary>
        /// Write current Configuration settings to File
        /// </summary>
        /// <param name="path">the path of the configuration file that will be written to.</param>
        public void WriteConfigurationToFile(string path)
        {
            string json = JsonSerializer.Serialize(this, _jsonSerializerOptions);
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
