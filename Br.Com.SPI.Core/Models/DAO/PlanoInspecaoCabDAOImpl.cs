using Br.Com.SPI.Core.Extensions;
using Br.Com.SPI.Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace Br.Com.SPI.Core.Models.DAO
{
    internal sealed class PlanoInspecaoCabDAOImpl : DAOImpl, IPlanoInspecaoCabDAO
    {
        public List<PlanoInspecaoCab> GetAll()
        {
            List<PlanoInspecaoCab> list = new List<PlanoInspecaoCab>();

            using (DataTable dt = this.GetDataTable("spGetPlanoInspecaoCab"))
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(this.ParseToDTO(row));
                }
            }

            return list;
        }

        public List<PlanoInspecaoCab> GetAllCodigoCC()
        {
            List<PlanoInspecaoCab> list = new List<PlanoInspecaoCab>();

            using (DataTable dt = this.GetDataTable("spGetPlanoInspecaoCabCodigoCC"))
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(this.ParseToDTO(row));
                }
            }

            return list;
        }

        public List<PlanoInspecaoCab> GetAllCodigoItem()
        {
            List<PlanoInspecaoCab> list = new List<PlanoInspecaoCab>();

            using (DataTable dt = this.GetDataTable("spGetPlanoInspecaoCabCodigoItem"))
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(this.ParseToDTO(row));
                }
            }

            return list;
        }

        public List<PlanoInspecaoCab> GetAllVersaoPlanoPadrao()
        {
            List<PlanoInspecaoCab> list = new List<PlanoInspecaoCab>();

            using (DataTable dt = this.GetDataTable("spGetPlanoInspecaoCabVersaoPlanoPadrao"))
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(this.ParseToDTO(row));
                }
            }

            return list;
        }

        public List<PlanoInspecaoCab> GetAllPlanoPadrao()
        {
            List<PlanoInspecaoCab> list = new List<PlanoInspecaoCab>();

            using (DataTable dt = this.GetDataTable("spGetPlanoInspecaoCabPlanoPadrao"))
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(this.ParseToDTO(row));
                }
            }

            return list;
        }

        public List<DTOPlanoInspecao> GetPlanoInspecaoCabBy(string ct, string codigoItem, string codigoOP, string planoPadraoVersao, string planoPadrao, DateTime dataInicial, DateTime dataFinal)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                { "CT", this.GetValueOrDbNull(ct) },
                { "CODIGOITEM", this.GetValueOrDbNull(codigoItem) },
                { "CODIGOOP", this.GetValueOrDbNull(codigoOP) },
                { "PPVERSAO", this.GetValueOrDbNull(planoPadraoVersao) },
                { "PP", this.GetValueOrDbNull(planoPadrao)},
                { "DATAINICIAL", this.GetValueOrDbNull(dataInicial) },
                { "DATAFINAL", this.GetValueOrDbNull(dataFinal) }
            };

            List<DTOPlanoInspecao> list = new List<DTOPlanoInspecao>();

            using (DataTable dt = this.GetDataTable("spGetPlanoInspecaoCabBy @CT, @CODIGOITEM, @CODIGOOP, @PPVERSAO, @PP, @DATAINICIAL, @DATAFINAL", dic))
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(this.ParseToSimpleDTO(row));
                }
            }

            return list;
        }

        public List<DTOPlanoInspecao> GetPlanoInspecaoCabReprovadoBy(string ct, string codigoItem, string codigoOP, string planoPadraoVersao, string planoPadrao, DateTime dataInicial, DateTime dataFinal)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                { "CT", this.GetValueOrDbNull(ct) },
                { "CODIGOITEM", this.GetValueOrDbNull(codigoItem) },
                { "CODIGOOP", this.GetValueOrDbNull(codigoOP) },
                { "PPVERSAO", this.GetValueOrDbNull(planoPadraoVersao) },
                { "PP", this.GetValueOrDbNull(planoPadrao)},
                { "DATAINICIAL", this.GetValueOrDbNull(dataInicial) },
                { "DATAFINAL", this.GetValueOrDbNull(dataFinal) }
            };

            List<DTOPlanoInspecao> list = new List<DTOPlanoInspecao>();
            using (DataTable dt = this.GetDataTable("spGetPlanoInspecaoCabReprovadoBy @CT, @CODIGOITEM, @CODIGOOP, @PPVERSAO, @PP, @DATAINICIAL, @DATAFINAL", dic))
            {
                foreach(DataRow row in dt.Rows)
                {
                    list.Add(this.ParseToSimpleDTO(row));
                }
            }

            return list;
        }

        public PlanoInspecaoCab Delete(PlanoInspecaoCab t)
        {
            throw new NotImplementedException();
        }

        public PlanoInspecaoCab ParseToDTO(DataRow row)
        {
            PlanoInspecaoCab p = new PlanoInspecaoCab();
            p.ID = row.ParseToInt64("Id");
            p.CodigoItem = row.ParseToString("codItem");
            p.DescricaoItem = row.ParseToString("descItem");
            p.VerPlano = row.ParseToString("verPlano");
            p.CodigoCC = row.ParseToString("codCC");
            p.DescricaoCC = row.ParseToString("descCC");
            p.DataRI = row.ParseToDatetime("dataRI");
            p.PlanoPadrao = row.ParseToString("planoPadrao");
            p.PlanoPadraoVersao = row.ParseToString("planoPadraoVersao");
            p.CT = row.ParseToString("CT");

            try
            {
                p.PlanoInspecaoCaract = new DAOFactory().InitPlanoInspecaoCaracDAO().GetPlanoInspecaoCaracByPlanoInspecaoCab(p);
            }
            catch { }

            try
            {
                p.MedicaoCab = new DAOFactory().InitMedicaoCabDAO().GetMedicaoCabByPlanoInspecaoCab(p);
            }
            catch { }

            return p;
        }

        public DTOPlanoInspecao ParseToSimpleDTO(DataRow row)
        {
            DTOPlanoInspecao p = new DTOPlanoInspecao();
            p.ID = row.ParseToInt64("Id");
            p.CodigoItem = row.ParseToString("codItem");
            p.DescricaoItem = row.ParseToString("descItem");
            p.VerPlano = row.ParseToString("verPlano");
            p.CodigoCC = row.ParseToString("codCC");
            p.DescricaoCC = row.ParseToString("descCC");
            p.DataRI = row.ParseToDatetime("dataRI");
            p.CodigoOP = row.ParseToString("codOP");
            p.PlanoPadrao = row.ParseToString("planoPadrao");
            p.PlanoPadraoVersao = row.ParseToString("planoPadraoVersao");
            p.CT = row.ParseToString("CT");

            return p;
        }

        public Dictionary<string, object> ParseToParameters(PlanoInspecaoCab t)
        {
            throw new NotImplementedException();
        }

        public PlanoInspecaoCab SaveUpdate(PlanoInspecaoCab t)
        {
            throw new NotImplementedException();
        }
    }
}
