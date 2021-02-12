using System;
using System.Threading;

namespace Br.Com.SPI.Core.Utils
{
    public static  class SafeRandom
    {

        private static int seed;
        private static readonly ThreadLocal<Random> random;

        static SafeRandom()
        {
            random = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));
        }

        public static int GetRandom()
        {
            return random.Value.Next();
        }

    }
}
