using System;
using System.Collections.Generic;

namespace Br.Com.SPI.Core.Models.DAO
{
    public interface IMotivoN1DAO : IDAO<MotivoN1>
    {
        /// <summary>
        /// Get all <see cref="MotivoN1"/>
        /// </summary>
        /// <returns></returns>
        List<MotivoN1> GetAll();

        /// <summary>
        /// Get <see cref="MotivoN1"/> by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MotivoN1 GetByID(Int64 id);
    }
}
