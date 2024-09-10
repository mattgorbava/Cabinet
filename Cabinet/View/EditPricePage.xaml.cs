using Cabinet.ViewModel;
using Cabinet.Model.Entities;
using System.Windows.Controls;

namespace Cabinet.View
{
    /// <summary>
    /// Interaction logic for EditPricePage.xaml
    /// </summary>
    public partial class EditPricePage : Page
    {
        public EditPricePage()
        {
            InitializeComponent();
        }

        public EditPricePage(Price price)
        {
            InitializeComponent();
            DataContext = new EditPriceViewModel(price);
        }   
    }
}
