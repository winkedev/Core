using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Br.Com.SPI.Core.Models
{
    public class PlanoInspecaoCaract : Abstract
    {
        public Int64 ID { get; set; }

        public string Posicao { get; set; }

        public string Tipo { get; set; }

        public string Caracteristica { get; set; }

        public string Classe { get; set; }

        public int QuantidadeMedicoes { get; set; }

        public decimal LimInf { get; set; }

        public decimal LimSup { get; set; }

        public string TipoCarac { get; set; }

        public string Observacao { get; set; }

        public string MetodoAvaliacao { get; set; }

        public int QuantidadeMedicoesInicio { get; set; }

        public int QuantidadeMedicoesFinal { get; set; }

        public int FatorMedicoes { get; set; }

        public DateTime DataRI { get; set; }

        public List<MedicaoCaract> MedicaoCaract { get; set; }

    }
}
