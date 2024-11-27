namespace APVRest.Model
{
    public class Users
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CityOrPostNr { get; set; }

        public Users(int UserId, string UserName, string Email, string Password, string CityOrPostNr)
        {
            this.UserID = UserId;
            this.UserName = UserName;
            this.Email = Email;
            this.Password = Password;
            this.CityOrPostNr = CityOrPostNr;
        }
    }
}
