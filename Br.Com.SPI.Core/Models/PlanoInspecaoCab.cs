using System;

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

        public PlanoInspecaoCaract PlanoInspecaoCaract { get; set; }
    }
}
