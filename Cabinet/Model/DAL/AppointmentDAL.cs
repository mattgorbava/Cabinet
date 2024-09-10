using Cabinet.Model.Entities;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;

namespace Cabinet.Model.DAL
{
    class AppointmentDAL
    {
        public List<Appointment> GetAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            var connection = DbHelper.Connection;
            try
            {
                connection.Open(); 
                SqlCommand command = new SqlCommand("SelectAppointments", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Appointment appointment = new Appointment();
                    appointment.AppointmentId = reader.GetInt32(0);
                    appointment.Date = reader.GetDateTime(1);
                    appointment.PatientId = reader.GetInt32(2);
                    appointment.MedicId = reader.GetInt32(3);
                    appointment.IsActive = reader.GetBoolean(4);
                    appointments.Add(appointment);
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
            return appointments;
        }

        public void AddAppointment(Appointment appointment)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddAppointment", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Date", appointment.Date);
                command.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                command.Parameters.AddWithValue("@MedicId", appointment.MedicId);
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

        public void EditAppointment(Appointment appointment)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EditAppointment", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AppointmentId", appointment.AppointmentId);
                command.Parameters.AddWithValue("@Date", appointment.Date);
                command.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                command.Parameters.AddWithValue("@MedicId", appointment.MedicId);
                command.Parameters.AddWithValue("@IsActive", appointment.IsActive);
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
