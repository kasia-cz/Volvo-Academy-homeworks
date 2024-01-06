namespace homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome in leasing company system!\n");

            var fleet = new VehicleFleet();

            var vehicleList = JsonDataReader.ReadData("fleet.json");
            fleet.AddVehicles(vehicleList);

            bool runProgram = true;
            while (runProgram)
            {
                Console.WriteLine("""
                    Select the option you want to perform by entering the number:
                    1. Show a list of all vehicles owned.
                    2. Show a list of vehicles of specified brand.
                    3. Show a list of vehicles of a chosen model that have exceeded a predetermined operational tenure.
                    4. Calculate total value of the entire vehicle fleet owned.
                    5. Show a list of vehicles of specified brand and color sorted by comfort class.
                    6. Show a list of vehicles that are within 1000 km of requiring maintenance.
                    Or type 'exit' to end the program.
                    """);

                var optionInput = Console.ReadLine();

                if (optionInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (!int.TryParse(optionInput, out int option) || option < 1 || option > 6)
                {
                    Console.WriteLine("Wrong input.\n");
                    continue;
                }

                List<Vehicle> vehicles;

                switch (option)
                {
                    case 1:
                        vehicles = fleet.GetAllVehicles();
                        ShowVehicleList(vehicles);
                        break;
                    case 2:
                        Console.WriteLine("Type brand:");
                        var brandInput = Console.ReadLine();
                        vehicles = fleet.GetVehiclesByBrand(brandInput);
                        ShowVehicleList(vehicles);
                        break;
                    case 3:
                        Console.WriteLine("Type model:");
                        var modelInput = Console.ReadLine();
                        vehicles = fleet.GetVehiclesOverOperationalTenureByModel(modelInput);
                        ShowVehicleList(vehicles);
                        break;
                    case 4:
                        Console.WriteLine($"Fleet value: {fleet.CalculateFleetValue():C}");
                        break;
                    case 5:
                        Console.WriteLine("Type brand:");
                        var brandInput2 = Console.ReadLine();
                        Console.WriteLine("Type color:");
                        var colorInput = Console.ReadLine();
                        vehicles = fleet.GetVehiclesByBrandAndColor(brandInput2, colorInput);
                        ShowVehicleList(vehicles);
                        break;
                    case 6:
                        vehicles = fleet.GetVehiclesRequiringMaintenance();
                        ShowVehicleList(vehicles);
                        break;
                }

                Console.WriteLine("Type 'exit' to end the program or press enter to continue.");
                var exitInput = Console.ReadLine();
                runProgram = !exitInput.Equals("exit", StringComparison.OrdinalIgnoreCase);
            }
            Console.WriteLine("Program ended. Goodbye!");
        }

        private static void ShowVehicleList(List<Vehicle> vehicles)
        {
            if (vehicles.Any())
            {
                Console.WriteLine("\nList of vehicles meeting the search conditions:\n");
                foreach (Vehicle vehicle in vehicles)
                {
                    Console.WriteLine($"{vehicle} \n");
                }
            } else {
                Console.WriteLine("Wrong input or there are no vehicles meeting the search conditions.");
            }
        }
    }
}
