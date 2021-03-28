using Br.Com.SPI.Core.Extensions;
using Br.Com.SPI.Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Br.Com.SPI.Core.Models.DAO
{
    internal sealed class DTOMedicaoDAOImpl : DAOImpl, IDTOMedicao
    {
        public List<DTOMedicao> GetAll()
        {
            List<DTOMedicao> list = new List<DTOMedicao>();
            
            using (DataTable dt = this.GetDataTable("spConsultaMedicao"))
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(this.ParseToDTO(row));
                }
            }

            return list;
        }

        public List<DTOMedicao> GetMedicaoBy(string ct, string codigoItem, string codigoOP, string planoPadraoVersao, string planoPadrao, DateTime dataInicial, DateTime dataFinal)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                { "CT", this.GetValueOrDbNull(ct) },
                { "CODIGOITEM", this.GetValueOrDbNull(codigoItem)},
                { "CODIGOOP", this.GetValueOrDbNull(codigoOP)},
                { "PPVERSAO", this.GetValueOrDbNull(planoPadraoVersao)},
                { "PP", this.GetValueOrDbNull(planoPadrao)},
                { "DATAINICIAL", this.GetValueOrDbNull(dataInicial)},
                { "DATAFINAL", this.GetValueOrDbNull(dataFinal)},
            };

            List<DTOMedicao> list = new List<DTOMedicao>();

            using (var dt = this.GetDataTable("spConsultaMedicaoBy @CT, @CODIGOITEM, @CODIGOOP, @PPVERSAO, @PP, @DATAINICIAL, @DATAFINAL", dic))
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(this.ParseToDTO(row));
                }
            }

            return list;
        }

        public List<DTOMedicao> GetItemReprovadoBy(string ct, string codigoItem, string codigoOP, string planoPadraoVersao, string planoPadrao, DateTime dataInicial, DateTime dataFinal)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                { "CT", this.GetValueOrDbNull(ct) },
                { "CODIGOITEM", this.GetValueOrDbNull(codigoItem)},
                { "CODIGOOP", this.GetValueOrDbNull(codigoOP)},
                { "PPVERSAO", this.GetValueOrDbNull(planoPadraoVersao)},
                { "PP", this.GetValueOrDbNull(planoPadrao) },
                { "DATAINICIAL", this.GetValueOrDbNull(dataInicial)},
                { "DATAFINAL", this.GetValueOrDbNull(dataFinal)},
            };

            List<DTOMedicao> list = new List<DTOMedicao>();

            using (var dt = this.GetDataTable("spConsultaItemReprovadoBy @CT, @CODIGOITEM, @CODIGOOP, @PPVERSAO, @PP, @DATAINICIAL, @DATAFINAL", dic))
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(this.ParseToDTO(row));
                }
            }

            return list;
        }

        public DTOMedicao Delete(DTOMedicao t)
        {
            throw new NotImplementedException();
        }

        public DTOMedicao ParseToDTO(DataRow row)
        {
            DTOMedicao dto = new DTOMedicao();
            dto.Row = row.ParseToInt64("row");
            dto.CodigoItem = row.ParseToString("codItem");
            dto.Descricaoitem = row.ParseToString("descItem");
            dto.VerPlano = row.ParseToString("verPlano");
            dto.PlanoPadraoVersao = row.ParseToString("planoPadraoVersao");
            dto.PlanoPadrao = row.ParseToString("planoPadrao");
            dto.CodigoCC = row.ParseToString("codCC");
            dto.CT = row.ParseToString("ct");
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
            dto.DataMedicao = row.ParseToDatetime("dataMedicao");
            dto.CodigoOperacao = row.ParseToString("codOP");
            dto.Limite = row.ParseToString("limite");
            dto.IDMedicaoCab = row.ParseToInt64("IDMedicaoCab");
            dto.IDMedicaoCarac = row.ParseToInt64("IDMedicaoCarac");
            dto.IDMotivoN1 = row.ParseToInt64("IDMotivoN1");
            dto.IDMotivoN2 = row.ParseToInt64("IDMotivoN2");
            dto.IDOrdemProducao = row.ParseToInt64("IDOrdemProducao");
            dto.IDPlanoInspecaoCAB = row.ParseToInt64("IDPlanoInspecaoCAB");
            dto.IDPlanoInspecaoCarac = row.ParseToInt64("IDPlanoInspecaoCarac");
            dto.IDTipoMedicao = row.ParseToInt64("IDTipoMedicao");
            dto.NumeroMatricula = row.ParseToString("numMatricula");
            dto.LimiteInferior = row.ParseToDecimal("limInf");
            dto.LimiteSuperior = row.ParseToDecimal("limSup");
            dto.TipoCaracteristica = row.ParseToString("tipoCarac");
            dto.RelN = row.ParseToString("relN");
            dto.DSV = row.ParseToString("DSV");
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

        public bool UpdateAll(List<DTOMedicao> list)
        {
            Parallel.ForEach(list, (dto) => new DAOFactory().InitMedicaoCaracDAO()
            .UpdateValorMedido(dto.IDMedicaoCarac, dto.ValorMedido));

            return true;
        }
    }
}
