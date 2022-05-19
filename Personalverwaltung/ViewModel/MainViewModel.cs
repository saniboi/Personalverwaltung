using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Serialization;
using Personalverwaltung.Model;

namespace Personalverwaltung.ViewModel
{
    internal class MainViewModel
    {
        private ListCollectionView personView;
        private CommandBinding newCommandBinding;
        private CommandBinding saveCommandBinding;
        private CommandBinding deleteCommandBinding;
        public ListCollectionView PersonView
        {
            get => personView;
        }

        public CommandBinding NewCommandBinding
        {
            get => newCommandBinding;
        }

        public CommandBinding SaveCommandBinding
        {
            get => saveCommandBinding;
        }

        public CommandBinding DeleteCommandBinding
        {
            get => deleteCommandBinding;
        }

        private void LoadPersons(ref ObservableCollection<Person> liste)
        {
            if (File.Exists("Persons.xml"))
            {
                FileStream fs = new FileStream("Persons.xml", FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
                liste = (ObservableCollection<Person>)serializer.Deserialize(fs);
                fs.Close();
            }
        }

        public MainViewModel()
        {
            var personList = new ObservableCollection<Person>();
            LoadPersons(ref personList);
            personView = new ListCollectionView(personList);
        }
    }
}
