using APVRest.Model;

namespace APVRest.IService
{
    public interface IUserService
    {

        public void CreateUser(Plants CreatingUser);

        public void DeleteUser(int UserId);

        public void UpdateUser(Users UpdateUser, int UserId);

        public Users GetUserById(int UserId);

        public void LogIn(string UName, string Password);

        public void LogOut();

        public int GetHttp();
    }
}
