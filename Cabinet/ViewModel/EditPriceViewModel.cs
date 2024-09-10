using Cabinet.MVVM;
using System.Windows.Input;
using Cabinet.Model.BLL;
using Cabinet.Model.Entities;
using System.Windows.Controls;
using Cabinet.View;

namespace Cabinet.ViewModel
{
    class EditPriceViewModel : BaseViewModel
    {
        private readonly PriceBLL priceBLL = new PriceBLL();

        public ICommand SaveCommand { get; set; }
        public EditPriceViewModel()
        {
            SaveCommand = new RelayCommand<object>(AddPrice, canExecute => TextBoxFieldsNotNull());
        }

        public EditPriceViewModel(Price price)
        {
            SaveCommand = new RelayCommand<object>(EditPrice, canExecute => TextBoxFieldsNotNull());
            PriceId = price.PriceId;
            Value = price.Value;
            IsActive = price.IsActive;
            StartDate = price.StartDate;
            EndDate = price.EndDate;
        }

        private int PriceId { get; set; }
        public decimal Value { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private void AddPrice(object? obj)
        {
            Price price = new Price()
            {
                Value = this.Value,
                IsActive = this.IsActive,
                StartDate = this.StartDate,
                EndDate = this.EndDate
            };
            priceBLL.AddPrice(price);

            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new AdminPage());
        }

        private void EditPrice(object? obj)
        {
            Price price = new Price()
            {
                PriceId = this.PriceId,
                Value = this.Value,
                IsActive = this.IsActive,
                StartDate = this.StartDate,
                EndDate = this.EndDate
            };
            priceBLL.EditPrice(price);

            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new AdminPage());
        }
    }
}
