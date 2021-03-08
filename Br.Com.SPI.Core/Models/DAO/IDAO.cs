using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Br.Com.SPI.Core.Models.DAO
{
    public interface IDAO<T>
    {
        /// <summary>
        /// Save or update <see cref="T"/>
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        T SaveUpdate(T t);

        /// <summary>
        /// Delete <see cref="T"/>
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        T Delete(T t);

        /// <summary>
        /// Parse <see cref="DataRow"/> to <see cref="T"/>
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        T ParseToDTO(DataRow row);

        /// <summary>
        /// Parse <see cref="T"/> to <see cref="Dictionary{TKey, TValue}"/>
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Dictionary<string, object> ParseToParameters(T t);
    }
}
