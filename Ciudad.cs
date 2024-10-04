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

        public void RegistrarTaxi(Taxi taxi)
        {
            taxis.Add(taxi);
            Console.WriteLine($"Ciudad: Taxi with plate {taxi.GetPlate()} has been registered.");
        }

        // Eliminar taxis
        public void EliminarTaxi(string plate)
        {
            Taxi taxi = taxis.Find(t => t.GetPlate() == plate);
            if (taxi != null)
            {
                taxis.Remove(taxi);
                Console.WriteLine($"Ciudad: Taxi with plate {plate} has been eliminated.");
            }
            else
            {
                Console.WriteLine($"Ciudad: Taxi  not found.");
            }
        }
    }
}
