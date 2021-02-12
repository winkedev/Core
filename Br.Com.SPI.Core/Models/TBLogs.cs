using System;

namespace Br.Com.SPI.Core.Models
{
    public class TBLogs : Abstract
    {
        public Int64 ID { get; set; }

        public string NumeroOperacao { get; set; }

        public string DescricaoOperacao { get; set; }

        public string NumeroUsuario { get; set; }

        public DateTime DataRegistro { get; set; }
    }
}
