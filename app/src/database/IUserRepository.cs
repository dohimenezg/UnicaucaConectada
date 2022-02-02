interface IUserRepository
{
    Boolean saveUser(User newUser);

    User? findUser(string user_id);

    Boolean deleteUser(User deleteUser);

    Boolean updateUser(User updatedUser);

    List<User> listAllUsers();

}