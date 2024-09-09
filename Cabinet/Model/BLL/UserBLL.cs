using Cabinet.Model.Entities;
using System.Collections.ObjectModel;

namespace Cabinet.Model.BLL
{
    internal class UserBLL
    {
        private readonly UserDAL userDAL;

        public UserBLL()
        {
            userDAL = new UserDAL();
        }

        public ObservableCollection<User> GetUsers()
        {
            return userDAL.GetUsers();
        }

        public void AddUser(User user)
        {
            userDAL.AddUser(user);
        }

        public void EditUser(User user)
        {
            userDAL.EditUser(user);
        }
    }
}
