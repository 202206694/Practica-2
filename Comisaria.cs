namespace Practica2
{
    class Comisaria
    {
        private List<PoliceCar> policeCars;
        public Comisaria()
        {
            policeCars = new List<PoliceCar>();
        }

        // Registra un coche de policía en la comisaría
        public void RegistrarCochePolicia(PoliceCar policeCar)
        {
            policeCars.Add(policeCar);
            Console.WriteLine($"Comisaria: PoliceCar with plate {policeCar.GetPlate()} has been registered.");
        }

        // Notifica una alerta a todos los coches de policía
        public void Alerta(string infractorPlate)
        {
            Console.WriteLine($"Alerta: vehicule eith plate {infractorPlate} went over the leagl speed limit.");
            foreach (var policeCar in policeCars)
            {
                if (policeCar.IsPatrolling())
                {
                    policeCar.PerseguirVehiculo(infractorPlate);
                }
            }
        }
    }
}