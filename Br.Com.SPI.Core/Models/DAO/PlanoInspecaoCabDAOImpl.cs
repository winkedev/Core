using Br.Com.SPI.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Br.Com.SPI.Core.Models.DAO
{
    internal sealed class PlanoInspecaoCabDAOImpl : DAOImpl, IPlanoInspecaoCabDAO
    {
        public List<PlanoInspecaoCab> GetAll()
        {
            List<PlanoInspecaoCab> list = new List<PlanoInspecaoCab>();

            var dt = this.GetDataTable("spGetPlanoInspecaoCab");
            
            foreach(DbDataReader row in dt)
            {
                list.Add(this.ParseToDTO(row));
            }
            

            return list;
        }

        public PlanoInspecaoCab Delete(PlanoInspecaoCab t)
        {
            throw new NotImplementedException();
        }

        public PlanoInspecaoCab ParseToDTO(DbDataReader row)
        {
            PlanoInspecaoCab p = new PlanoInspecaoCab();
            p.ID = row.ParseToInt64("Id");
            p.CodigoItem = row.ParseToString("codItem");
            p.DescricaoItem = row.ParseToString("descItem");
            p.VerPlano = row.ParseToString("verPlano");
            p.CodigoCC = row.ParseToString("codCC");
            p.DescricaoCC = row.ParseToString("descCC");
            p.DataRI = row.ParseToDatetime("dataRI");
            return p;
        }

        public Dictionary<string, object> ParseToParameters(PlanoInspecaoCab t)
        {
            throw new NotImplementedException();
        }

        public PlanoInspecaoCab SaveUpdate(PlanoInspecaoCab t)
        {
            throw new NotImplementedException();
        }
    }
}
