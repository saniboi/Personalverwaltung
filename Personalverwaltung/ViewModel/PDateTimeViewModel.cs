using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Personalverwaltung.ViewModel
{
    internal class PDateTimeViewModel : BaseViewModel
    {
        private DateTime? currentValue;
        private DateTime? originalValue;
        private bool hasChanged;
        private bool hasError;
        private string errorValue;

        public PDateTimeViewModel(DateTime? date)
        {
            currentValue = date;
            originalValue = date;
        }

        public string Value
        {
            get
            {
                if (HasError)
                {
                    return errorValue;
                }

                if (!currentValue.HasValue)
                {
                    return null;
                }

                return currentValue.Value.ToShortDateString();
            }

            set
            {
                DateTime newValue;
                hasError = false;
                if (value == string.Empty)
                {
                    SetProperty(ref currentValue, null);
                }
                else if (DateTime.TryParse(value, out newValue))
                {
                    SetProperty(ref currentValue, newValue);
                }
                else
                {
                    errorValue = value;
                    hasError = true;
                }

                HasChanged = currentValue != originalValue;
            }
        }

        public DateTime? CurrentValue
        {
            get => currentValue;
        }

        public bool HasChanged
        {
            get => hasChanged;

            set => SetProperty(ref hasChanged, value);
        }

        public bool HasError
        {
            get => hasError;

            set => SetProperty(ref hasError, value);
        }
        
    }
}
