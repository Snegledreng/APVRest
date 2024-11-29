using APVRest.IService;
using APVRest.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace APVRest.Service
{
    public class UserService : IUserService
    {
        public User GetUserById(int userId)
        {
            string SelectByIdSQL = "SELECT * FROM  DBO.[USER] WHERE USERID = @UID;";

            using (SqlConnection conn = new SqlConnection(Service.Secret.TestConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(SelectByIdSQL, conn);
                cmd.Parameters.AddWithValue("@UID", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return new User( reader.GetInt32("UserID"), reader.GetString("Username"), reader.GetString("Email"), reader.GetString("Password"), reader.GetString("City") );
            }
            return null;
        }


        public void CreateUser(User creatingUser)
        {
            string CreateSQL = "INSERT INTO DBO.[USER](Username,Email, Password, City) VALUES (@Username,@Email, @Password, @City);";
            using (SqlConnection conn = new SqlConnection(Service.Secret.TestConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(CreateSQL, conn);
                cmd.Parameters.AddWithValue("@Username", creatingUser.UserID);
                cmd.Parameters.AddWithValue("@Email", creatingUser.Email);
                cmd.Parameters.AddWithValue("@Password", creatingUser.Password);
                cmd.Parameters.AddWithValue("@City", creatingUser.City);
                int RowAffected = cmd.ExecuteNonQuery();
                if (RowAffected == 0)
                    throw new Exception("something went wrong");
            }
        }


        public void DeleteUser(int userId)
        {
            string DeleteSQL = "DELETE FROM DBO.[USER] WHERE USERID = @UID";
            using (SqlConnection conn = new SqlConnection(Service.Secret.TestConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(DeleteSQL, conn);
                cmd.Parameters.AddWithValue("@UID", userId);
                int RowAffected = cmd.ExecuteNonQuery();
                if (RowAffected == 0)
                    throw new Exception("The deleted user never existed");
            }
        }


        public void UpdateUser(User updateUser, int userId)
        {
            string UpdateSQL = "UPDATE DBO.[USER] SET USERNAME = @USERNAME, Email = @Email, Password = @Password, City = @City WHERE USERID = @UID";
            using (SqlConnection conn = new SqlConnection(Service.Secret.TestConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(UpdateSQL, conn);
                cmd.Parameters.AddWithValue("@UID", userId);
                cmd.Parameters.AddWithValue("@Username", updateUser.UserID);
                cmd.Parameters.AddWithValue("@Email", updateUser.Email);
                cmd.Parameters.AddWithValue("@Password", updateUser.Password);
                cmd.Parameters.AddWithValue("@City", updateUser.City);
                int RowAffected = cmd.ExecuteNonQuery();
                if (RowAffected == 0)
                    throw new Exception("The user you tried to update doesn't exist");
            }
        }


        public int GetHttp()
        {
            throw new NotImplementedException();
        }

        public void LogIn(string uName, string password)
        {
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }


    }
}
