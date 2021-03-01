using System.Collections.ObjectModel;

namespace Br.Com.SPI.Core.Models.DAO
{
    public interface IMotivoN2DAO : IDAO<MotivoN2>
    {
        public ObservableCollection<MotivoN2> GetAll();

        public ObservableCollection<MotivoN2> GetByMotivoN1(MotivoN1 motivo);
    }
}
