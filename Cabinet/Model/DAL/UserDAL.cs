using Cabinet.Model.Entities;
using Microsoft.Data.SqlClient;

namespace Cabinet.Model.DAL
{
    internal class UserDAL
    {
        public List<User> GetUsers()
        {
            var connection = DbHelper.Connection;
            List<User> users = new List<User>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectUsers", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.UserId = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.IsAdmin = reader.GetBoolean(3);
                    user.IsActive = reader.GetBoolean(4);
                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return users;
        }

        public void AddUser(User user)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
                command.Parameters.AddWithValue("@IsActive", user.IsActive);
                if (SqlValidator.ValidateCommand(command))
                    command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public void EditUser(User user)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EditUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", user.UserId);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
                command.Parameters.AddWithValue("@IsActive", user.IsActive);
                if (SqlValidator.ValidateCommand(command))
                    command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
