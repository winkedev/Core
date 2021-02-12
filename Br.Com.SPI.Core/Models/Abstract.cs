using Br.Com.SPI.Core.Utils;
using System;

namespace Br.Com.SPI.Core.Models
{
    [Serializable]
    public abstract class Abstract
    {
        private readonly int hash;

        public Abstract()
        {
            hash = SafeRandom.GetRandom();
        }

        public int GetHash()
        {
            return this.hash;
        }

    }
}
