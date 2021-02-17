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
        public List<PlanoInspecaoCab> GetPlanoInspecaoCabBy(string codigoCC, string descricaoItem, string codigoOP, DateTime dataInicial, DateTime dataFinal)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                { "CODIGOCC", codigoCC },
                { "DESCRICAOITEM", this.GetValueOrDbNull(descricaoItem) },
                { "CODIGOOP", this.GetValueOrDbNull(codigoOP) },
                { "DATAINICIAL", this.GetValueOrDbNull(dataInicial) },
                { "DATAFINAL", this.GetValueOrDbNull(dataFinal) }
            };

            List<PlanoInspecaoCab> list = new List<PlanoInspecaoCab>();

            foreach(DbDataReader row in this.GetDataTable("spGetPlanoInspecaoBy @CODIGOCC, @DESCRICAOITEM, @CODIGOOP, @DATAINICIAL, @DATAFINAL", dic))
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

            try
            {
                p.PlanoInspecaoCaract = new DAOFactory().InitPlanoInspecaoCaracDAO().GetPlanoInspecaoCaracByPlanoInspecaoCab(p);
            }
            catch { }

            try
            {
                p.MedicaoCab = new DAOFactory().InitMedicaoCabDAO().GetMedicaoCabByPlanoInspecaoCab(p);
            }
            catch { }

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
