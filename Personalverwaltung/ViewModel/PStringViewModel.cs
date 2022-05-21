namespace Personalverwaltung.ViewModel
{
    internal class PStringViewModel : ViewModelBase
    {
        private string currentValue;
        private string originalValue;
        private bool hasChanged;

        public bool HasChanged
        {
            get => hasChanged;

            set => SetProperty(ref hasChanged, value);
        }

        public PStringViewModel(string value)
        {
            if (value == string.Empty)
            {
                value = null;
            }
            currentValue = value;
            originalValue = value;
        }

        public string Value
        {
            get => currentValue;

            set
            {
                if (value == "")
                {
                    value = null;
                }
                SetProperty(ref currentValue, value);
                HasChanged = currentValue != originalValue;
            }

        }
    }  
}
