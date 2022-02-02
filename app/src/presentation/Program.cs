// See https://aka.ms/new-console-template for more information
using MongoDB.Driver;

Console.WriteLine("Hello, World!");


var myNewUser = new User() { nombre = "David", nombre_usuario = "dohimenez", contrasena = "pass123", correo = "ojime@unicauca.edu.co"};
EventRepository EventRepository = new EventRepository();
UserRepository UserRepository = new UserRepository();

if (UserRepository.saveUser(myNewUser))
{
    Console.WriteLine("Save Successfully");
}
else
{
    Console.WriteLine("ERROR Couldn't save");
}

Event event1 = new Event("Matriculas2022", "Inicio de matriculas del 2do periodo de 2022", DateTime.Parse("2022-02-01"), DateTime.Parse("2022-02-03"));
Event event2 = new Event("Doomsday", "HAPPY DOOMSDAY", DateTime.Parse("2022-02-20"), DateTime.Parse("2022-02-21"));

if (EventRepository.saveEvent(event1))
{
    Console.WriteLine("Save Successfully");
}else
{
    Console.WriteLine("ERROR Couldn't save");
}

if (EventRepository.saveEvent(event2))
{
    Console.WriteLine("Save Successfully");
}
else
{
    Console.WriteLine("ERROR Couldn't save");
}



event2 = EventRepository.findEvent("61f9fa67d30e435e0d504463");

if (event2 != null)
{
    Console.WriteLine("FOUND ELEMENT 2 !");
    event2.descripcion = "NO DOOMSDAY FOR YOU!!!!";
}

event1 = EventRepository.findEvent("61f9fa66d30e435e0d504462");
if (event1 != null)
{
    Console.WriteLine("FOUND ELEMENT 1 !");
}


if (EventRepository.deleteEvent(event1))
{
    Console.WriteLine("DELETE SUCCESSFULL");
}
if (EventRepository.updateEvent(event2))
{
    Console.WriteLine("UPDATE SUCCESSFULL");
}

List<Event> list = EventRepository.listAllEvents();

foreach (var item in list)
{
    Console.WriteLine(item.descripcion);
}





