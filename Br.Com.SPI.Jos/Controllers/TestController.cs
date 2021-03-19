using Br.Com.SPI.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Br.Com.SPI.Jos.Controllers
{
    [Route("api/test")]
    public class TestController : CustomController
    {
        [HttpGet]
        [Route("getpdf")]
        public async Task<IActionResult> GetPDF()
        {
            var resp = await new Teste().GetBase64StringAsync();
            return this.WriteSucess(resp);
        }
        [HttpGet]
        [Route("getstring")]
        public async Task<IActionResult> GetString()
        {
            var resp = await new Teste().GetBase64String();
            return this.WriteSucess(resp);
        }

    }
}
