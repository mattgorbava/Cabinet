using Cabinet.Model.BLL;
using Cabinet.Model.Entities;
using Cabinet.MVVM;
using Cabinet.View;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cabinet.ViewModel
{
    class EditAppointmentViewModel : BaseViewModel
    {
        private readonly AppointmentBLL appointmentBLL;
        public ICommand SaveCommand { get; set; }

        public EditAppointmentViewModel(Medic medic, Patient patient)
        {
            SaveCommand = new RelayCommand<object>(AddAppointment, canExecute => TextBoxFieldsNotNull());
            Medic = medic;
            Patient = patient;
        }

        private int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public Medic Medic { get; set; }
        public Patient Patient { get; set; }
        public bool IsActive { get; set; }

        private void AddAppointment(object? obj)
        {
            Appointment appointment = new Appointment()
            {
                Date = this.Date,
                MedicId = Medic.MedicId,
                PatientId = Patient.PatientId,
                IsActive = this.IsActive
            };

            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new MedicPage());
        }
    }
}
