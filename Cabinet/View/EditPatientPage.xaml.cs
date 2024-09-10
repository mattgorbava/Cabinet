using Cabinet.Model.Entities;
using Cabinet.ViewModel;
using System.Windows.Controls;

namespace Cabinet.View
{
    /// <summary>
    /// Interaction logic for EditPatientPage.xaml
    /// </summary>
    public partial class EditPatientPage : Page
    {
        public EditPatientPage()
        {
            InitializeComponent();
        }

        public EditPatientPage(Patient patient)
        {
            InitializeComponent();
            DataContext = new EditPatientViewModel(patient);
        }
    }
}
