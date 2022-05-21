using System;
using Personalverwaltung.ViewModel;

namespace Personalverwaltung.Model
{
    public class Person : ViewModelBase
    {
        private string id;
        public string Id
        {
            get => id;

            set => SetProperty(ref id, value);
        }

        private string vorname;
        public string Vorname
        {
            get => vorname;

            set => SetProperty(ref vorname, value);
        }

        private string nachname;
        public string Nachname
        {
            get => nachname;

            set => SetProperty(ref nachname, value);
        }

        private DateTime? geburtsdatum;

        public DateTime? Geburtsdatum
        {
            get => geburtsdatum;

            set => SetProperty(ref geburtsdatum, value);
        }

        private string strasse;
        public string Strasse
        {
            get => strasse; 

            set => SetProperty(ref strasse, value);
        }

        private string ort;
        public string Ort
        {
            get => ort;

            set => SetProperty(ref ort, value);
        }

        private int plz;
        public int Plz
        {
            get => plz;
            
            set => SetProperty(ref plz, value);
        }

        private string details;
        public string Details
        {
            get => details;

            set => SetProperty(ref details, value);
        }
    }
}
