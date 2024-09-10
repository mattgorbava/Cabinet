using Cabinet.Model.Entities;
using Cabinet.MVVM;
using Cabinet.View;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Cabinet.Model.BLL;

namespace Cabinet.ViewModel
{
    internal class AdminViewModel : BaseViewModel
    {
        private readonly UserBLL userBLL;
        private readonly MedicBLL medicBLL;
        private readonly PriceBLL priceBLL;
        private readonly OperationBLL operationBLL;
        private readonly PatientBLL patientBLL;

        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Medic> Medics { get; set; }
        public ObservableCollection<Price> Prices { get; set; }
        public ObservableCollection<Operation> Operations { get; set; }
        //private ObservableCollection<Patient> patients { get; set; }

        public User SelectedUser { get; set; }
        public Medic SelectedMedic { get; set; }
        public Price SelectedPrice { get; set; }
        public Operation SelectedOperation { get; set; }

        public ICommand AddUserCommand { get; set; }
        public ICommand EditUserCommand { get; set; }
        public ICommand AddMedicCommand { get; set; }
        public ICommand EditMedicCommand { get; set; }
        public ICommand AddPriceCommand { get; set; }
        public ICommand EditPriceCommand { get; set; }
        public ICommand AddOperationCommand { get; set; }
        public ICommand EditOperationCommand { get; set; }

        public AdminViewModel()
        {
            Users = new ObservableCollection<User>(userBLL.GetUsers());
            Medics = new ObservableCollection<Medic>(medicBLL.GetMedics());
            Prices = new ObservableCollection<Price>(medicBLL.GetPrices());
            Operations = new ObservableCollection<Operation>(operationBLL.GetOperations());

            AddUserCommand = new RelayCommand<object>(AddUser);
            EditUserCommand = new RelayCommand<object>(EditUser, canExecute => SelectedUser != null);
            AddMedicCommand = new RelayCommand<object>(AddMedic);
            EditMedicCommand = new RelayCommand<object>(EditMedic, canExecute => SelectedMedic != null);
            AddPriceCommand = new RelayCommand<object>(AddPrice);
            EditPriceCommand = new RelayCommand<object>(EditPrice, canExecute => SelectedPrice != null);
            AddOperationCommand = new RelayCommand<object>(AddOperation);
            EditOperationCommand = new RelayCommand<object>(EditOperation, canExecute => SelectedOperation != null);
        }

        private void AddUser(object obj)
        {
            if (obj is not AdminPage currentPage)
            {
                return;
            }
            currentPage.NavigationService?.Navigate(new EditUserPage());
        }

        private void EditUser(object obj)
        {
            if (obj is not AdminPage currentPage)
            {
                return;
            }
            currentPage.NavigationService?.Navigate(new EditUserPage(SelectedUser));
        }

        private void AddMedic(object obj)
        {
            if (obj is not AdminPage currentPage)
            {
                return;
            }
            currentPage.NavigationService?.Navigate(new EditMedicPage());
        }

        private void EditMedic(object obj)
        {
            if (obj is not AdminPage currentPage)
            {
                return;
            }
            currentPage.NavigationService?.Navigate(new EditMedicPage(SelectedMedic));
        }

        private void AddPrice(object obj)
        {
            if (obj is not AdminPage currentPage)
            {
                return;
            }
            currentPage.NavigationService?.Navigate(new EditPricePage());
        }

        private void EditPrice(object obj)
        {
            if (obj is not AdminPage currentPage)
            {
                return;
            }
            currentPage.NavigationService?.Navigate(new EditPricePage(SelectedPrice));
        }

        private void AddOperation(object obj)
        {
            if (obj is not AdminPage currentPage)
            {
                return;
            }
            currentPage.NavigationService?.Navigate(new EditOperationsPage());
        }

        private void EditOperation(object obj)
        {
            if (obj is not AdminPage currentPage)
            {
                return;
            }
            currentPage.NavigationService?.Navigate(new EditOperationsPage(SelectedOperation));
        }
    }
}
