using Newtonsoft.Json.Linq;

namespace homework2
{
    internal static class JsonDataReader
    {
        public static List<Vehicle> ReadData(string filename) 
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string solutionDirectory = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\..\"));
            string filePath = Path.Combine(solutionDirectory, "Data", filename);

            string JSONString = File.ReadAllText(filePath);

            var jObject = JObject.Parse(JSONString);
            var jToken = jObject.GetValue("PassengerVehicles");

            List<PassengerVehicle> passengerVehicles = new List<PassengerVehicle>();

            if (jToken != null)
            {
                passengerVehicles = jToken.ToObject<List<PassengerVehicle>>();
            }

            jToken = jObject.GetValue("CargoVehicles");

            List<CargoVehicle> cargoVehicles = new List<CargoVehicle>();

            if (jToken != null)
            {
                cargoVehicles = jToken.ToObject<List<CargoVehicle>>();
            }

            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.AddRange(passengerVehicles);
            vehicles.AddRange(cargoVehicles);

            return vehicles.OrderBy(v => v.Id).ToList();
        }
    }
}
