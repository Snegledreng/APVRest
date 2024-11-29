using Microsoft.IdentityModel.Tokens;

namespace APVRest.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }

        public User(int UserID, string UserName, string Email, string Password, string City)
        {
            this.UserID = UserID;

            if (UserName.Length < 2 || UserName.Length > 19)
                throw new ArgumentException("Username must be between 2 and 19 char long(2 and 19 included)");
            this.UserName = UserName;

            if( string.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
                throw new ArgumentException("It must be a real Email");
            this.Email = Email;

            if (Password.Length < 8 || Password.Length > 18 || string.IsNullOrWhiteSpace(Password))
                throw new ArgumentException("Password must be between 9 and 17 char long(9 and 17 included)");
            this.Password = Password;

            if (string.IsNullOrWhiteSpace(City))
                throw new ArgumentException("Requires to enter the city");
            this.City = City;
        }

        public User(string UserName, string Email, string Password, string City)
        {
            UserID = 0;
            this.UserName = UserName;
            this.Email = Email;
            this.Password = Password;
            this.City = City;
        }
    }
}
