using System;

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
    }
}
