using NUnit.Framework;

namespace uTest.logic
{
    public class UserTest
    {
        [Test]
        public void TestUserConstructorParams()
        {
            string varNombre = "Carlos";
            string varUsuario = "carlos10";
            string varContrasena = "c95";
            string varCorreo = "carlos@unicauca.edu.co";
            User user = new User() { nombre = varNombre, nombre_usuario = varUsuario, contrasena = varContrasena, correo = varCorreo};
            Assert.AreEqual(varNombre, user.nombre);
            Assert.AreEqual(varUsuario, user.nombre_usuario);
            Assert.AreEqual(varContrasena, user.contrasena);
            Assert.AreEqual(varCorreo, user.correo);
        }
    }
}