namespace APVRest.Model
{
    public record UserModelDTO
    {
        public record UserDTO(int userId, string userName, string email, string password, string city);

        public static User UserDTO2User(UserDTO user)
        {
            return new User(user.userId, user.userName, user.email, user.password, user.city);
        }

    }
}
