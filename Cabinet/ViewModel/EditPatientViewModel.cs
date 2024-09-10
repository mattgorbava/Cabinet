using Cabinet.Model.BLL;
using Cabinet.Model.Entities;
using Cabinet.MVVM;
using Cabinet.View;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cabinet.ViewModel
{
    class EditPatientViewModel : BaseViewModel
    {
        private readonly PatientBLL patientBLL = new PatientBLL();

        public ICommand SaveCommand { get; set; }
        public EditPatientViewModel()
        {
            SaveCommand = new RelayCommand<object>(AddPatient, canExecute => TextBoxFieldsNotNull());
        }

        public EditPatientViewModel(Patient patient)
        {
            SaveCommand = new RelayCommand<object>(EditPatient, canExecute => TextBoxFieldsNotNull());
            PatientId = patient.PatientId;
            Name = patient.Name;
            MedicId = patient.MedicId;
            IsActive = patient.IsActive;
            
        }

        private int PatientId { get; set; }
        public string Name { get; set; }
        public int MedicId { get; set; }
        public bool IsActive { get; set; }

        private void AddPatient(object? obj)
        {
            Patient patient = new Patient()
            {
                Name = this.Name,
                MedicId = this.MedicId,
                IsActive = this.IsActive
            };
            patientBLL.AddPatient(patient);

            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new MedicPage());
        }

        private void EditPatient(object? obj)
        {
            Patient patient = new Patient()
            {
                PatientId = this.PatientId,
                Name = this.Name,
                MedicId = this.MedicId,
                IsActive = this.IsActive
            };
            patientBLL.EditPatient(patient);

            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new MedicPage());
        }
    }
}
