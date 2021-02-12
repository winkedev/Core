using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Br.Com.SPI.Core.Models
{
    public class MedicaoCaract : Abstract
    {
        public Int64 ID { get; set; }

        public int NumeroMedicao { get; set; }

        public string ValorMedido { get; set; }

        public int NumeroMatricula { get; set; }

        public DateTime DataMedicao { get; set; }

        public DateTime DataRI { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public PlanoInspecaoCaract PlanoInspecaoCaractParent { get; set; }

        public MedicaoCab MedicaoCab { get; set; }

        public TipoMedicao TipoMedicao { get; set; }

        public MedicaoJustificativa MedicaoJustificativa { get; set; }
    }
}
