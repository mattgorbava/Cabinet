using Cabinet.Model.Entities;
using Microsoft.Data.SqlClient;
using System.Net;

namespace Cabinet.Model.DAL
{
    internal class MedicDAL
    {
        public List<Medic> GetMedics()
        {
            var connection = DbHelper.Connection;
            List<Medic> medics = new List<Medic>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectMedics", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Medic medic = new Medic();
                    medic.MedicId = reader.GetInt32(0);
                    medic.Name = reader.GetString(1);
                    medic.UserId = reader.GetInt32(2);
                    medic.IsActive = reader.GetBoolean(3);
                    medics.Add(medic);
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
            return medics;
        }

        public void AddMedic(Medic medic)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddMedic", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", medic.Name);
                command.Parameters.AddWithValue("@UserId", medic.UserId);
                command.Parameters.AddWithValue("@IsActive", medic.IsActive);
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

        public void EditMedic(Medic medic)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EditMedic", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MedicId", medic.MedicId);
                command.Parameters.AddWithValue("@Name", medic.Name);
                command.Parameters.AddWithValue("@UserId", medic.UserId);
                command.Parameters.AddWithValue("@IsActive", medic.IsActive);
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
