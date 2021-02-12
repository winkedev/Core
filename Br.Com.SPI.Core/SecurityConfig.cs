namespace Br.Com.SPI.Core
{
    public class SecurityConfig
    {
        private static SecurityConfig instance;

        public string SqlServer { get; private set; }
        public string SqlUID { get; private set; }
        public string SqlPWD { get; private set; }
        public string SqlDatabase { get; private set; }
        public string SqlTimeout { get; private set; }

        public string SqlProvider { get; private set; }

        private SecurityConfig()
        {

        }

        public static SecurityConfig GetInstance()
        {
            return instance = instance == null ? new SecurityConfig() : instance;
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
