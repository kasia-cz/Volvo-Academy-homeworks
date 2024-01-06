namespace homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fleet = new VehicleFleet();

            fleet.AddVehicle(new PassengerVehicle(1, "Brand1", "Model1", 2019, "Black", 150000, "ABC123", 1.05, 50000, 2, 8));
            fleet.AddVehicle(new PassengerVehicle(2, "Brand1", "Model2", 2016, "Blue", 100000, "ABC456", 1.07, 90000, 6, 7));
            fleet.AddVehicle(new CargoVehicle(3, "Brand3", "Model3", 2015, "White", 200000, "DEF123", 1.1, 380000, 7, 1800));
            fleet.AddVehicle(new CargoVehicle(4, "Brand4", "Model4", 2005, "Red", 250000, "DEF456", 1, 1199900, 10, 3000));
            fleet.AddVehicle(new CargoVehicle(5, "Brand4", "Model4", 2005, "Red", 250000, "DEF789", 1, 700000, 14, 3000));
            fleet.AddVehicle(new PassengerVehicle(6, "Brand4", "Model5", 2017, "Red", 300000, "ABC666", 1.1, 34500, 4, 8.5));
            fleet.AddVehicle(new PassengerVehicle(7, "Brand4", "Model6", 2018, "Red", 400000, "ABC777", 1.1, 15000, 3, 9));


            //var vehicles = fleet.GetAllVehicles();
            //var vehicles = fleet.GetVehiclesByBrand("brand1");
            //var vehicles = fleet.GetVehiclesOverOperationalTenureByModel("Model4");
            //var vehicles = fleet.GetVehiclesByBrandAndColor("Brand4", "red");
            var vehicles = fleet.GetVehiclesRequiringMaintenance();

            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle} \n");
            }

            Console.WriteLine($"Fleet value: {fleet.CalculateFleetValue():C}");
        }
    }
}
