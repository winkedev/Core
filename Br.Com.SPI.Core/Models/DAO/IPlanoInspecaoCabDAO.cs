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

        List<DTOPlanoInspecao> GetPlanoInspecaoCabBy(string ct, string descricaoItem, string codigoOP, string planoPadraoVersao, DateTime dataInicial, DateTime dataFinal);
    }
}
