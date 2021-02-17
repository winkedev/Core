using System.Collections.Generic;

namespace Br.Com.SPI.Core.Models.DAO
{
    public interface IPlanoInspecaoCaracDAO : IDAO<PlanoInspecaoCaract>
    {
        public List<PlanoInspecaoCaract> GetPlanoInspecaoCaracByPlanoInspecaoCab(PlanoInspecaoCab cab);
    }
}
