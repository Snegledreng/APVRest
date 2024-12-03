using Microsoft.Data.SqlClient;

namespace APVRest.Helpers
{
    public static class GetFirstobjectIDDB
    {
        public static int ID()
        {
            string GetMinIDSQL = "SELECT MIN(UserID) FROM Dbo.[User];";
            using (SqlConnection conn = new SqlConnection(Service.Secret.TestConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(GetMinIDSQL, conn);

                SqlDataReader reader =cmd.ExecuteReader();
                if (reader.Read())
                    return reader.GetInt32(0);
                return 0;
            }
        }
    }
}
