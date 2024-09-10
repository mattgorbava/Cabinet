using Cabinet.MVVM;
using System.Windows.Input;
using Cabinet.Model.BLL;
using Cabinet.Model.Entities;
using System.Windows.Controls;
using Cabinet.View;

namespace Cabinet.ViewModel
{
    class EditMedicViewModel : BaseViewModel
    {
        private readonly MedicBLL medicBLL = new MedicBLL();

        public ICommand SaveCommand { get; set; }
        public EditMedicViewModel()
        {
            SaveCommand = new RelayCommand<object>(AddMedic, canExecute => TextBoxFieldsNotNull());
        }

        public EditMedicViewModel(Medic medic)
        {
            SaveCommand = new RelayCommand<object>(EditMedic, canExecute => TextBoxFieldsNotNull());
            MedicId = medic.MedicId;
            Name = medic.Name;
            UserId = medic.UserId;
            IsActive = medic.IsActive;
        }

        private int MedicId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }

        private void AddMedic(object? obj)
        {
            Medic medic = new Medic()
            {
                Name = this.Name,
                UserId = this.UserId,
                IsActive = this.IsActive
            };
            medicBLL.AddMedic(medic);

            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new AdminPage());
        }

        private void EditMedic(object? obj)
        {
            Medic medic = new Medic()
            {
                MedicId = this.MedicId,
                Name = this.Name,
                UserId = this.UserId,
                IsActive = this.IsActive
            };
            medicBLL.EditMedic(medic);

            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new AdminPage());
        }
    }
}
