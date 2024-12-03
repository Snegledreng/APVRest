using System.Data;
using APVRest.IService;
using APVRest.Model;
using Microsoft.Data.SqlClient;

namespace APVRest.Service
{
    public class PlantService : IPlantService
    {
        private LogService _logService = new LogService();
        public Plant GetPlantById(int plantId)
        {
            string SelectByIdSQL = "SELECT * FROM PLANT WHERE PLANTID = @PlantId";

            using (SqlConnection conn = new SqlConnection(Secret.TestConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(SelectByIdSQL, conn);
                cmd.Parameters.AddWithValue("@PlantId", plantId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    List<Log> logliste = _logService.GetAllLog(plantId);
                
                    return new Plant(reader.GetString("Name"), reader.GetInt32("DesiredHumidity"), reader.GetInt32("WaterTankVolume"), reader.GetString("IPAddress"), reader.GetString("PictureUrl"),logliste, reader.GetInt32("UserId"), reader.GetInt32("PlantID"));
                }
            }

            return null;
        }
        
        public List<Plant> GetAllPlants(int userId)
        {
            string SelectAllSQL = "SELECT * FROM PLANT WHERE USERID = @UID";

            List<Plant> listofplants = new List<Plant>();

            using (SqlConnection conn = new SqlConnection(Secret.TestConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(SelectAllSQL, conn);
                cmd.Parameters.AddWithValue("@UID", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    List<Log> logliste = _logService.GetAllLog(userId);

                    Plant p1 = new Plant(reader.GetString("Name"), reader.GetInt32("DesiredHumidity"), reader.GetInt32("WaterTankVolume"), reader.GetString("IPAddress"), reader.GetString("PictureUrl"),logliste, reader.GetInt32("UserId"), reader.GetInt32("PlantID"));
                    
                    listofplants.Add(p1);
                }
            }

            return listofplants;
        }
        
        public void CreatePlant(Plant creatingPlant)
        {
            string CreateSQL = "INSERT INTO PLANT (NAME, DESIREDHUMIDITY, WATERTANKVOLUME, IPADDRESS, USERID, PICTUREURL) VALUES (@Plantname, @Desiredhumidity, @Watertankvolume, @Ipadress, @Userid, @Pictureurl)";
            using (SqlConnection conn = new SqlConnection(Secret.TestConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(CreateSQL, conn);
                cmd.Parameters.AddWithValue("@Plantname", creatingPlant.Name);
                cmd.Parameters.AddWithValue("@Desiredhumidity", creatingPlant.DesiredHumidity);
                cmd.Parameters.AddWithValue("@Watertankvolume", creatingPlant.WaterTankVolume);
                cmd.Parameters.AddWithValue("@Ipadress", creatingPlant.IPAddress);
                cmd.Parameters.AddWithValue("@Userid", creatingPlant.UserId);

                if (creatingPlant.PictureUrl == null)
                    cmd.Parameters.AddWithValue("@Pictureurl", DBNull.Value);
                
                else
                    cmd.Parameters.AddWithValue("@Pictureurl", creatingPlant.PictureUrl);
                        
                int RowAffected = cmd.ExecuteNonQuery();
                
                if (RowAffected == 0)
                    throw new Exception("Something went wrong");
            }
        }
        
        public void DeletePlant(int plantId)
        {
            string DeleteSQL = "DELETE FROM PLANT WHERE PLANTID = @PLANTID";
            using (SqlConnection conn = new SqlConnection(Service.Secret.TestConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(DeleteSQL, conn);
                cmd.Parameters.AddWithValue("@PLANTID", plantId);
                int RowAffected = cmd.ExecuteNonQuery();
                if (RowAffected == 0)
                    throw new Exception("The deleted plant never existed");
            }
        }

        public void UpdatePlant(Plant updatePlant, int plantId)
        {
            string UpdateSQL = "UPDATE PLANT SET NAME = @Name, DESIREDHUMIDITY = @Desiredhumidity, WATERTANKVOLUME = @Watertankvolume, IPADDRESS = @Ipaddress, PICTUREURL = @Pictureurl WHERE PLANTID = @PLANTID";
            using (SqlConnection conn = new SqlConnection(Service.Secret.TestConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(UpdateSQL, conn);
                cmd.Parameters.AddWithValue("@Name", updatePlant.Name);
                cmd.Parameters.AddWithValue("@Desiredhumidity", updatePlant.DesiredHumidity);
                cmd.Parameters.AddWithValue("@Watertankvolume", updatePlant.WaterTankVolume);
                cmd.Parameters.AddWithValue("@Ipaddress", updatePlant.IPAddress);
                
                if (updatePlant.PictureUrl == null)
                    cmd.Parameters.AddWithValue("@Pictureurl", DBNull.Value);
                
                else
                    cmd.Parameters.AddWithValue("@Pictureurl", updatePlant.PictureUrl);
                cmd.Parameters.AddWithValue("@PLANTID", plantId);
                
                int RowAffected = cmd.ExecuteNonQuery();
                if (RowAffected == 0)
                    throw new Exception("The plant you tried to update doesn't exist");
            }
        }
    }
}
