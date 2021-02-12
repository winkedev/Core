using Microsoft.AspNetCore.Mvc;

namespace Br.Com.SPI.Jos.Controllers
{
    public abstract class CustomController : Controller
    {
        private class RESTMessage
        {
            private RESTMessage()
            {

            }

            public object Data { get; private set; }

            public bool Sucess { get; private set; }

            public string Message { get; private set; }

            public static RESTMessage Build()
            {
                return new RESTMessage();
            }

            public RESTMessage AddData(object data)
            {
                this.Data = data;
                return this;
            }

            public RESTMessage AddSucess(bool sucess)
            {
                this.Sucess = sucess;
                return this;
            }

            public RESTMessage AddMessage(string message)
            {
                this.Message = message;
                return this;
            }

        }

        public IActionResult WriteSucess<T>(T data, string message = null)
        {
            return Json(RESTMessage.Build().AddData(data).AddSucess(true).AddMessage(message));
        }

        public IActionResult WriteError<T>(T data, string message = null)
        {
            return Json(RESTMessage.Build().AddData(data).AddSucess(false).AddMessage(message));
        }

        public IActionResult WriteSucessInfo(string message = null)
        {
            return Json(RESTMessage.Build().AddSucess(true).AddMessage(message));
        }

        public IActionResult WriteErrorInfo(string message = null)
        {
            return Json(RESTMessage.Build().AddSucess(false).AddMessage(message));
        }

    }
}
