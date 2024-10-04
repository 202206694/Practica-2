namespace Practica2
{
    class PoliceCar : Vehicle
    {
        private const string typeOfVehicle = "Police Car";
        private bool isPatrolling;
        private SpeedRadar speedRadar;
        private bool isPursuing;
        private string pursuingVehiclePlate;

        public PoliceCar(string plate) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            speedRadar = new SpeedRadar();
            isPursuing = false;
            pursuingVehiclePlate = null;
        }

        public void UseRadar(Vehicle vehicle, Comisaria comisaria)
        {
            if (isPatrolling)
            {
                speedRadar.TriggerRadar(vehicle);
                string measurement = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {measurement}"));

                // Si se detecta velocidad ilegal, notifica a la comisaría
                if (vehicle.GetSpeed() > 50.0f)
                {
                    comisaria.Alerta(vehicle.GetPlate());
                }
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        // Perseguir un vehículo cuando se detecta o se recibe una notificación
        public void PerseguirVehiculo(string plate)
        {
            if (isPatrolling)
            {
                isPursuing = true;
                pursuingVehiclePlate = plate;
                Console.WriteLine(WriteMessage($"is now pursuing vehicle with plate {plate}."));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void PrintRadarHistory()
        {
            Console.WriteLine(WriteMessage("Report radar speed history:"));
            foreach (float speed in speedRadar.SpeedHistory)
            {
                Console.WriteLine(speed);
            }
        }
    }
}

