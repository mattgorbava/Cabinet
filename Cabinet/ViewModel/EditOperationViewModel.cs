using Cabinet.MVVM;
using System.Windows.Input;
using Cabinet.Model.BLL;
using Cabinet.Model.Entities;
using System.Windows.Controls;
using Cabinet.View;

namespace Cabinet.ViewModel
{
    class EditOperationViewModel : BaseViewModel
    {
        private readonly OperationBLL operationBLL = new OperationBLL();

        public ICommand SaveCommand { get; set; }
        public EditOperationViewModel()
        {
            SaveCommand = new RelayCommand<object>(AddOperation, canExecute => TextBoxFieldsNotNull());
        }

        public EditOperationViewModel(Operation operation)
        {
            SaveCommand = new RelayCommand<object>(EditOperation, canExecute => TextBoxFieldsNotNull());
            OperationId = operation.OperationId;
            OperationType = operation.OperationType;
            Date = operation.Date;
            MedicId = operation.MedicId;
            PatientId = operation.PatientId;
            PriceId = operation.PriceId;
            IsActive = operation.IsActive;
        }

        private int OperationId { get; set; }
        public string OperationType { get; set; }
        public DateTime Date { get; set; }
        public int MedicId { get; set; }
        public int PatientId { get; set; }
        public int PriceId { get; set; }
        public bool IsActive { get; set; }

        private void AddOperation(object? obj)
        {
            Operation operation = new Operation()
            {
                OperationType = this.OperationType,
                Date = this.Date,
                MedicId = this.MedicId,
                PatientId = this.PatientId,
                PriceId = this.PriceId,
                IsActive = this.IsActive
            };
            operationBLL.AddOperation(operation);

            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new AdminPage());
        }

        private void EditOperation(object? obj)
        {
            Operation operation = new Operation()
            {
                OperationId = this.OperationId,
                OperationType = this.OperationType,
                Date = this.Date,
                MedicId = this.MedicId,
                PatientId = this.PatientId,
                PriceId = this.PriceId,
                IsActive = this.IsActive
            };
            operationBLL.EditOperation(operation);

            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new AdminPage());
        }
    }
}
