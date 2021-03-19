using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Br.Com.SPI.Core
{
    public class Teste
    {

        public Task<string> GetBase64StringAsync()
        {
            return Task.Run(() =>
            {
                byte[] b = File.ReadAllBytes(@"D:\Analise\teste.pdf");
                return Convert.ToBase64String(b);
            });
        }

        public Task<string> GetBase64String()
        {
            return Task.Run(() =>
            {
                byte[] b = Encoding.UTF8.GetBytes("Some Text");
                return Convert.ToBase64String(b);
            });
        }

    }
}
