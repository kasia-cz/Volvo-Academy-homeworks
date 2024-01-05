namespace homework2
{
    internal class CargoVehicle : Vehicle
    {
        private int CargoWeight;

        public CargoVehicle(int id, string brand, string model, int yearOfManufacture, string color, decimal price, string registrationNumber, double coefficient, int mileage, int serviceTime, int cargoWeight)
            : base(id, brand, model, yearOfManufacture, color, price, registrationNumber, coefficient, mileage, serviceTime)
        {
            CargoWeight = cargoWeight;
        }

        public override string ToString()
        {
            return $"Cargo Vehicle - ID: {Id}, Brand: {Brand}, Model: {Model}, Year Of Manufacture: {YearOfManufacture}, Color: {Color}, Price: {Price:C}, Registration Number: {RegistrationNumber}, Coefficient: {Coefficient}, Mileage: {Mileage}, Service Time: {ServiceTime}, Cargo Weight: {CargoWeight}";
        }

        public override decimal calculateRentalCosts(int tripDuration, int travelDistance)
        {
            // example rental cost calculation with these parameters
            return (decimal)(tripDuration * travelDistance * Coefficient * CargoWeight);
        }
    }
}
