using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Br.Com.SPI.Core.Models.DTO
{
    public class DTOPlanoInspecao : PlanoInspecaoCab
    {
        [XmlElement("CodigoOP"), JsonPropertyName("codigoOP")]
        public string CodigoOP { get; set; }
    }
}
