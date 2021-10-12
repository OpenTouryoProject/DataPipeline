using System;
using System.IO;
using System.Reflection;

using OTRPU = Touryo.Infrastructure.Public.Util;

namespace KafkaConfig
{
    /// <summary>GetConfigParameter</summary>
    public class GetConfigParameter
    {
        /// <summary>InitConfig</summary>
        public static void InitConfig()
        {
            string dir = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory
                .FullName.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            OTRPU.GetConfigParameter.InitConfiguration(dir + "/appsettings.json");
        }

        /// <summary>GetConfigValue</summary>
        /// <param name="key">string</param>
        /// <returns>string</returns>
        public static string GetConfigValue(string key)
        {
            return OTRPU.GetConfigParameter.GetConfigValue(key);
        }

        /// <summary>GetConnectionString</summary>
        /// <param name="key">string</param>
        /// <returns>string</returns>
        public static string GetConnectionString(string key)
        {
            return OTRPU.GetConfigParameter.GetConnectionString(key);
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
