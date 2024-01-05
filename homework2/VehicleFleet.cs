namespace homework2
{
    internal class VehicleFleet
    {
        private List<Vehicle> vehicles = new List<Vehicle>();

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public List<Vehicle> GetAllVehicles()
        {
            return vehicles;
        }
    }
}
