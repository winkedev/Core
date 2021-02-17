using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Br.Com.SPI.Core
{
    [Serializable]
    public class SecurityConfig
    {
        private static SecurityConfig instance;

        [XmlElement("Server"), JsonPropertyName("server")]
        public string SqlServer { get; private set; }

        [XmlElement("UserID"), JsonPropertyName("userID")]
        public string SqlUID { get; private set; }
        
        [XmlIgnore, JsonIgnore]
        public string SqlPWD { get; private set; }

        [XmlElement("Database"), JsonPropertyName("database")]
        public string SqlDatabase { get; private set; }

        [XmlElement("Timeout"), JsonPropertyName("timeout")]
        public string SqlTimeout { get; private set; }

        [XmlElement("Provider"), JsonPropertyName("provider")]
        public string SqlProvider { get; private set; }

        private SecurityConfig()
        {

        }

        public static SecurityConfig GetInstance()
        {
            return instance = instance ?? new SecurityConfig();
        }

        public SecurityConfig AddSqlServer(string server)
        {
            this.SqlServer = server;
            return this;
        }

        public SecurityConfig AddSqlUID(string uid)
        {
            this.SqlUID = uid;
            return this;
        }

        public SecurityConfig AddSqlPWD(string password)
        {
            this.SqlPWD = password;
            return this;
        }

        public SecurityConfig AddSqlDatabase(string database)
        {
            this.SqlDatabase = database;
            return this;
        }

        public SecurityConfig AddSqlTimeout(string timeout)
        {
            this.SqlTimeout = timeout;
            return this;
        }

        public SecurityConfig AddSqlProvider(string provider)
        {
            this.SqlProvider = provider;
            return this;
        }
    }
}
