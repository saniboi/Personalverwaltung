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

        private ObservableCollection<PersonViewModel> personList;
        private ListCollectionView personView;

        #endregion
        
        #region Mouse Trigger Eigenschaften

        private string personDetails;

        public string PersonDetails
        {
            get => personDetails;

            set => SetProperty(ref personDetails, value);
        }

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
        private void LoadPersons(ref ObservableCollection<PersonViewModel> liste)
        {
            if (!File.Exists("Persons.xml")) return;
            FileStream fs = new FileStream("Persons.xml", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
            var tempList = (ObservableCollection<Person>)serializer.Deserialize(fs);
            foreach (var item in tempList) 
                liste.Add(new PersonViewModel(item));
            fs.Close();
        }

        #endregion

        #region Konstruktor

        public MainViewModel()
        {
            // Personenliste wird befüllt
            personList = new ObservableCollection<PersonViewModel>();
            LoadPersons(ref personList);

            // ListCollectionView wird initialisiert wird in diesem Beispiel welcher von mir aufgebaut wurde nicht verwendet
            personView = new ListCollectionView(personList);


            newCommandBinding = new CommandBinding(ApplicationCommands.New, NewExecuted, NewCanExecute);
            saveCommandBinding = new CommandBinding(ApplicationCommands.Save, SaveExecuted, SaveCanExecute);
            deleteCommandBinding = new CommandBinding(ApplicationCommands.Delete, DeleteExecuted, DeleteCanExecute);
            MouseEnterCommand = new RelayCommand(MouseEnterExecute, MouseEnterCanExevute);
            MouseLeaveCommand = new RelayCommand(MouseLeaveExecute, MouseLeaveCanExecute);
        }

        #endregion

        #region Events
        private void MouseEnterExecute(object obj)
        {
            PersonViewModel selPerson = (PersonViewModel)personView.CurrentItem;
            if (selPerson != null)
            {
                PersonDetails = selPerson.Details.Value;
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
                ((PersonViewModel)personView.CurrentItem).Details.Value = personDetails;
            }
            PersonDetails = string.Empty;
        }

        private bool MouseLeaveCanExecute(object arg)
        {
            return true;
        }
        private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            PersonViewModel person = new(null);
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
            PersonViewModel persDelete = (PersonViewModel)PersonView.CurrentItem;
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
    }
}
