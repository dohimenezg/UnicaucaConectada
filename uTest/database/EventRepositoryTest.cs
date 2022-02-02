using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace uTest.database
{
    public class EventRepositoryTest
    {
        [Test]
        public void TestEventRepoSaveEvent()
        {
            string varTitulo = "Evento";
            string varDescripcion = "Concierto";
            DateTime varFecha_Inicio = DateTime.Parse("2022-02-01");
            DateTime varFecha_Final = DateTime.Parse("2022-02-02");
            Event varEvent = new Event(varTitulo, varDescripcion, varFecha_Inicio, varFecha_Final);

            EventRepository varEventRepository = new EventRepository();
            Assert.IsTrue(varEventRepository.saveEvent(varEvent));
        }

        [Test]
        public void TestEventRepoUpdateEvent()
        {
            EventRepository varEventRepository = new EventRepository();
            List<Event> varEventList = varEventRepository.listAllEvents();
            Assert.IsNotNull(varEventList);

            Event varEvent = varEventList[0];
            Assert.IsNotNull(varEvent);
            string varNewTitle = "Otro Evento";
            varEvent.titulo = varNewTitle;
            Assert.IsTrue(varEventRepository.updateEvent(varEvent));
            Event varFindEvent = varEventRepository.findEvent(varEvent.id);
            Assert.IsNotNull(varFindEvent);
            Assert.AreEqual(varFindEvent.id, varEvent.id);
            Assert.AreEqual(varFindEvent.titulo, varNewTitle);
        }
        [Test]
        public void TestEventRepoDeleteEvent()
        {
            EventRepository varEventRepository = new EventRepository();
            List<Event> varEventList = varEventRepository.listAllEvents();
            Assert.IsNotNull(varEventList);

            Event varEvent = varEventList[0];
            Assert.IsNotNull(varEvent);
            Assert.IsTrue(varEventRepository.deleteEvent(varEvent));
        }

        [Test]
        public void TestEventRepoListAllEvents()
        {
            EventRepository varEventRepository = new EventRepository();
            Assert.IsNotNull(varEventRepository.listAllEvents());
        }

        [Test]
        public void TestEventRepoSearchEvent()
        {
            EventRepository varEventRepository = new EventRepository();
            List<Event> varEventList = varEventRepository.listAllEvents();
            Assert.IsNotNull(varEventList);

            Event varEvent = varEventList[0];
            Assert.IsNotNull(varEvent);
            Event varFindEvent = varEventRepository.findEvent(varEvent.id);
            Assert.IsNotNull(varFindEvent);
            Assert.AreEqual(varFindEvent.id, varEvent.id);
            Assert.AreEqual(varFindEvent.titulo, varEvent.titulo);
        }
    }
}