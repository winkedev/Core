using Br.Com.SPI.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace Br.Com.SPI.Core.Models.DAO
{
    internal sealed class MotivoN2DAOImpl : DAOImpl, IMotivoN2DAO
    {
        public ObservableCollection<MotivoN2> GetAll()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<MotivoN2> GetByMotivoN1(MotivoN1 motivo)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                { "ID", motivo.ID }
            };

            ObservableCollection<MotivoN2> list = new ObservableCollection<MotivoN2>();

            using (DataTable dt = this.GetDataTable("spGetMotivosN2ByIDMotivoN1 @ID", dic))
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(this.ParseToDTO(row));
                }
            }

            return list;
        }

        public MotivoN2 ParseToDTO(DataRow row)
        {
            MotivoN2 m = new MotivoN2();
            m.ID = row.ParseToInt64("id");
            m.Descricao = row.ParseToString("descMotivoN2");
            m.DataRI = row.ParseToDatetime("dataRI");
            return m;
        }

        public Dictionary<string, object> ParseToParameters(MotivoN2 t)
        {
            return new Dictionary<string, object>()
            {
                {"ID", t.ID },
                {"IDN1", t.MotivoN1Parent?.ID },
                {"DESCRICAO", t.Descricao },
                {"DATARI", DateTime.Now }
            };
        }

        public MotivoN2 SaveUpdate(MotivoN2 t)
        {
            using (DataTable dt = this.GetDataTable("spSaveUpdateMotivosN2 @ID, @IDN1, @DESCRICAO, @DATARI", this.ParseToParameters(t)))
            {
                foreach (DataRow row in dt.Rows)
                {
                    t.ID = row.ParseToInt64("id");
                    return t;
                }
            }

            return null;
        }

        public MotivoN2 Delete(MotivoN2 t)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>()
            {
                { "ID", t.ID }
            };

            using (DataTable dt = this.GetDataTable("spDeleteMotivoN2 @ID", dic))
            {
                this.CheckPatternError(dt.Rows);

                foreach (DataRow row in dt.Rows)
                {
                    return t;
                }
            }
            return null;
        }
    }
}
