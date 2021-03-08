using Br.Com.SPI.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Data;

namespace Br.Com.SPI.Core.Models.DAO
{
    internal sealed class PlanoInspecaoCaracImpl : DAOImpl, IPlanoInspecaoCaracDAO
    {
        public PlanoInspecaoCaract Delete(PlanoInspecaoCaract t)
        {
            throw new NotImplementedException();
        }

        public List<PlanoInspecaoCaract> GetPlanoInspecaoCaracByPlanoInspecaoCab(PlanoInspecaoCab cab)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                { "IDPLANOCAB", cab.ID }
            };

            List<PlanoInspecaoCaract> list = new List<PlanoInspecaoCaract>();

            using (DataTable dt = this.GetDataTable("spGetPlanoInspecaocaracByPlanoInspecaoCab @IDPLANOCAB", dic))
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(this.ParseToDTO(row));
                }
            }

            return list;
        }

        public PlanoInspecaoCaract ParseToDTO(DataRow row)
        {
            PlanoInspecaoCaract p = new PlanoInspecaoCaract();
            p.ID = row.ParseToInt64("Id");
            p.Posicao = row.ParseToString("posicao");
            p.Tipo = row.ParseToString("tipo");
            p.Caracteristica = row.ParseToString("caracteristica");
            p.Classe = row.ParseToString("class");
            p.QuantidadeMedicoes = row.ParseToInt("qtdMedicoes");
            p.LimInf = row.ParseToDecimal("limInf");
            p.LimSup = row.ParseToDecimal("limSup");
            p.TipoCarac = row.ParseToString("tipoCarac");
            p.Observacao = row.ParseToString("obs");
            p.MetodoAvaliacao = row.ParseToString("metodoAvaliacao");
            p.QuantidadeMedicoesInicio = row.ParseToInt("qtdMedicoesInicio");
            p.QuantidadeMedicoesFinal = row.ParseToInt("qtdMedicoesFinal");
            p.FatorMedicoes = row.ParseToInt("fatorMedicoes");
            p.DataRI = row.ParseToDatetime("dataRI");

            try
            {
                p.MedicaoCaract = new DAOFactory().InitMedicaoCaracDAO().GetMedicaoCaracByPlanoInspecaoCarac(p);
            }
            catch { }

            return p;
        }

        public Dictionary<string, object> ParseToParameters(PlanoInspecaoCaract t)
        {
            throw new NotImplementedException();
        }

        public PlanoInspecaoCaract SaveUpdate(PlanoInspecaoCaract t)
        {
            throw new NotImplementedException();
        }
    }
}
