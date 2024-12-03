using APVRest.Model;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Data.SqlClient;

namespace APVRest.Helpers
{
    public static class NukeTable
    {

        public static void NukeSpecificTable<T>() where T : class
        {
            string NukeSQL = "DELETE FROM ";
            if (typeof(T) == typeof(User))
                NukeSQL += "DBO.[USER]";
            else if (typeof(T) == typeof(Plant))
                NukeSQL += "Plant";
            else
                NukeSQL += "Log";

            using (SqlConnection conn = new SqlConnection(Service.Secret.TestConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(NukeSQL, conn);


                cmd.ExecuteNonQuery();
            }
        }

    }
}
