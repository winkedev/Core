using Br.Com.SPI.Core.Models;
using Br.Com.SPI.Core.Models.DAO;
using Br.Com.SPI.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Br.Com.SPI.Jos.Controllers
{
    [Route("api/planoinspecao")]
    public class PlanoInspecaoController : CustomController
    {
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll([FromServices] IPlanoInspecaoCabDAO dao)
        {
            List<PlanoInspecaoCab> list = dao.GetAll();

            return list != null && list.Any() ? this.WriteSucess(list) : this.WriteErrorInfo("Erro ao recuperar Plano de inspecao");
        }
    }
}
