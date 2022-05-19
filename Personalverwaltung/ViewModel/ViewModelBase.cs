using System.ComponentModel;
using System.Runtime.CompilerServices;
using Personalverwaltung.Annotations;

namespace Personalverwaltung.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void SetProperty<T>(ref T storage, T value,
            [CallerMemberName] string property = null)
        {
            if (Equals(storage, value)) return;
            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
