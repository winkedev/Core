namespace Br.Com.SPI.Core.Models.DAO
{
    public class DAOFactory
    {
        public IDTOMedicao InitDTOMedicaoDAO()
        {
            return new DTOMedicaoDAOImpl();
        }

        public IMedicaoCabDAO InitMedicaoCabDAO()
        {
            return new MedicaoCabDAOImpl();
        }

        public IMedicaoCaracDAO InitMedicaoCaracDAO()
        {
            return new MedicaoCaracDAOImpl();
        }

        public IPlanoInspecaoCabDAO InitPlanoInspecaoCabDAO()
        {
            return new PlanoInspecaoCabDAOImpl();
        }

        public IPlanoInspecaoCaracDAO InitPlanoInspecaoCaracDAO()
        {
            return new PlanoInspecaoCaracImpl();
        }

        public IOrdemProducaoDAO InitOrdemProducaoDAO()
        {
            return new OrdemProducaoDAOImpl();
        }

        public IConnectionDAO InitConnectionDAO()
        {
            return new ConnectionDAOImpl();
        }

        public IMotivoN1DAO InitMotivoN1DAO()
        {
            return new MotivoN1DAOImpl();
        }

        public ITipoMedicaoDAO InitTipoMedicaoDAO()
        {
            return new TipoMedicaoDAOImpl();
        }
    }
}
