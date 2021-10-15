using System;
using System.IO;
using System.Reflection;

using Touryo.Infrastructure.Public.Util;

namespace KafkaConfig
{
    /// <summary>Initial</summary>
    public class Initial
    {
        /// <summary>InitConfig</summary>
        public static void InitConfig()
        {
            string dir = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory
                .FullName.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            GetConfigParameter.InitConfiguration(dir + "/appsettings.json");
        }

        /// <summary>GetConfigValue</summary>
        /// <param name="brokerList">string</param>
        /// <param name="topic">string</param>
        /// <param name="connectionString">string</param>
        /// <param name="cacertLocation">string</param>
        /// <param name="consumerGroup">string</param>
        public static void GetConfigValues(out string brokerList, out string topic,
            out string connectionString,  out string cacertLocation, out string consumerGroup)
        {
            brokerList = GetConfigParameter.GetConfigValue("EH_FQDN");
            topic = GetConfigParameter.GetConfigValue("EH_NAME");
            connectionString = GetConfigParameter.GetConnectionString("EH_CONNECTION_STRING");
            cacertLocation = GetConfigParameter.GetConfigValue("CA_CERT_LOCATION");
            consumerGroup = GetConfigParameter.GetConfigValue("CONSUMER_GROUP");
        }
    }
}
