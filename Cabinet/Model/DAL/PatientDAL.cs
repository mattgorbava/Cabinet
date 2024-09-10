using Cabinet.Model.Entities;
using Microsoft.Data.SqlClient;

namespace Cabinet.Model.DAL
{
    class PatientDAL
    {
        public List<Patient> GetPatients()
        {
            List<Patient> patients = new List<Patient>();
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectPatients", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) 
                {
                    Patient patient = new Patient();
                    patient.PatientId = reader.GetInt32(0);
                    patient.Name = reader.GetString(1);
                    patient.MedicId = reader.GetInt32(2);
                    patient.IsActive = reader.GetBoolean(3);
                    patients.Add(patient);
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
            return patients;
        }

        public void AddPatient(Patient patient)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddPatient", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", patient.Name);
                command.Parameters.AddWithValue("@MedicId", patient.MedicId);
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

        public void EditPatient(Patient patient)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EditPatient", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PatientId", patient.PatientId);
                command.Parameters.AddWithValue("@Name", patient.Name);
                command.Parameters.AddWithValue("@MedicId", patient.MedicId);
                command.Parameters.AddWithValue("@IsActive", patient.IsActive);
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
