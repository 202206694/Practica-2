namespace Practica2
{
    internal class Program
    {
        static void Main()
        {
            // Crear la comisaría
            Comisaria comisaria = new Comisaria();

            // Crear la ciudad y registrar taxis
            Ciudad ciudad = new Ciudad(comisaria);
            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");
            ciudad.RegistrarTaxi(taxi1);
            ciudad.RegistrarTaxi(taxi2);

            // Crear coches de policía y registrarlos en la comisaría
            PoliceCar policeCar1 = new PoliceCar("0001 CNP");
            PoliceCar policeCar2 = new PoliceCar("0002 CNP");
            comisaria.RegistrarCochePolicia(policeCar1);
            comisaria.RegistrarCochePolicia(policeCar2);

            // Simulación
            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1, comisaria);

            taxi2.StartRide();
            policeCar2.UseRadar(taxi2, comisaria);
            policeCar2.StartPatrolling();
            policeCar2.UseRadar(taxi2, comisaria);
            taxi2.StopRide();
            policeCar2.EndPatrolling();

            taxi1.StartRide();
            policeCar1.UseRadar(taxi1, comisaria);
            taxi1.StopRide();
            policeCar1.EndPatrolling();

            policeCar1.PrintRadarHistory();
            policeCar2.PrintRadarHistory();

            // Eliminar un taxi
            ciudad.EliminarTaxi("0002 BBB");
        }
    }
}