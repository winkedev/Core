using Br.Com.SPI.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Data;

namespace Br.Com.SPI.Core.Models.DAO
{
    internal sealed class MedicaoCaracDAOImpl : DAOImpl, IMedicaoCaracDAO
    {
        public List<MedicaoCaract> GetMedicaoCaracByMedicaoCab(MedicaoCab cab)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                { "IDMEDICAOCAB", cab.ID }
            };

            List<MedicaoCaract> list = new List<MedicaoCaract>();

            using (DataTable dt = this.GetDataTable("spGetMedicaoCaracByMedicaoCab @IDMEDICAOCAB", dic))
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(this.ParseToDTO(row));
                }
            }

            return list;
        }

        public List<MedicaoCaract> GetMedicaoCaracByPlanoInspecaoCarac(PlanoInspecaoCaract plano)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                { "IDPLANO", plano.ID }
            };

            List<MedicaoCaract> list = new List<MedicaoCaract>();

            using (DataTable dt = this.GetDataTable("spGetMedicaoCaracByPlanoInspecaoCarac @IDPLANO", dic))
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(this.ParseToDTO(row));
                }
            }

            return list;
        }

        public bool UpdateValorMedido(long idMedicaoCab, string valorMedido)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>
            {
                { "ID", idMedicaoCab },
                { "VALORMEDIDO", valorMedido },
            };

            using (DataTable dt = this.GetDataTable("spAtualizaValorMedido @ID, @VALORMEDIDO", dic))
            {
                foreach (DataRow row in dt.Rows)
                {
                    return true;
                }
            }

            return false;
        }

        public MedicaoCaract Delete(MedicaoCaract t)
        {
            throw new NotImplementedException();
        }

        public MedicaoCaract ParseToDTO(DataRow row)
        {
            MedicaoCaract m = new MedicaoCaract();
            m.ID = row.ParseToInt64("Id");
            m.NumeroMedicao = row.ParseToInt("numMedicao");
            m.ValorMedido = row.ParseToString("valorMedido");
            m.NumeroMatricula = row.ParseToInt("numMatricula");
            m.DataMedicao = row.ParseToDatetime("dataMedicao");
            m.DataRI = row.ParseToDatetime("dataRI");
            m.IDTipoMedicao = row.ParseToInt64("idTipoMedicao");

            try
            {
                m.TipoMedicao = new DAOFactory().InitTipoMedicaoDAO().GetTipoMedicaoByID(m.IDTipoMedicao);
            }
            catch { }

            return m;
        }

        public Dictionary<string, object> ParseToParameters(MedicaoCaract t)
        {
            throw new NotImplementedException();
        }

        public MedicaoCaract SaveUpdate(MedicaoCaract t)
        {
            throw new NotImplementedException();
        }
    }
}
