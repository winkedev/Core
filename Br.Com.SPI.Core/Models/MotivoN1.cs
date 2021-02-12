using System;

namespace Br.Com.SPI.Core.Models
{
    public class MotivoN1 : Abstract
    {
        public Int64 ID { get; set; }

        public string Descricao { get; set; }

        public DateTime DataRI { get; set; }

        public MotivoN2 MotivoN2 { get; set; }
    }
}
