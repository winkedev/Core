using Br.Com.SPI.Core.Models;
using Br.Com.SPI.Core.Models.DAO;
using Br.Com.SPI.Jos.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Br.Com.SPI.Jos.Controllers
{
    [Route("api/motivo")]
    public class MotivoController : CustomController
    {
        
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll([FromServices] DAOFactory dao)
        {
            List<MotivoN1> list = dao.InitMotivoN1DAO().GetAll();
            return this.WriteSucess(list, "dados retornados com sucesso.");

        }


        [HttpPost]
        [Route("saveupdate")]
        [CheckModel]
        public IActionResult SaveUpdate([FromServices] DAOFactory dao, [FromBody] MotivoN1 motivo)
        {
            MotivoN1 result = dao.InitMotivoN1DAO().SaveUpdate(motivo);
            return this.WriteSucess(result);
        }

        [HttpPost]
        [Route("deleteN1")]
        public IActionResult DeleteMotivoN1([FromServices] DAOFactory dao, [FromBody] MotivoN1 motivo)
        {
            if (motivo.ID <= 0)
            {
                return this.WriteErrorInfo("Erro ao deletar MotivoN1, ID não pode ser nulo.");
            }

            try
            {
                var result = dao.InitMotivoN1DAO().Delete(motivo);

                return this.WriteSucess(result);
            }
            catch (Exception ex)
            {
                return this.WriteErrorInfo(ex?.Message);
            }
            
        }

        [HttpPost]
        [Route("deleteN2")]
        public IActionResult DeleteMotivoN2([FromServices] DAOFactory dao, [FromBody] MotivoN2 motivo)
        {
            if (motivo.ID <= 0)
            {
                return this.WriteErrorInfo("Erro ao deletar MotivoN2, ID não pode ser nulo.");
            }

            try
            {
                var result = dao.InitMotivoN2DAO().Delete(motivo);

                return this.WriteSucess(result);
            }
            catch (Exception ex)
            {
                return this.WriteErrorInfo(ex?.Message);
            }
            
        }

    }
}
