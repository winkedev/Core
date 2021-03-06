﻿namespace Br.Com.SPI.Core.Models.DAO
{
    internal sealed class ConnectionDAOImpl : DAOImpl, IConnectionDAO
    {
        public SecurityConfig GetConnectionString()
        {
            return SecurityConfig.GetInstance();
        }

        public bool TestConnection()
        {
            return this.IsConnected();
        }
    }
}
