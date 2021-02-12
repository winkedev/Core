namespace Br.Com.SPI.Core.Models.DAO
{
    public interface IConnectionDAO
    {
        public bool TestConnection();

        public SecurityConfig GetConnectionString();
    }
}
