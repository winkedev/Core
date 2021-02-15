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
            List<DTOMedicao> list = dao.InitDTOMedicaoDAO().GetMedicaoBy(dto.CodigoCC, dto.Descricaoitem, dto.CodigoOperacao, dto.DataInicio, dto.DataFim);

            return list != null && list.Any() ? this.WriteSucess(list) : this.WriteErrorInfo("Erro ao recuperar medicoes"); 
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll([FromServices] DAOFactory dao)
        {
            List<DTOMedicao> list = dao.InitDTOMedicaoDAO().GetAll();

            return list != null && list.Any() ? this.WriteSucess(list) : this.WriteErrorInfo("Erro ao recuperar medicoes");
        }
    }
}
