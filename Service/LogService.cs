using APVRest.IService;
using APVRest.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;

namespace APVRest.Service
{
    public class LogService : ILogService
    {
        public List<Log> GetAllLog(int plantId)
        {
            string SelectAllSQL = "SELECT * FROM LOG WHERE PLANTID = @PlantId";
            List<Log> list = new List<Log>();

            using (SqlConnection conn = new SqlConnection(Secret.TestConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(SelectAllSQL, conn);
                cmd.Parameters.AddWithValue("@PlantId", plantId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Log l1 = new Log(reader.GetInt32("PlantID"), reader.GetDateTime("Timestamp"), reader.GetInt32("Humidity"), reader.GetInt32("RemainingWater"));
                    list.Add(l1);
                }
            }
            return list;
        }

        public Log GetLogById(int plantId, DateTime dateTime)
        {
            string SelectbyIdSQL = "SELECT * FROM LOG WHERE PLANTID = @PlantId AND TIMESTAMP = @Timestamp";

            using (SqlConnection conn = new SqlConnection(Secret.TestConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(SelectbyIdSQL, conn);
                cmd.Parameters.AddWithValue("@PlantId", plantId);
                cmd.Parameters.AddWithValue("@Timestamp", dateTime);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Log(reader.GetInt32("PlantID"), reader.GetDateTime("Timestamp"), reader.GetInt32("Humidity"), reader.GetInt32("RemainingWater"));
                }
            }
            return null;
        }


        public void CreateLog(Log log)
        {
            string CreateSQL = "INSERT INTO LOG (PlantID, Timestamp, Humidity, RemainingWater) VALUES (@Plantid, @Timestamp, @Humidity, @Remainingwater)";
            using (SqlConnection conn = new SqlConnection(Secret.TestConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(CreateSQL, conn);
                cmd.Parameters.AddWithValue("@Plantid", log.Plantid);
                cmd.Parameters.AddWithValue("@Timestamp", log.Timestamp);
                cmd.Parameters.AddWithValue("@Humidity", log.Humidity);
                cmd.Parameters.AddWithValue("@Remainingwater", log.Remainingwater);

                int RowAffected = cmd.ExecuteNonQuery();

                if (RowAffected == 0)
                    throw new Exception("Something went wrong");
            }
        }

        public void DeleteLog(int plantId, DateTime dateTime)
        {
            string DeleteSQL = "DELETE FROM LOG WHERE PLANTID = @PlantId AND TIMESTAMP = @Timestamp";

            using (SqlConnection conn = new SqlConnection(Secret.TestConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(DeleteSQL, conn);
                cmd.Parameters.AddWithValue("@PlantId", plantId);
                cmd.Parameters.AddWithValue("@Timestamp", dateTime);
                int RowAffected = cmd.ExecuteNonQuery();

                if (RowAffected == 0)
                    throw new Exception("Something went wrong");
            }

        }
    }
}
