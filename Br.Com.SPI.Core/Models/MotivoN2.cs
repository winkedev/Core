using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Br.Com.SPI.Core.Models
{
    public class MotivoN2 : Abstract
    {
        public Int64 ID { get; set; }

        public string Descricao { get; set; }

        public DateTime DataRI { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public MotivoN1 MotivoN1Parent { get; set; }
    }
}
