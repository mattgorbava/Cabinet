using Cabinet.Model.DAL;
using Cabinet.Model.Entities;
using System.Collections.ObjectModel;

namespace Cabinet.Model.BLL
{
    class AppointmentBLL
    {
        private readonly AppointmentDAL appointmentDAL;

        public AppointmentBLL()
        {
            appointmentDAL = new AppointmentDAL();
        }

        public ObservableCollection<Appointment> GetAppointments()
        {
            return new ObservableCollection<Appointment>(appointmentDAL.GetAppointments());
        }

        public void AddAppointment(Appointment appointment)
        {
            appointmentDAL.AddAppointment(appointment);
        }

        public void EditAppointment(Appointment appointment)
        {
            appointmentDAL.EditAppointment(appointment);
        }
    }
}
