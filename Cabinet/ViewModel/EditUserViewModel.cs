using Cabinet.Model.BLL;
using Cabinet.MVVM;
using Cabinet.Model.Entities;
using Cabinet.View;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace Cabinet.ViewModel
{
    internal class EditUserViewModel : BaseViewModel
    {
        private readonly UserBLL userBLL;
        public ICommand SaveCommand { get; set; }
        public EditUserViewModel()
        {
            SaveCommand = new RelayCommand<object>(AddUser, canExecute => TextBoxFieldsNotNull());
        }

        public EditUserViewModel(User user)
        {
            SaveCommand = new RelayCommand<object>(EditUser, canExecute => TextBoxFieldsNotNull());
            UserId = user.UserId;
            Username = user.Username;
            Password = user.Password;
            IsAdmin = user.IsAdmin;
            IsActive = user.IsActive;
        }

        private int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }

        private void AddUser(object? obj)
        {
            User user = new User()
            {
                Username = this.Username,
                Password = this.Password,
                IsAdmin = this.IsAdmin,
                IsActive = this.IsActive
            };
            userBLL.AddUser(user);

            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new AdminPage());
        }

        private void EditUser(object? obj)
        {
            User user = new User()
            {
                UserId = this.UserId,
                Username = this.Username,
                Password = this.Password,
                IsAdmin = this.IsAdmin,
                IsActive = this.IsActive
            };
            userBLL.AddUser(user);

            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new AdminPage());
        }

        
    }
}
}