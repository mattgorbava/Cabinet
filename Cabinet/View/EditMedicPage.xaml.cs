using Cabinet.Model.Entities;
using Cabinet.ViewModel;
using System.Windows.Controls;

namespace Cabinet.View
{
    /// <summary>
    /// Interaction logic for EditMedicPage.xaml
    /// </summary>
    public partial class EditMedicPage : Page
    {
        public EditMedicPage()
        {
            InitializeComponent();
        }

        public EditMedicPage(Medic medic)
        {
            InitializeComponent();
            DataContext = new EditMedicViewModel(medic);
        }
    }
}
