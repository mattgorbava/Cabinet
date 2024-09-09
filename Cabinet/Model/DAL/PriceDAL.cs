using Cabinet.Model.Entities;
using Microsoft.Data.SqlClient;

namespace Cabinet.Model.DAL
{
    internal class PriceDAL
    {
        public List<Price> GetPrices()
        {
            var connection = DbHelper.Connection;
            List<Price> prices = new List<Price>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectPrices", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Price price = new Price();
                    price.PriceId = reader.GetInt32(0);
                    price.Value = reader.GetDecimal(1);
                    price.IsActive = reader.GetBoolean(2);
                    prices.Add(price);
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
            return prices;
        }

        public void AddPrice(Price price)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("AddPrice", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Value", price.Value);
                command.Parameters.AddWithValue("@IsActive", price.IsActive);
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

        public void EditPrice(Price price)
        {
            var connection = DbHelper.Connection;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EditPrice", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PriceId", price.PriceId);
                command.Parameters.AddWithValue("@Value", price.Value);
                command.Parameters.AddWithValue("@IsActive", price.IsActive);
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
