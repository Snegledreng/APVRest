using APVRest.Model;

namespace APVRest.IService
{
    public interface IUserService
    {

        public void CreateUser(User creatingUser);

        public void DeleteUser(int userId);

        public void UpdateUser(User updateUser, int userId);

        public User GetUserById(int userId);

        public int LogIn(string uName, string password);

        public void LogOut();

        public int GetHttp();
    }
}
