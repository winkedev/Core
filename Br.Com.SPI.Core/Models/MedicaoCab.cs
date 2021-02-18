using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Br.Com.SPI.Core.Models
{
    public class MedicaoCab : Abstract
    {
        public Int64 ID { get; set; }

        public Int64 IDPlanoInspecaoCab { get; set; }

        public Int64 IDOrdemProducao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public DateTime DataRI { get; set; }

        [XmlElement("DataMedicaoShort"), JsonPropertyName("dataMedicaoShort")]
        public string DataMedicaoShort { get => DataRI.ToShortDateString(); set => this.DataMedicaoShort = value; }

        public List<OrdemProducao> OrdemProducao { get; set; }

        public List<MedicaoCaract> MedicaoCaract { get; set; }
    }
}
