using System;

namespace Br.Com.SPI.Core.Models
{
    public class ParadaMedicao : Abstract
    {
        public Int64 ID { get; set; }

        public string NumeroParada { get; set; }

        public int QuantidadePecas { get; set; }

        public DateTime DataRI { get; set; }
    }
}
