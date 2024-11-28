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
            this.UserName = UserName;
            this.Email = Email;
            this.Password = Password;
            this.City = City;
        }
    }
}
