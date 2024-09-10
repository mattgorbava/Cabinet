using Cabinet.Model.BLL;
using Cabinet.Model.Entities;
using Cabinet.MVVM;
using Cabinet.View;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Cabinet.ViewModel
{
    internal class MedicViewModel
    {
        private readonly PatientBLL patientBLL;
        private readonly AppointmentBLL appointmentBLL;
        private readonly MedicBLL medicBLL;

        public ObservableCollection<Patient> Patients {  get; set; }
        public ObservableCollection<Appointment> Appointments { get; set; }

        public Medic ConnectedMedic { get; set; }
        public Patient SelectedPatient { get; set; }
        public Appointment SelectedAppointment { get; set; }

        public ICommand AddPatientCommand { get; set; }
        public ICommand EditPatientCommand { get; set; }
        public ICommand AddAppointmentCommand { get; set; }
        public ICommand EditAppointmentCommand { get; set; }

        public MedicViewModel(int userId)
        {
            ConnectedMedic = medicBLL.GetMedicByUId(userId);
            Patients = patientBLL.GetPatients();
            Appointments = appointmentBLL.GetAppointments();

            AddPatientCommand = new RelayCommand<object>(AddPatient);
            EditPatientCommand = new RelayCommand<object>(EditPatient, canExecute => SelectedPatient != null);
            AddAppointmentCommand = new RelayCommand<object>(AddAppointment, canExecute => SelectedPatient != null);
            EditAppointmentCommand = new RelayCommand<object>(EditAppointment);
        }

        private void AddPatient(object obj)
        {
            if (obj is not MedicPage currentPage)
            {
                return;
            }
            currentPage.NavigationService?.Navigate(new EditPatientPage());
        }

        private void EditPatient(object obj)
        {
            if (obj is not MedicPage currentPage)
            {
                return;
            }
            currentPage.NavigationService?.Navigate(new EditPatientPage(SelectedPatient));
        }

        private void AddAppointment(object obj)
        {
            if (obj is not MedicPage currentPage)
            {
                return;
            }
            currentPage.NavigationService?.Navigate(new EditAppointmentPage(ConnectedMedic, SelectedPatient)); 
        }

        private void EditAppointment(object obj)
        {
            if (obj is not MedicPage currentPage)
            {
                return;
            }
            currentPage.NavigationService?.Navigate(new EditAppointmentPage(SelectedAppointment));
        }
    }
}
