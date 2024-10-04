namespace Practica2
{
    class PoliceCar : Vehicle
    {
        private const string typeOfVehicle = "Police Car";
        private bool isPatrolling;  // Esta variable indica si el coche está patrullando
        private SpeedRadar? speedRadar;  // Radar opcional (puede ser nulo)
        private bool isPursuing;
        private string? pursuingVehiclePlate;

        public PoliceCar(string plate, SpeedRadar? radar = null) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            speedRadar = radar;
            isPursuing = false;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
        }

        // Este método devuelve si el coche está patrullando o no
        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void UseRadar(Vehicle vehicle, Comisaria comisaria)
        {
            if (speedRadar == null)
            {
                Console.WriteLine(WriteMessage("has no radar installed."));
                return;
            }

            if (isPatrolling)
            {
                speedRadar.TriggerRadar(vehicle);
                string measurement = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {measurement}"));

                if (vehicle.GetSpeed() > 50.0f)
                {
                    comisaria.Alerta(vehicle.GetPlate());
                }
            }
            else
            {
                Console.WriteLine(WriteMessage($"is not patrolling."));
            }
        }

        public void PerseguirVehiculo(string plate)
        {
            if (isPatrolling)
            {
                isPursuing = true;
                pursuingVehiclePlate = plate;
                Console.WriteLine(WriteMessage($"is now pursuing vehicle with plate {plate}."));
            }
        }
    }
}
