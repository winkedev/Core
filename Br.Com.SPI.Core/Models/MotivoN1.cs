using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Br.Com.SPI.Core.Models
{
    public class MotivoN1 : Abstract
    {
        private ObservableCollection<MotivoN2> motivosN2;

        public Int64 ID { get; set; }

        [Required(ErrorMessage = "Descricao não pode ser nulo.")]
        public string Descricao { get; set; }

        public DateTime DataRI { get; set; }

        public ObservableCollection<MotivoN2> MotivoN2
        {
            get
            {
                return this.motivosN2;
            }
            set
            {
                if (value == null && this.motivosN2 != null)
                {
                    this.motivosN2.CollectionChanged -= MotivosN2_CollectionChanged;
                }

                if ((this.motivosN2 = value) != null)
                {
                    this.motivosN2.CollectionChanged += MotivosN2_CollectionChanged;

                    foreach (MotivoN2 m in this.motivosN2)
                    {
                        m.MotivoN1Parent = this;
                    }
                }
            }
        }

        private void MotivosN2_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    MotivoN2[e.NewStartingIndex].MotivoN1Parent = this;
                    break;
                default:
                    break;
            }
        }
    }
}
