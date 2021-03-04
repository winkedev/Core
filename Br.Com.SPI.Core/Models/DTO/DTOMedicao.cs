using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Br.Com.SPI.Core.Models.DTO
{
    public class DTOMedicao : Abstract
    {
        [XmlElement("Row"), JsonPropertyName("row")]
        public Int64 Row { get; set; }

        [XmlElement("IDPlanoInspecaoCAB"), JsonPropertyName("idPlanoInspecaoCAB")]
        public Int64 IDPlanoInspecaoCAB { get; set; }

        [XmlElement("IDPlanoInspecaoCarac"), JsonPropertyName("idPlanoInspecaoCarac")]
        public Int64 IDPlanoInspecaoCarac { get; set; }

        [XmlElement("IDMedicaoCab"), JsonPropertyName("idMedicaoCab")]
        public Int64 IDMedicaoCab { get; set; }

        [XmlElement("IDMedicaoCarac"), JsonPropertyName("idMedicaoCarac")]
        public Int64 IDMedicaoCarac { get; set; }

        [XmlElement("IDTipoMedicao"), JsonPropertyName("idTipoMedicao")]
        public Int64 IDTipoMedicao { get; set; }

        [XmlElement("IDMotivoN1"), JsonPropertyName("idMotivoN1")]
        public Int64 IDMotivoN1 { get; set; }

        [XmlElement("IDMotivoN2"), JsonPropertyName("idMotivoN2")]
        public Int64 IDMotivoN2 { get; set; }

        [XmlElement("IDOrdemProducao"), JsonPropertyName("idOrdemProducao")]
        public Int64 IDOrdemProducao { get; set; }

        [XmlElement("CodigoItem"), JsonPropertyName("codigoItem")]
        public string CodigoItem { get; set; }

        [Required(ErrorMessage = "DescricaoItem não pode ser nulo.")]
        [XmlElement("DescricaoItem"), JsonPropertyName("descricaoItem")]
        public string Descricaoitem { get; set; }

        [XmlElement("VerPlano"), JsonPropertyName("verPlano")]
        public string VerPlano { get; set; }

        [XmlElement("PlanoPadraoVersao"), JsonPropertyName("planoPadraoVersao")]
        public string PlanoPadraoVersao { get; set; }

        [XmlElement("CT"), JsonPropertyName("ct")]
        public string CT { get; set; }

        [XmlElement("CodigoCC"), JsonPropertyName("codigoCC")]
        public string CodigoCC { get; set; }

        [XmlElement("DescricaoCC"), JsonPropertyName("descricaoCC")]
        public string DescricaoCC { get; set; }

        [XmlElement("DataInicio"), JsonPropertyName("dataInicio")]
        public DateTime DataInicio { get; set; }

        [XmlElement("DataFim"), JsonPropertyName("dataFim")]
        public DateTime DataFim { get; set; }

        [XmlElement("Posicao"), JsonPropertyName("posicao")]
        public string Posicao { get; set; }

        [XmlElement("Tipo"), JsonPropertyName("tipo")]
        public string Tipo { get; set; }

        [XmlElement("Caracteristica"), JsonPropertyName("caracteristica")]
        public string Caracteristica { get; set; }

        [XmlElement("class"), JsonPropertyName("class")]
        public string Class { get; set; }

        [XmlElement("NumeroMedicao"), JsonPropertyName("numeroMedicao")]
        public int NumeroMedicao { get; set; }

        [XmlElement("ValorMedido"), JsonPropertyName("valorMedido")]
        public string ValorMedido { get; set; }

        [XmlElement("DescricaoTipo"), JsonPropertyName("descricaoTipo")]
        public string DescricaoTipo { get; set; }

        [XmlElement("Justificativa"), JsonPropertyName("justificativa")]
        public string Justificativa { get; set; }

        [XmlElement("DataMedicao"), JsonPropertyName("dataMedicao")]
        public DateTime DataMedicao { get; set; }

        [XmlElement("DataMedicaoShort"), JsonPropertyName("dataMedicaoShort")]
        public string DataMedicaoShort { get => DataMedicao.ToString(@"dd/MM/yyyy HH:mm:ss"); set => this.DataMedicaoShort = value; }

        [XmlElement("CodigoOperacao"), JsonPropertyName("codigoOperacao")]
        public string CodigoOperacao { get; set; }

        [XmlElement("Limite"), JsonPropertyName("limite")]
        public string Limite { get; set; }

        [XmlElement("CodigoCCAndDescricaoCC"), JsonPropertyName("codigoCCAndDescricaoCC")]
        public string CodigoCCAndDescricaoCC { get => string.Concat(CodigoCC, " ", DescricaoCC); set => this.CodigoCCAndDescricaoCC = value; }

        [XmlElement("NumeroMatricula"), JsonPropertyName("numeroMatricula")]
        public string NumeroMatricula { get; set; }

        [XmlElement("LimiteInferior"), JsonPropertyName("limiteInferior")]
        public decimal LimiteInferior { get; set; }

        [XmlElement("LimiteSuperior"), JsonPropertyName("limiteSuperior")]
        public decimal LimiteSuperior { get; set; }

        [XmlElement("TipoCaracteristica"), JsonPropertyName("tipoCaracteristica")]
        public string TipoCaracteristica { get; set; }

        [XmlElement("RelN"), JsonPropertyName("relN")]
        public string RelN { get; set; }

        [XmlElement("DSV"), JsonPropertyName("dsv")]
        public string DSV { get; set; }
    }
}
