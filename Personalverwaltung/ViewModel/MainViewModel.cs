using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Serialization;
using Personalverwaltung.Command;
using Personalverwaltung.Model;

namespace Personalverwaltung.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        #region Listen

        private ObservableCollection<Person> personList;
        private ListCollectionView personView;

        #endregion

        #region Command 

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

        public ICommand MouseEnterCommand { get; private set; }
        public ICommand MouseLeaveCommand { get; private set; }
        #endregion

        #region Personen Laden
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

        #endregion

        #region Konstruktor

        public MainViewModel()
        {
            personList = new ObservableCollection<Person>();
            LoadPersons(ref personList);
            personView = new ListCollectionView(personList);
            newCommandBinding = new CommandBinding(ApplicationCommands.New, NewExecuted, NewCanExecute);
            saveCommandBinding = new CommandBinding(ApplicationCommands.Save, SaveExecuted, SaveCanExecute);
            deleteCommandBinding = new CommandBinding(ApplicationCommands.Delete, DeleteExecuted, DeleteCanExecute);
            MouseEnterCommand = new RelayCommand(MouseEnterExecute, MouseEnterCanExevute);
            MouseLeaveCommand = new RelayCommand(MouseLeaveExecute, MouseLeaveCanExecute);
        }

        private void MouseEnterExecute(object obj)
        {
            Person selPerson = (Person) personView.CurrentItem;
            if (selPerson != null)
            {
                PersonDetails = selPerson.Details;
            }
        }

        private bool MouseEnterCanExevute(object arg)
        {
            return true;
        }

        private void MouseLeaveExecute(object obj)
        {
            if (personView.CurrentItem != null)
            {
                ((Person)personView.CurrentItem).Details = personDetails;
            }
            PersonDetails = string.Empty;
        }

        private bool MouseLeaveCanExecute(object arg)
        {
            return true;
        }

        #endregion

        #region Events
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

        }
        private void SaveCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }
        private void DeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Person persDelete = (Person)PersonView.CurrentItem;
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
        

        #endregion

        #region Mouse Trigger

        private string personDetails;

        public string PersonDetails
        {
            get => personDetails;
            set => SetProperty(ref personDetails, value);
        }

        #endregion
    }
}
