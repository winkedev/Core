using Br.Com.SPI.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Br.Com.SPI.Core.Models.DAO
{
    public sealed class OrdemProducaoDAOImpl : DAOImpl, IOrdemProducaoDAO
    {
        public List<OrdemProducao> GetAll()
        {
            List<OrdemProducao> list = new List<OrdemProducao>();
            var dt = this.GetDataTable("spGetOrdemProducao");
            
            foreach (DbDataReader row in dt)
            {
                list.Add(this.ParseToDTO(row));
            }

            return list;
        }

        public OrdemProducao Delete(OrdemProducao t)
        {
            throw new NotImplementedException();
        }

        public OrdemProducao ParseToDTO(DbDataReader row)
        {
            OrdemProducao o = new OrdemProducao();
            o.CodigoOp = row.ParseToString("codOP");
            o.CodigoItem = row.ParseToString("codItem");
            o.CodigoCC = row.ParseToString("codCC");
            o.Dispositivo = row.ParseToString("dispositivo");
            o.QuantidadePrevista = row.ParseToInt("qtdPrevista");
            o.QuantidadeProduzida = row.ParseToInt("qtdProduzida");
            o.DataInicio = row.ParseToDatetime("dataInicio");
            o.DataFim = row.ParseToDatetime("dataFim");
            o.Status = row.ParseToInt("status");
            o.DataRI = row.ParseToDatetime("dataRI");
            return o;
        }

        public Dictionary<string, object> ParseToParameters(OrdemProducao t)
        {
            throw new NotImplementedException();
        }

        public OrdemProducao SaveUpdate(OrdemProducao t)
        {
            throw new NotImplementedException();
        }
    }
}
