using NUnit.Framework;
using System;

namespace uTest.logic
{
    public class EventTest
    {
        [Test]
        public void TestEventConstructorParams()
        {
            string varTitulo = "Evento 1";
            string varDescripcion = "Concierto";
            DateTime varFecha_Inicio = DateTime.Parse("2022-02-01");
            DateTime varFecha_Final = DateTime.Parse("2022-02-02");
            Event evento = new Event(varTitulo, varDescripcion, varFecha_Inicio, varFecha_Final);
            Assert.AreEqual(evento.titulo, varTitulo);
            Assert.AreEqual(evento.descripcion, varDescripcion);
            Assert.AreEqual(evento.fecha_inicio, varFecha_Inicio);
            Assert.AreEqual(evento.fecha_final, varFecha_Final);
        }
    }
}