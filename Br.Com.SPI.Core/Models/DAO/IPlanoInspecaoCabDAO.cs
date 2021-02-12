using System.Collections.Generic;

namespace Br.Com.SPI.Core.Models.DAO
{
    public interface IPlanoInspecaoCabDAO: IDAO<PlanoInspecaoCab>
    {
        List<PlanoInspecaoCab> GetAll();
    }
}
