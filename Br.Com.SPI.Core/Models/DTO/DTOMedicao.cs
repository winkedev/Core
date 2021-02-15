using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Br.Com.SPI.Core.Models.DTO
{
    public class DTOMedicao : Abstract
    {
        public string CodigoItem { get; set; }

        [XmlElement("DescricaoItem"), JsonPropertyName("descricaoItem")]
        public string Descricaoitem { get; set; }

        [XmlElement("VerPlano"), JsonPropertyName("verPlano")]
        public string VerPlano { get; set; }

        [Required(ErrorMessage = "CodigoCC não pode ser nulo.")]
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

        [XmlElement("Justificativa"), JsonPropertyName("Justificativa")]
        public string Justificativa { get; set; }

        [XmlElement("Observacao"), JsonPropertyName("observacao")]
        public string Observacao { get; set; }

        [XmlElement("DataMedicao"), JsonPropertyName("dataMedicao")]
        public DateTime DataMedicao { get; set; }

        [XmlElement("DataMedicaoShort"), JsonPropertyName("dataMedicaoShort")]
        public string DataMedicaoShort { get => DataMedicao.ToShortDateString(); set => this.DataMedicaoShort = value; }

        [XmlElement("CodigoOperacao"), JsonPropertyName("codigoOperacao")]
        public string CodigoOperacao { get; set; }

        [XmlElement("Limite"), JsonPropertyName("limite")]
        public string Limite { get; set; }

        [XmlElement("CodigoCCAndDescricaoCC"), JsonPropertyName("codigoCCAndDescricaoCC")]
        public string CodigoCCAndDescricaoCC { get => string.Concat(CodigoCC, " ", DescricaoCC); set => this.CodigoCCAndDescricaoCC = value; }
    }
}
