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
        private ObservableCollection<Person> personList;
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
            personList = new ObservableCollection<Person>();
            LoadPersons(ref personList);
            personView = new ListCollectionView(personList);
            newCommandBinding = new CommandBinding(ApplicationCommands.New, NewExecuted, NewCanExecute);
            saveCommandBinding = new CommandBinding(ApplicationCommands.Save, SaveExecuted, SaveCanExecute);
            deleteCommandBinding = new CommandBinding(ApplicationCommands.Delete, DeleteExecuted, DeleteCanExecute);
        }

        private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Person person = new();
            personList.Add(person);
            personView.MoveCurrentTo(person);
        }
        private void NewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
        private void SaveCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
        private void DeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Person persDelete = (Person) PersonView.CurrentItem;
            if (persDelete != null)
            {
                personList.Remove(persDelete);
            }

            personView.MoveCurrentToFirst();
        }
        private void DeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = PersonView.Count > 0;
        }

    }
}
