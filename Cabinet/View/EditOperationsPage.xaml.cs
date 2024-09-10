using Cabinet.Model.Entities;
using Cabinet.ViewModel;
using System.Windows.Controls;

namespace Cabinet.View
{
    /// <summary>
    /// Interaction logic for EditOperationsPage.xaml
    /// </summary>
    public partial class EditOperationsPage : Page
    {
        public EditOperationsPage()
        {
            InitializeComponent();
        }

        public EditOperationsPage(Operation operation)
        {
            InitializeComponent();
            DataContext = new EditOperationsViewModel(operation);
        }
    }
}
