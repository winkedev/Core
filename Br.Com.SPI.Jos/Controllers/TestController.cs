using Br.Com.SPI.Core;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
        [Route("getpdf2")]
        public async Task<IActionResult> GetPDF2()
        {
            var resp = await new Teste().Get2Base64StringAsync();
            return this.WriteSucess(resp);
        }

        [HttpGet]
        [Route("getstring")]
        public async Task<IActionResult> GetString()
        {
            var resp = await new Teste().GetBase64String();
            return this.WriteSucess(resp);
        }

        [HttpGet]
        [Route("generate")]
        public IActionResult AsyncGenerateQRCode()
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode("some text", QRCodeGenerator.ECCLevel.Q);
            QRCode q = new QRCode(data);

            Bitmap b = q.GetGraphic(20);
            byte[] bytes;

            using (MemoryStream stream = new MemoryStream())
            {
                b.Save(stream, ImageFormat.Png);
                bytes = stream.ToArray();
            }

            string base64 = Convert.ToBase64String(bytes);
            return this.WriteSucess(base64);
        }

    }
}
