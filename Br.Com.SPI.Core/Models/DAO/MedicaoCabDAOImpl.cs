using Br.Com.SPI.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Data;

namespace Br.Com.SPI.Core.Models.DAO
{
    internal sealed class MedicaoCabDAOImpl : DAOImpl, IMedicaoCabDAO
    {
        public MedicaoCab Delete(MedicaoCab t)
        {
            throw new NotImplementedException();
        }

        public List<MedicaoCab> GetMedicaoCabByPlanoInspecaoCab(PlanoInspecaoCab cab)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                { "IDCAB", cab.ID }
            };

            List<MedicaoCab> list = new List<MedicaoCab>();

            using (DataTable dt = this.GetDataTable("spGetMedicaoCabByPlanoInspecaoCab @IDCAB", dic))
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(this.ParseToDTO(row));
                }
            }

            return list;
        }

        public MedicaoCab ParseToDTO(DataRow row)
        {
            MedicaoCab m = new MedicaoCab();
            m.ID = row.ParseToInt64("Id");
            m.DataInicio = row.ParseToDatetime("dataInicio");
            m.DataFim = row.ParseToDatetime("dataFim");
            m.DataRI = row.ParseToDatetime("dataRI");
            m.IDOrdemProducao = row.ParseToInt64("idOrdemProducao");

            try
            {
                m.OrdemProducao = new DAOFactory().InitOrdemProducaoDAO().GetByID(m.IDOrdemProducao);
            }
            catch { }

            try
            {
                m.MedicaoCaract = new DAOFactory().InitMedicaoCaracDAO().GetMedicaoCaracByMedicaoCab(m);
            }
            catch { }

            return m;
        }

        public Dictionary<string, object> ParseToParameters(MedicaoCab t)
        {
            throw new NotImplementedException();
        }

        public MedicaoCab SaveUpdate(MedicaoCab t)
        {
            throw new NotImplementedException();
        }
    }
}
