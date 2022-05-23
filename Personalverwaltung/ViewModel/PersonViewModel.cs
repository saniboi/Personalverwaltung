using System.ComponentModel;
using Personalverwaltung.Model;

namespace Personalverwaltung.ViewModel
{
    internal class PersonViewModel : ViewModelBase 
    {
        private Person person;
        private string changed;
        private PStringViewModel id;
        private PStringViewModel vorname;
        private PStringViewModel nachname;
        private PDateTimeViewModel geburtsdatum;
        private PStringViewModel strasse;
        private PStringViewModel ort;
        private PStringViewModel plz;
        private PStringViewModel details;

        public PersonViewModel(Person person)
        {
            if (person != null)
            {
                this.person = person;
                initializeFields();
            }
            else
            {
                this.person = new Person();
                initializeFields();
                id.HasChanged = true;
                vorname.HasChanged = true;
                nachname.HasChanged = true;
                geburtsdatum.HasChanged = true;
                strasse.HasChanged = true;
                ort.HasChanged = true;
                plz.HasChanged = true;
                details.HasChanged = true;
            }

            id.PropertyChanged += person_PropertyChanged;
            vorname.PropertyChanged += person_PropertyChanged;
            nachname.PropertyChanged += person_PropertyChanged;
            geburtsdatum.PropertyChanged += person_PropertyChanged;
            strasse.PropertyChanged += person_PropertyChanged;
            ort.PropertyChanged += person_PropertyChanged;
            plz.PropertyChanged += person_PropertyChanged;
            details.PropertyChanged += person_PropertyChanged;
        }

        private void initializeFields()
        {
            id = new PStringViewModel(person.Id);
            vorname = new PStringViewModel(person.Vorname);
            nachname = new PStringViewModel(person.Nachname);
            geburtsdatum = new PDateTimeViewModel(person.Geburtsdatum);
            strasse = new PStringViewModel(person.Strasse);
            ort = new PStringViewModel(person.Ort);
            plz = new PStringViewModel(person.Plz);
            details = new PStringViewModel(person.Details);
        }

        private void person_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (id.HasChanged || vorname.HasChanged || nachname.HasChanged || geburtsdatum.HasChanged || strasse.HasChanged || ort.HasChanged || plz.HasChanged || details.HasChanged)
            {
                Changed = "*";
            }
            else
            {
                Changed = string.Empty;
            }
        }

        #region Eigenschaften

        public PStringViewModel Id
        {
            get => id;
        }

        public PStringViewModel Vorname
        {
            get => vorname;
        }

        public PStringViewModel Nachname
        {
            get => nachname;
        }

        public PDateTimeViewModel Geburtsdatum
        {
            get => geburtsdatum;
        }

        public PStringViewModel Strasse
        {
            get => strasse;
        }

        public PStringViewModel Ort
        {
            get => ort;
        }

        public PStringViewModel Plz
        {
            get => plz;
        }

        public PStringViewModel Details
        {
            get => details;
        }

        #endregion

        public string Changed
        {
            get => changed;

            set => SetProperty(ref changed, value);
        }

    }

    
}
