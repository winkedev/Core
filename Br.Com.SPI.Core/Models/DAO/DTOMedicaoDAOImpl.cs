using Br.Com.SPI.Core.Extensions;
using Br.Com.SPI.Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Br.Com.SPI.Core.Models.DAO
{
    public sealed class DTOMedicaoDAOImpl : DAOImpl, IDTOMedicao
    {
        public List<DTOMedicao> GetAll()
        {
            List<DTOMedicao> list = new List<DTOMedicao>();
            var dt = this.GetDataTable("spConsultaMedicao");

            foreach(DbDataReader row in dt)
            {
                list.Add(this.ParseToDTO(row));
            }
            
            return list;
        }

        public List<DTOMedicao> GetMedicaoBy(string codigoCC, string descricaoItem, string codigoOP, DateTime dataInicial, DateTime dataFinal)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                { "CODIGOCC", codigoCC },
                { "DESCITEM", this.GetValueOrDbNull(descricaoItem)},
                { "CODIGOOP", this.GetValueOrDbNull(codigoOP)},
                { "DATAINICIAL", this.GetValueOrDbNull(dataInicial)},
                { "DATAFINAL", this.GetValueOrDbNull(dataFinal)},
            };

            List<DTOMedicao> list = new List<DTOMedicao>();
            var dt = this.GetDataTable("spConsultaMedicaoBy @CODIGOCC, @DESCITEM, @CODIGOOP, @DATAINICIAL, @DATAFINAL", dic);
            
            foreach(DbDataReader row in dt)
            {
                list.Add(this.ParseToDTO(row));
            }
            

            return list;
        }

        public DTOMedicao Delete(DTOMedicao t)
        {
            throw new NotImplementedException();
        }

        public DTOMedicao ParseToDTO(DbDataReader row)
        {
            DTOMedicao dto = new DTOMedicao();
            dto.CodigoItem = row.ParseToString("codItem");
            dto.Descricaoitem = row.ParseToString("descItem");
            dto.VerPlano = row.ParseToString("verPlano");
            dto.CodigoCC = row.ParseToString("codCC");
            dto.DescricaoCC = row.ParseToString("descCC");
            dto.DataInicio = row.ParseToDatetime("dataInicio");
            dto.DataFim = row.ParseToDatetime("datafim");
            dto.Posicao = row.ParseToString("posicao");
            dto.Tipo = row.ParseToString("tipo");
            dto.Caracteristica = row.ParseToString("caracteristica");
            dto.Class = row.ParseToString("class");
            dto.NumeroMedicao = row.ParseToInt("numMedicao");
            dto.ValorMedido = row.ParseToString("valorMedido");
            dto.DescricaoTipo = row.ParseToString("descTipo");
            dto.Justificativa = row.ParseToString("justificativa");
            dto.Observacao = row.ParseToString("obs");
            dto.DataMedicao = row.ParseToDatetime("dataMedicao");
            dto.CodigoOperacao = row.ParseToString("codOP");
            dto.Limite = row.ParseToString("limite");
            return dto;
        }

        public Dictionary<string, object> ParseToParameters(DTOMedicao t)
        {
            throw new NotImplementedException();
        }

        public DTOMedicao SaveUpdate(DTOMedicao t)
        {
            throw new NotImplementedException();
        }
    }
}
