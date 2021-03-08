using Br.Com.SPI.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Data;

namespace Br.Com.SPI.Core.Models.DAO
{
    internal sealed class TipoMedicaoDAOImpl : DAOImpl, ITipoMedicaoDAO
    {
        public TipoMedicao GetTipoMedicaoByID(long id)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                { "ID", id }
            };

            using (DataTable dt = this.GetDataTable("spGetTipoMedicaoByID @ID", dic))
            {
                foreach (DataRow row in dt.Rows)
                {
                    return this.ParseToDTO(row);
                }
            }

            return null;
        }

        public TipoMedicao Delete(TipoMedicao t)
        {
            throw new NotImplementedException();
        }

        public TipoMedicao ParseToDTO(DataRow row)
        {
            TipoMedicao t = new TipoMedicao();
            t.ID = row.ParseToInt64("Id");
            t.DescricaoTipo = row.ParseToString("descTipo");
            t.DataRI = row.ParseToDatetime("dataRI");

            return t;
        }

        public Dictionary<string, object> ParseToParameters(TipoMedicao t)
        {
            throw new NotImplementedException();
        }

        public TipoMedicao SaveUpdate(TipoMedicao t)
        {
            throw new NotImplementedException();
        }
    }
}
