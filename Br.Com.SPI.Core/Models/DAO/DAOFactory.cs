﻿namespace Br.Com.SPI.Core.Models.DAO
{
    public class DAOFactory
    {
        public IDTOMedicao InitDTOMedicaoDAO()
        {
            return new DTOMedicaoDAOImpl();
        }

        public IPlanoInspecaoCabDAO InitPlanoInspecaoCabDAO()
        {
            return new PlanoInspecaoCabDAOImpl();
        }

        public IOrdemProducaoDAO InitOrdemProducaoDAO()
        {
            return new OrdemProducaoDAOImpl();
        }

        public IConnectionDAO InitConnectionDAO()
        {
            return new ConnectionDAOImpl();
        }

        public IMotivoN1DAO InitMotivoN1DAO()
        {
            return new MotivoN1DAOImpl();
        }
    }
}