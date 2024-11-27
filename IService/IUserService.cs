using APVRest.Model;

namespace APVRest.IService
{
    public interface IUserService
    {

        public void CreateUser(Plants creatingUser);

        public void DeleteUser(int userId);

        public void UpdateUser(Users updateUser, int userId);

        public Users GetUserById(int userId);

        public void LogIn(string uName, string password);

        public void LogOut();

        public int GetHttp();
    }
}
