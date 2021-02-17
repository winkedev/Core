using System;

namespace Br.Com.SPI.Core.Models.DAO
{
    public interface ITipoMedicaoDAO : IDAO<TipoMedicao>
    {
        public TipoMedicao GetTipoMedicaoByID(Int64 id);
    }
}
