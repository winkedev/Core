using Br.Com.SPI.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

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

            foreach(DbDataReader row in this.GetDataTable("spGetTipoMedicaoByID @ID", dic))
            {
                return this.ParseToDTO(row);
            }

            return null;
        }

        public TipoMedicao Delete(TipoMedicao t)
        {
            throw new NotImplementedException();
        }

        public TipoMedicao ParseToDTO(DbDataReader row)
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
