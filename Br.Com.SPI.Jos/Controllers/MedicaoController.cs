using Br.Com.SPI.Core.Models.DAO;
using Br.Com.SPI.Core.Models.DTO;
using Br.Com.SPI.Jos.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Br.Com.SPI.Jos.Controllers
{
    [Route("api/medicao")]
    public class MedicaoController : CustomController
    {
        [HttpPost]
        [Route("getby")]
        [CheckModel]
        public IActionResult GetMedicaoBy([FromServices] DAOFactory dao, [FromBody] DTOMedicao dto)
        {
            List<DTOMedicao> list = dao.InitDTOMedicaoDAO().GetMedicaoBy(dto.CT, dto.CodigoItem, dto.CodigoOperacao, dto.PlanoPadraoVersao, dto.PlanoPadrao, dto.DataInicio, dto.DataFim);

            return list != null && list.Any() ? this.WriteSucess(list) : this.WriteErrorInfo("Erro ao recuperar medicoes"); 
        }

        [HttpPost]
        [Route("getItemReprovadoBy")]
        [CheckModel]
        public IActionResult GetItemReprovadoBy([FromServices] DAOFactory dao, [FromBody] DTOMedicao dto)
        {
            List<DTOMedicao> list = dao.InitDTOMedicaoDAO().GetItemReprovadoBy(dto.CT, dto.CodigoItem, dto.CodigoOperacao, dto.PlanoPadraoVersao, dto.PlanoPadrao, dto.DataInicio, dto.DataFim);

            return list != null && list.Any() ? this.WriteSucess(list) : this.WriteErrorInfo("Erro ao recuperar itens reprovados.");
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll([FromServices] DAOFactory dao)
        {
            List<DTOMedicao> list = dao.InitDTOMedicaoDAO().GetAll();

            return list != null && list.Any() ? this.WriteSucess(list) : this.WriteErrorInfo("Erro ao recuperar medicoes");
        }

        [HttpPost]
        [Route("updateall")]
        public IActionResult SaveAll([FromServices] DAOFactory dao, [FromBody] List<DTOMedicao> list)
        {
            if(list == null || !list.Any())
            {
                return this.WriteErrorInfo("Lista não pode ser vazia.");
            }

            bool result = dao.InitDTOMedicaoDAO().UpdateAll(list);

            return result ? this.WriteSucessInfo("Lista atualizada com sucesso.") : this.WriteErrorInfo("Erro ao atualizar lista.");
        }
    }
}
