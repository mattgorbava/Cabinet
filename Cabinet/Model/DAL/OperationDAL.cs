using Cabinet.Model.Entities;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Cabinet.Model.DAL
{
    internal class OperationDAL
    {
        public List<Operation> GetOperations()
        {
            var connection = DbHelper.Connection;
            List<Operation> operations = new List<Operation>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddOperation", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Operation operation = new Operation();
                    operation.OperationId = reader.GetInt32(0);
                    operation.OperationType = reader.GetString(1);
                    operation.PatientId = reader.GetInt32(2);
                    operation.PriceId = reader.GetInt32(3);
                    operation.IsActive = reader.GetBoolean(4);
                    operations.Add(operation);
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
            return operations;
        }

        public void AddOperation(Operation operation)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddOperation", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OperationType", operation.OperationType);
                command.Parameters.AddWithValue("@MedicId", operation.MedicId);
                command.Parameters.AddWithValue("@PatientId", operation.PatientId);
                command.Parameters.AddWithValue("@PriceId", operation.PriceId);
                command.Parameters.AddWithValue("@IsActive", operation.IsActive);
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

        public void EditOperation(Operation operation)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EditOperation", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@OperationId", operation.OperationId);
                command.Parameters.AddWithValue("@OperationType", operation.OperationType);
                command.Parameters.AddWithValue("@MedicId", operation.MedicId);
                command.Parameters.AddWithValue("@PatientId", operation.PatientId);
                command.Parameters.AddWithValue("@PriceId", operation.PriceId);
                command.Parameters.AddWithValue("@IsActive", operation.IsActive);
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
