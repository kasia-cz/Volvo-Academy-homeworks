namespace homework2
{
    internal class VehicleFleet
    {
        private List<Vehicle> Vehicles = new List<Vehicle>();

        public void AddVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
        }

        public void AddVehicles(IEnumerable<Vehicle> vehicles)
        {
            Vehicles.AddRange(vehicles);
        }

        public List<Vehicle> GetAllVehicles()
        {
            return Vehicles;
        }

        public List<Vehicle> GetVehiclesByBrand(string brand)
        {
            return Vehicles.Where(v => v.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Vehicle> GetVehiclesOverOperationalTenureByModel(string model)
        {
            return Vehicles.Where(v => v.Model.Equals(model, StringComparison.OrdinalIgnoreCase) &&
                ((v is PassengerVehicle && (v.ServiceTime >= 5 || v.Mileage >= 100000)) ||
                (v is CargoVehicle && (v.ServiceTime >= 15 || v.Mileage >= 1000000))))
                .ToList();
        }

        public decimal CalculateFleetValue()
        {
            return Vehicles.Sum(v => v.CalculateValue());
        }

        public List<Vehicle> GetVehiclesByBrandAndColor(string brand, string color)
        {
            return Vehicles.Where(v => v.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
                v.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(v => v is PassengerVehicle ? ((PassengerVehicle)v).LesseeRating : 0)
                .ToList();
        }

        public List<Vehicle> GetVehiclesRequiringMaintenance()
        {
            return Vehicles.Where(v => v.IsRequiringMaintenance()).ToList();
        }
    }
}
