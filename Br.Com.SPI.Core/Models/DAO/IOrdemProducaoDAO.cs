using System.Collections.Generic;

namespace Br.Com.SPI.Core.Models.DAO
{
    public interface IOrdemProducaoDAO : IDAO<OrdemProducao>
    {
        List<OrdemProducao> GetAll();
    }
}
