using System.Collections;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace QA.GoogleDemo.Support
{
    public class EnvConfiguration
    {
        public static Dictionary<string, string> serviceUrlMap = new Dictionary<string, string>();

        public static void FormPropertiesFromJSON()
        {
            var pathToResources = Directory.GetParent(@"../../../").FullName + Path.DirectorySeparatorChar + "Resources/";
            serviceUrlMap = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(pathToResources + "env.settings.json"));
        }
    }
}
