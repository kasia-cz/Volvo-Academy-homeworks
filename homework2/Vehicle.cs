namespace homework2
{
    internal abstract class Vehicle
    {
        public int Id;
        public string Brand;
        public string Model;
        public int YearOfManufacture;
        public string Color;
        public decimal Price;
        public string RegistrationNumber;
        public double Coefficient;
        public int Mileage;
        public int ServiceTime;

        const int MaxMileageBeforeMaintentance = 1000;

        public abstract decimal CalculateRentalCosts(int tripDuration, int travelDistance);

        public abstract decimal CalculateValue();
        public decimal CalculateValue(double valueLossCoefficient)
        {
            return Price * (decimal)Math.Pow(valueLossCoefficient, DateTime.Now.Year - YearOfManufacture);
        }

        public abstract bool IsRequiringMaintenance();
        public bool IsRequiringMaintenance(int maxMileageSinceLastMaintentance)
        {
            if (Mileage % maxMileageSinceLastMaintentance >= maxMileageSinceLastMaintentance - MaxMileageBeforeMaintentance)
            {
                return true;
            }
            return false;
        }

        protected Vehicle(int id, string brand, string model, int yearOfManufacture, string color, decimal price, string registrationNumber, double coefficient, int mileage, int serviceTime)
        {
            Id = id;
            Brand = brand;
            Model = model;
            YearOfManufacture = yearOfManufacture;
            Color = color;
            Price = price;
            RegistrationNumber = registrationNumber;
            Coefficient = coefficient;
            Mileage = mileage;
            ServiceTime = serviceTime;
        }
    }
}
