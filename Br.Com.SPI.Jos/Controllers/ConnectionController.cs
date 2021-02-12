using Br.Com.SPI.Core.Models.DAO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Br.Com.SPI.Jos.Controllers
{
    [Route("api/connection")]
    public class ConnectionController : CustomController
    {
        [HttpGet]
        [Route("test")]
        public IActionResult TestConnection([FromServices] IConnectionDAO dao)
        {
            try
            {
                return dao.TestConnection() ? this.WriteSucessInfo("Teste realizado com sucesso") : this.WriteErrorInfo("Erro ao realizar teste");
            }
            catch (Exception ex)
            {
                return this.WriteErrorInfo(ex.Message);
            }
        }
    }
}
