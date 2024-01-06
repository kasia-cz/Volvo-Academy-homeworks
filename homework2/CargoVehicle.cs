namespace homework2
{
    internal class CargoVehicle : Vehicle
    {
        public int CargoWeight;

        const double ValueLossCoefficient = 0.93;
        const int MaxMileageSinceLastMaintentance = 15000;

        public CargoVehicle(int id, string brand, string model, int yearOfManufacture, string color, decimal price, string registrationNumber, double coefficient, int mileage, int serviceTime, int cargoWeight)
            : base(id, brand, model, yearOfManufacture, color, price, registrationNumber, coefficient, mileage, serviceTime)
        {
            CargoWeight = cargoWeight;
        }

        public override string ToString()
        {
            return $"Cargo Vehicle - ID: {Id}, Brand: {Brand}, Model: {Model}, Year Of Manufacture: {YearOfManufacture}, Color: {Color}, Price: {Price:C}, Registration Number: {RegistrationNumber}, Coefficient: {Coefficient}, Mileage: {Mileage} km, Service Time: {ServiceTime} years, Cargo Weight: {CargoWeight} kg";
        }

        public override decimal CalculateRentalCosts(int tripDuration, int travelDistance)
        {
            // example rental cost calculation with these parameters
            return (decimal)(tripDuration * travelDistance * Coefficient * CargoWeight);
        }

        public override decimal CalculateValue()
        {
            return CalculateValue(ValueLossCoefficient);
        }

        public override bool IsRequiringMaintenance()
        {
            return IsRequiringMaintenance(MaxMileageSinceLastMaintentance);
        }
    }
}
