using Br.Com.SPI.Core.Models.DTO;
using System;
using System.Collections.Generic;

namespace Br.Com.SPI.Core.Models.DAO
{
    public interface IDTOMedicao : IDAO<DTOMedicao>
    {
        /// <summary>
        /// Gel all medicao
        /// </summary>
        /// <returns></returns>
        List<DTOMedicao> GetAll();

        /// <summary>
        /// Get medição by codigoCC, descricaoItem, codigoOP, dataInicial, dataFinal
        /// </summary>
        /// <param name="codigoCC"></param>
        /// <param name="descricaoItem"></param>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <param name="codigoOP"></param>
        /// <returns></returns>
        List<DTOMedicao> GetMedicaoBy(string ct, string descricaoItem, string codigoOP, string planoPadraoVersao, DateTime dataInicial, DateTime dataFinal);

        bool UpdateAll(List<DTOMedicao> list);
    }
}
