using Br.Com.SPI.Core.Models;
using Br.Com.SPI.Core.Models.DAO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Br.Com.SPI.Jos.Controllers
{
    [Route("api/motivo")]
    public class MotivoController : CustomController
    {
        
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll([FromServices] IMotivoN1DAO dao)
        {
            List<MotivoN1> list = dao.GetAll();
            return this.WriteSucess(list, "dados retornados com sucesso.");

        }

    }
}
