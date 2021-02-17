using System;
using System.Collections.Generic;
using System.Text;

namespace Br.Com.SPI.Core.Models.DAO
{
    public interface IMedicaoCabDAO : IDAO<MedicaoCab>
    {
        public List<MedicaoCab> GetMedicaoCabByPlanoInspecaoCab(PlanoInspecaoCab cab);
    }
}
