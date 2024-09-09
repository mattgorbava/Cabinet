using Microsoft.Data.SqlClient;

namespace Cabinet.Model.DAL
{
    internal class SqlValidator
    {
        public static bool ValidateCommand(SqlCommand command)
        {
            foreach (SqlParameter parameter in command.Parameters)
            {
                if (ValidateParameter(parameter))
                    return false;
            }
            return true;
        }

        static bool ValidateParameter(SqlParameter parameter)
        {
            string upperCaseValue = parameter.SqlValue.ToString().ToUpper();
            if (upperCaseValue.Contains("SELECT") ||
                upperCaseValue.Contains("UPDATE") ||
                upperCaseValue.Contains("DELETE") ||
                upperCaseValue.Contains("INSERT"))
                return false;
            return true;
        }
    }
}
