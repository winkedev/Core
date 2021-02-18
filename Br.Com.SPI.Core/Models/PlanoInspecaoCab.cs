using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Br.Com.SPI.Core.Models
{
    public class PlanoInspecaoCab : Abstract
    {
        public Int64 ID { get; set; }

        public string CodigoItem { get; set; }

        public string DescricaoItem { get; set; }

        public string VerPlano { get; set; }

        public string CodigoCC { get; set; }

        public string DescricaoCC { get; set; }

        public string PlanoPadrao { get; set; }

        public DateTime DataRI { get; set; }

        [XmlElement("DataMedicaoShort"), JsonPropertyName("dataMedicaoShort")]
        public string DataMedicaoShort { get => DataRI.ToShortDateString(); set => this.DataMedicaoShort = value; }


        [XmlElement("CodigoCCAndDescricaoCC"), JsonPropertyName("codigoCCAndDescricaoCC")]
        public string CodigoCCAndDescricaoCC { get => string.Concat(CodigoCC, " ", DescricaoCC); set => this.CodigoCCAndDescricaoCC = value; }

        public List<PlanoInspecaoCaract> PlanoInspecaoCaract { get; set; }

        public List<MedicaoCab> MedicaoCab { get; set; }
    }
}
