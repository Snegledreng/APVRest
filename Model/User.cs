using Microsoft.IdentityModel.Tokens;

namespace APVRest.Model
{
    public class User
    {
        private int _userID;
        private string _userName;
        private string _email;
        private string _password;
        private string _city;

        public int UserID
        {
            get => _userID;
            set => _userID = value;
        }

        public string UserName
        {
            get => _userName;
            set
            {
                if (value.Length < 2 || value.Length > 19)
                    throw new ArgumentException("Username must be between 2 and 19 characters long (2 and 19 included)");
                _userName = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                    throw new ArgumentException("Email must contain @");
                _email = value;
            } 
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value.Length < 8 || value.Length > 18 || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Password must be between 9 and 17 characters long (9 and 17 included)");
                _password = value;
            }
        }

        public string City
        {
            get => _city;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("City is required");
                _city = value;
            }
        }

        public User(int userId, string userName, string email, string password, string city)
        {
            this.UserID = userId;
            this.UserName = userName;
            this.Email = email;
            this.Password = password;
            this.City = city;
        }

        public User(string userName, string email, string password, string city)
        {
            UserID = 0;
            this.UserName = userName;
            this.Email = email;
            this.Password = password;
            this.City = city;
        }
    }
}
