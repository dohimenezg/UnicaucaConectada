using EventosVista.Source.Model;
using System;
using System.Collections.Generic;

namespace EventosVista.Source.Access
{
    interface IUserRepository
    {
        Boolean saveUser(User newUser);

        User? findUser(string user_id);

        Boolean deleteUser(User deletedUser);

        Boolean updateUser(User updatedUser);

        List<User> listAllUsers();

    }
}

