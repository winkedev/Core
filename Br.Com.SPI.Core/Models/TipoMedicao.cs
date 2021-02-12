using System;

namespace Br.Com.SPI.Core.Models
{
    public class TipoMedicao : Abstract
    {
        public Int64 ID { get; set; }

        public string DescricaoTipo { get; set; }

        public DateTime DataRI { get; set; }
    }
}
