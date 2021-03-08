using Br.Com.SPI.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Br.Com.SPI.Core.Models.DAO
{
    internal abstract class DAOImpl
    {
        private const string DEFAULT_ERROR_COLUMN = "Retorno";
        private const string DEFAULT_ERROR_MESSAGE_COLUMN = "Mensagem";

        private DbProviderFactory currentFactory;

        private string MountConnection()
        {
            StringBuilder b = new StringBuilder();
            b.Append($@"Data Source={SecurityConfig.GetInstance().SqlServer};");
            b.Append($@"Initial Catalog={SecurityConfig.GetInstance().SqlDatabase};");
            b.Append($@"User ID={SecurityConfig.GetInstance().SqlUID};");
            b.Append($@"Password={SecurityConfig.GetInstance().SqlPWD};");
            b.Append($@"Persist Security Info={true};");
            b.Append($@"Connect Timeout={SecurityConfig.GetInstance().SqlTimeout};");
            return b.ToString();
        }

        private DbConnection OpenConnection()
        {
            this.currentFactory = DbProviderFactories.GetFactory(SecurityConfig.GetInstance().SqlProvider);
            DbConnection connection = this.currentFactory.CreateConnection();
            connection.ConnectionString = this.MountConnection();
            connection.Open();
            return connection;
        }

        public DataTable GetDataTable(string query, Dictionary<string, object> dic = null)
        {
            using (DbConnection con = this.OpenConnection())
            {
                using (DbCommand command = this.currentFactory.CreateCommand())
                {
                    command.CommandText = query;
                    command.Connection = con;

                    if (dic != null)
                    {
                        foreach (KeyValuePair<string, object> keypair in dic)
                        {
                            DbParameter parameter = this.currentFactory.CreateParameter();
                            parameter.ParameterName = keypair.Key;
                            parameter.Value = keypair.Value;
                            command.Parameters.Add(parameter);
                        }
                    }

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader, LoadOption.OverwriteChanges);
                        return table;
                    }
                }
            }
        }

        public void CheckPatternError(DataRowCollection rows)
        {
            if (rows?.Count > 0 && !string.IsNullOrEmpty(rows[0].ParseToString(DEFAULT_ERROR_COLUMN)) && !string.IsNullOrEmpty(rows[0].ParseToString(DEFAULT_ERROR_MESSAGE_COLUMN)) )
            {
                throw new Exception(rows[0].ParseToString(DEFAULT_ERROR_MESSAGE_COLUMN));
            }
        }

        public bool IsConnected()
        {
            using (DbConnection c = this.OpenConnection())
            {
                return true;
            }
        }

        protected object GetValueOrDbNull(object obj)
        {
            if (obj is string o)
            {
                return !string.IsNullOrEmpty(o) ? obj : DBNull.Value;
            }
            else if(obj is DateTime d)
            {
                if (d == null || d == default)
                {
                    return DBNull.Value;
                }

                return d;
            }

            return obj ?? DBNull.Value;
        }
    }
}
