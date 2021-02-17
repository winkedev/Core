using System;
using System.Collections.Generic;

namespace Br.Com.SPI.Core.Models.DAO
{
    public interface IPlanoInspecaoCabDAO: IDAO<PlanoInspecaoCab>
    {
        List<PlanoInspecaoCab> GetAll();

        List<PlanoInspecaoCab> GetPlanoInspecaoCabBy(string codigoCC, string descricaoItem, string codigoOP, DateTime dataInicial, DateTime dataFinal);
    }
}
