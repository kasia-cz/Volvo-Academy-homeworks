namespace homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fleet = new VehicleFleet();

            var vehicleList = JsonDataReader.ReadData("fleet.json");
            fleet.AddVehicles(vehicleList);

            var vehicles = fleet.GetAllVehicles();
            //var vehicles = fleet.GetVehiclesByBrand("brand1");
            //var vehicles = fleet.GetVehiclesOverOperationalTenureByModel("Model4");
            //var vehicles = fleet.GetVehiclesByBrandAndColor("Brand4", "red");
            //var vehicles = fleet.GetVehiclesRequiringMaintenance();

            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle} \n");
            }

            Console.WriteLine($"Fleet value: {fleet.CalculateFleetValue():C}");
        }
    }
}
