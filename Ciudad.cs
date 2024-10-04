namespace Practica2
{
    class Ciudad
    {
        private List<Taxi> taxis;
        private Comisaria comisaria;

        public Ciudad(Comisaria comisaria)
        {
            this.comisaria = comisaria;
            taxis = new List<Taxi>();
        }

        // Registro de taxis
        public void RegistrarTaxi(Taxi taxi)
        {
            taxis.Add(taxi);
            Console.WriteLine($"Ciudad: Taxi con matrícula {taxi.GetPlate()} registrado.");
        }

        // Eliminar taxis
        public void EliminarTaxi(string plate)
        {
            Taxi taxi = taxis.Find(t => t.GetPlate() == plate);
            if (taxi != null)
            {
                taxis.Remove(taxi);
                Console.WriteLine($"Ciudad: Taxi con matrícula {plate} eliminado.");
            }
            else
            {
                Console.WriteLine($"Ciudad: Taxi con matrícula {plate} no encontrado.");
            }
        }
    }
}
