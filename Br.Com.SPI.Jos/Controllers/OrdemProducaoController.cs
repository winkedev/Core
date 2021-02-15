using Br.Com.SPI.Core.Models;
using Br.Com.SPI.Core.Models.DAO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Br.Com.SPI.Jos.Controllers
{
    [Route("api/ordemproducao")]
    public class OrdemProducaoController : CustomController
    {
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll([FromServices] DAOFactory dao)
        {
            List<OrdemProducao> list = dao.InitOrdemProducaoDAO().GetAll();

            return list != null && list.Any() ? this.WriteSucess(list) : this.WriteErrorInfo("Erro ao recuperar ordem de producao");
        }
    }
}
