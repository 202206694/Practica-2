namespace Practica2
{
    internal class Program
    {
        static void Main()
        {
            // Crear ciudad y comisaría
            Comisaria comisaria = new Comisaria();
            Ciudad ciudad = new Ciudad(comisaria);
            Console.WriteLine("Ciudad y comisaría creadas.");

            // Registrar taxis
            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");
            ciudad.RegistrarTaxi(taxi1);
            ciudad.RegistrarTaxi(taxi2);

            // Registrar patinete
            Scooter scooter1 = new Scooter();
            Console.WriteLine(scooter1.WriteMessage("is registered in the city."));

            // Registrar coches de policía (uno con radar, otro sin radar)
            SpeedRadar radar = new SpeedRadar();
            PoliceCar policeCar1 = new PoliceCar("0001 CNP", radar);
            PoliceCar policeCar2 = new PoliceCar("0002 CNP", null);
            comisaria.RegistrarCochePolicia(policeCar1);
            comisaria.RegistrarCochePolicia(policeCar2);

            // Intento de usar radar en coche sin radar
            policeCar2.StartPatrolling();
            policeCar2.UseRadar(taxi1, comisaria);  // Este no tiene radar

            // Simulación de patrullaje y persecución
            policeCar1.StartPatrolling();
            taxi1.StartRide();
            policeCar1.UseRadar(taxi1, comisaria);

            // Eliminar un taxi por infracción
            ciudad.EliminarTaxi("0001 AAA");

            // Finalizar patrullaje
            policeCar1.EndPatrolling();
            policeCar2.EndPatrolling();
        }
    }
}
