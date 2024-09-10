using Cabinet.Model.Entities;
using System.Windows.Controls;

namespace Cabinet.View
{
    
    public partial class EditAppointmentPage : Page
    {
        public EditAppointmentPage()
        {
            InitializeComponent();
        }

        public EditAppointmentPage(Appointment appointment)
        {
            InitializeComponent();
            DataContext = new EditAppointmentViewModel(appointment);
        }

        public EditAppointmentPage(Medic medic, Patient patient)
        {
            InitializeComponent();
            DataContext = new EditAppointmentViewModel(medic, patient);
        }
    }
}
