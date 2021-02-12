using Br.Com.SPI.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Br.Com.SPI.Core.Models.DAO
{
    public sealed class MotivoN1DAOImpl : DAOImpl, IMotivoN1DAO
    {
        public List<MotivoN1> GetAll()
        {
            List<MotivoN1> list = new List<MotivoN1>();

            var dt = this.GetDataTable("spGetMotivosN1");
            
            foreach (DbDataReader row in dt)
            {
                list.Add(this.ParseToDTO(row));
            }

            return list;
        }

        public MotivoN1 GetByID(long id)
        {
            Dictionary<string, object> d = new Dictionary<string, object>()
            {
                { "ID", id }
            };

            var dt = this.GetDataTable("spGetMotivosN1ByID @ID", d);

            foreach(DbDataReader row in dt)
            {
                return this.ParseToDTO(row);
            }
            

            return null;
        }

        public MotivoN1 Delete(MotivoN1 t)
        {
            Dictionary<string, object> d = new Dictionary<string, object>()
            {
                { "ID", t.ID }
            };

            var dt = this.GetDataTable("spDeleteMotivoN1 @ID", d);

            foreach(DbDataReader row in dt)
            {
                return t;
            }
            

            return null;
        }

        public MotivoN1 SaveUpdate(MotivoN1 t)
        {
            var dt = this.GetDataTable("spSaveUpdateMotivosN1 @ID, @DescricaoMotivo, @DataRI", this.ParseToParameters(t));
            
            foreach(DbDataReader row in dt)
            {
                Int64 id = row.ParseToInt64("ID");
                t.ID = id > 0 ? id: t.ID;
                return t;
            }
            

            return null;
        }

        public MotivoN1 ParseToDTO(DbDataReader row)
        {
            MotivoN1 m = new MotivoN1();
            m.ID = row.ParseToInt64("id");
            m.Descricao = row.ParseToString("descMotivoN1");
            m.DataRI = row.ParseToDatetime("dataRI");
            return m;
        }

        public Dictionary<string, object> ParseToParameters(MotivoN1 t)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Id", t.ID);
            d.Add("descMotivoN1", t.Descricao);
            d.Add("dataRI", t.DataRI);

            return d;
        }
    }
}
