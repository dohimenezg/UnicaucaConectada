interface IUserRepository
{
    bool saveUser(User newUser);

    User? findUser(string user_id);

    bool deleteUser(User deleteUser);

    bool updateUser(User updatedUser);

    List<User> listAllUsers();

}