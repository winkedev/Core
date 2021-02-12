using Microsoft.AspNetCore.Mvc;

namespace Br.Com.SPI.Jos.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {
        [HttpGet]
        [Route("testconnection")]
        public void TestConnection()
        {
        }
    }
}
