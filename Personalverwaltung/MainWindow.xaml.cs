using Personalverwaltung.ViewModel;

namespace Personalverwaltung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel vm = (MainViewModel) this.TryFindResource("Vm");
            if (vm == null) return;
            this.CommandBindings.Add(vm.NewCommandBinding);
            this.CommandBindings.Add(vm.DeleteCommandBinding);
            this.CommandBindings.Add(vm.SaveCommandBinding);
        }
    }
}
