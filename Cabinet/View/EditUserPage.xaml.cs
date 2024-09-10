using Cabinet.Model.Entities;
using Cabinet.ViewModel;
using System.Windows.Controls;

namespace Cabinet.View
{
    /// <summary>
    /// Interaction logic for EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        public EditUserPage()
        {
            InitializeComponent();
            DataContext = new EditUserViewModel();
        }

        public EditUserPage(User user)
        {
            InitializeComponent();
            DataContext = new EditUserViewModel(user);
        }
    }
}
