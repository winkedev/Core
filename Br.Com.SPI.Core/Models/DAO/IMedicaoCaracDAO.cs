using System.Collections.Generic;

namespace Br.Com.SPI.Core.Models.DAO
{
    public interface IMedicaoCaracDAO : IDAO<MedicaoCaract>
    {

        public List<MedicaoCaract> GetMedicaoCaracByMedicaoCab(MedicaoCab cab);

        public List<MedicaoCaract> GetMedicaoCaracByPlanoInspecaoCarac(PlanoInspecaoCaract plano);

    }
}
