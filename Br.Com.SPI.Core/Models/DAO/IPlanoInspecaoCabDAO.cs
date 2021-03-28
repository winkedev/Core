using Br.Com.SPI.Core.Models.DTO;
using System;
using System.Collections.Generic;

namespace Br.Com.SPI.Core.Models.DAO
{
    public interface IPlanoInspecaoCabDAO: IDAO<PlanoInspecaoCab>
    {
        List<PlanoInspecaoCab> GetAll();

        List<PlanoInspecaoCab> GetAllCodigoCC();

        List<PlanoInspecaoCab> GetAllCodigoItem();

        List<PlanoInspecaoCab> GetAllVersaoPlanoPadrao();

        List<PlanoInspecaoCab> GetAllPlanoPadrao();

        List<DTOPlanoInspecao> GetPlanoInspecaoCabBy(string ct, string codigoItem, string codigoOP, string planoPadraoVersao, string planoPadrao, DateTime dataInicial, DateTime dataFinal);
    }
}
