using Br.Com.SPI.Core.Models;
using Br.Com.SPI.Core.Models.DAO;
using Br.Com.SPI.Core.Models.DTO;
using Br.Com.SPI.Core.Utils;
using Br.Com.SPI.Jos.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Br.Com.SPI.Jos.Controllers
{
    [Route("api/planoinspecao")]
    public class PlanoInspecaoController : CustomController
    {
        private const string DEFAULT_ERROR_MESSAGE = "Erro ao recuperar Plano de inspecao";

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll([FromServices] DAOFactory dao)
        {
            List<PlanoInspecaoCab> list = dao.InitPlanoInspecaoCabDAO().GetAll();

            return list != null && list.Any() ? this.WriteSucess(list) : this.WriteErrorInfo(DEFAULT_ERROR_MESSAGE);
        }

        [HttpGet]
        [Route("getallcodcc")]
        public IActionResult GetAllCodCC([FromServices] DAOFactory dao)
        {
            List<PlanoInspecaoCab> list = dao.InitPlanoInspecaoCabDAO().GetAllCodigoCC();

            return list != null && list.Any() ? this.WriteSucess(list) : this.WriteErrorInfo(DEFAULT_ERROR_MESSAGE);
        }

        [HttpGet]
        [Route("getallcoditem")]
        public IActionResult GetAllCodItem([FromServices] DAOFactory dao)
        {
            List<PlanoInspecaoCab> list = dao.InitPlanoInspecaoCabDAO().GetAllCodigoItem();

            return list != null && list.Any() ? this.WriteSucess(list) : this.WriteErrorInfo(DEFAULT_ERROR_MESSAGE);
        }

        [HttpGet]
        [Route("getallversaopp")]
        public IActionResult GetAllVersaoPlanoPadrao([FromServices] DAOFactory dao)
        {
            List<PlanoInspecaoCab> list = dao.InitPlanoInspecaoCabDAO().GetAllVersaoPlanoPadrao();

            return list != null && list.Any() ? this.WriteSucess(list, "Dados recuperados com sucesso.") : this.WriteErrorInfo(DEFAULT_ERROR_MESSAGE);
        }

        [HttpGet]
        [Route("getallplanopadrao")]
        public IActionResult GetAllPlanoPadrao([FromServices] DAOFactory dao)
        {
            List<PlanoInspecaoCab> list = dao.InitPlanoInspecaoCabDAO().GetAllPlanoPadrao();

            return list != null && list.Any() ? this.WriteSucess(list, "Dados recuperados com sucesso.") : this.WriteErrorInfo(DEFAULT_ERROR_MESSAGE);
        }

        [HttpPost]
        [Route("getby")]
        [CheckModel]
        public IActionResult GetPlanoInspecaoBy([FromServices] DAOFactory dao, [FromBody] DTOMedicao dto)
        {
            List<DTOPlanoInspecao> list = dao.InitPlanoInspecaoCabDAO().GetPlanoInspecaoCabBy(dto.CT, dto.CodigoItem, dto.CodigoOperacao, dto.PlanoPadraoVersao, dto.PlanoPadrao, dto.DataInicio, dto.DataFim);

            return list != null && list.Any() ? this.WriteSucess(list) : this.WriteErrorInfo(DEFAULT_ERROR_MESSAGE);
        }

        [HttpPost]
        [Route("getreprovadoby")]
        [CheckModel]
        public IActionResult GetPlanoInpecaoReprovadoBy([FromServices] DAOFactory dao, [FromBody] DTOMedicao dto)
        {
            List<DTOPlanoInspecao> list = dao.InitPlanoInspecaoCabDAO().GetPlanoInspecaoCabReprovadoBy(dto.CT, dto.CodigoItem, dto.CodigoOperacao, dto.PlanoPadraoVersao, dto.PlanoPadrao, dto.DataInicio, dto.DataFim);

            return list != null && list.Any() ? this.WriteSucess(list) : this.WriteErrorInfo(DEFAULT_ERROR_MESSAGE);
        }
    }
}
