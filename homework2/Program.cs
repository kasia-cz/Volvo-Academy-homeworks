namespace homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fleet = new VehicleFleet();

            fleet.AddVehicle(new PassengerVehicle(1,"Brand1","Model1",2019,"Black",100000,"ABC123",1.05,14000,2,8));
            fleet.AddVehicle(new CargoVehicle(2,"Brand2","Model2",2015,"White",200000,"DEF456",1,380000,7,1800));

            var vehicles = fleet.GetAllVehicles();

            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle} \n");
            }
        }
    }
}
