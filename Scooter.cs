namespace Practica2
{
    class Scooter : Vehicle
    {
        private static string typeOfVehicle = "Scooter";

        public Scooter() : base(typeOfVehicle)
        {
            SetSpeed(25.0f); // Velocidad inicial
        }

        public void Accelerate()
        {
            SetSpeed(GetSpeed() + 10.0f);
            Console.WriteLine(WriteMessage($"accelerates to {GetSpeed()} km/h."));
        }
    }
}
