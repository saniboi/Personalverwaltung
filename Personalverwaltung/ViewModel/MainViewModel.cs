using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Data;
using System.Xml.Serialization;
using Personalverwaltung.Model;

namespace Personalverwaltung.ViewModel
{
    internal class MainViewModel
    {
        private ObservableCollection<Person> personList;
        private ListCollectionView personView;

        public ListCollectionView PersonView
        {
            get => personView;
        }

        private void LoadPersons(ref ObservableCollection<Person> liste)
        {
            if (File.Exists("C:\\Users\\sanke\\source\\repos\\Personalverwaltung\\Personalverwaltung\\Resources\\Persons.xml"))
            {
                FileStream fs = new FileStream("C:\\Users\\sanke\\source\\repos\\Personalverwaltung\\Personalverwaltung\\Resources\\Persons.xml", FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
                liste = (ObservableCollection<Person>)serializer.Deserialize(fs);
                fs.Close();
            }
        }

        public MainViewModel()
        {
            personList = new ObservableCollection<Person>();
            LoadPersons(ref personList);
            personView = new ListCollectionView(personList);
        }
    }
}
