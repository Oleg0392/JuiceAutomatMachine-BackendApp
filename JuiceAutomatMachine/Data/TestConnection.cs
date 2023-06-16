using Microsoft.Data.SqlClient;

namespace JuiceAutomatMachine.Data
{
    public static class TestConnection
    {
        public static void Test()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DEVELOP-MGN\\SQLEXPRESS;Initial Catalog=msdb;Trust Server Certificate=True;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            sqlConnection.Close();
        }
    }
}
