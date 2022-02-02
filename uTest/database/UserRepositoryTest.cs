using NUnit.Framework;
using System.Collections.Generic;

namespace uTest.database
{
    public class UserRepositoryTest
    {
        [Test]
        public void TestUserRepoSaveUser()
        {
            string varNombre = "Carlos";
            string varUsuario = "carlos10";
            string varContrasena = "c95";
            string varCorreo = "carlos@unicauca.edu.co";
            User varUser = new User() { nombre = varNombre, nombre_usuario = varUsuario, contrasena = varContrasena, correo = varCorreo };

            UserRepository varUserRepository = new UserRepository();
            Assert.IsTrue(varUserRepository.saveUser(varUser));
        }

        [Test]
        public void TestUserRepoUpdateUser()
        {
            UserRepository varUserRepository = new UserRepository();
            List<User> varUserList = varUserRepository.listAllUsers();
            Assert.IsNotNull(varUserList);

            User varUser = varUserList[0];
            Assert.IsNotNull(varUser);
            string varNewName = "Maria";
            varUser.nombre = varNewName;
            Assert.IsTrue(varUserRepository.updateUser(varUser));
            User varFindUser = varUserRepository.findUser(varUser.id);
            Assert.IsNotNull(varFindUser);
            Assert.AreEqual(varFindUser.id, varUser.id);
            Assert.AreEqual(varFindUser.nombre, varNewName);
        }

        [Test]
        public void TestUserRepoDeleteUser()
        {
            UserRepository varUserRepository = new UserRepository();
            List<User> varUserList = varUserRepository.listAllUsers();
            Assert.IsNotNull(varUserList);

            User varUser = varUserList[0];
            Assert.IsNotNull(varUser);
            Assert.IsTrue(varUserRepository.deleteUser(varUser));
        }

        [Test]
        public void TestUserRepoListAllUsers()
        {
            UserRepository varUserRepository = new UserRepository();
            Assert.IsNotNull(varUserRepository.listAllUsers());
        }

        [Test]
        public void TestUserRepoSearchUser()
        {
            UserRepository varUserRepository = new UserRepository();
            List<User> varUserList = varUserRepository.listAllUsers();
            Assert.IsNotNull(varUserList);

            User varUser = varUserList[0];
            Assert.IsNotNull(varUser);
            User varFindUser = varUserRepository.findUser(varUser.id);
            Assert.IsNotNull(varFindUser);
            Assert.AreEqual(varFindUser.id, varUser.id);
            Assert.AreEqual(varFindUser.nombre, varUser.nombre);
        }
    }
}