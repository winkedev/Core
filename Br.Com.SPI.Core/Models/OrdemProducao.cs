using System;

namespace Br.Com.SPI.Core.Models
{
    public class OrdemProducao : Abstract
    {

        public Int64 ID { get; set; }

        public string CodigoOp { get; set; }

        public string CodigoItem { get; set; }

        public string CodigoCC { get; set; }
        
        public string Dispositivo { get; set; }

        public int QuantidadePrevista { get; set; }

        public int QuantidadeProduzida { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public int Status { get; set; }

        public DateTime DataRI { get; set; }

    }
}
