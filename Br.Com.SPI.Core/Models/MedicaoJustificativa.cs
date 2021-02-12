using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Br.Com.SPI.Core.Models
{
    public class MedicaoJustificativa : Abstract
    {
        public Int64 ID { get; set; }

        public string Observacao { get; set; }

        public DateTime DataRI { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public MedicaoCaract MedicaoCaractParent { get; set; }

        public MotivoN2 MotivoN2Parent { get; set; }
    }
}
