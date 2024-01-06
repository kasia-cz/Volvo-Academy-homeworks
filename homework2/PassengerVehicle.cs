namespace homework2
{
    internal class PassengerVehicle : Vehicle
    {
        public double LesseeRating;

        public PassengerVehicle(int id, string brand, string model, int yearOfManufacture, string color, decimal price, string registrationNumber, double coefficient, int mileage, int serviceTime, double leeseRating)
            : base(id, brand, model, yearOfManufacture, color, price, registrationNumber, coefficient, mileage, serviceTime)
        {
            LesseeRating = leeseRating;
        }

        public override string ToString()
        {
            return $"Passenger Vehicle - ID: {Id}, Brand: {Brand}, Model: {Model}, Year Of Manufacture: {YearOfManufacture}, Color: {Color}, Price: {Price:C}, Registration Number: {RegistrationNumber}, Coefficient: {Coefficient}, Mileage: {Mileage} km, Service Time: {ServiceTime} years, Lessee's Rating: {LesseeRating}";
        }

        public override decimal CalculateRentalCosts(int tripDuration, int travelDistance)
        {
            // example rental cost calculation with these parameters
            return (decimal)(tripDuration * travelDistance * Coefficient * LesseeRating);
        }

        public override decimal CalculateValue()
        {
            return Price * (decimal)Math.Pow(0.93, DateTime.Now.Year - YearOfManufacture);
        }

        public override bool IsRequiringMaintenance()
        {
            if (Mileage % 5000 >= 4000)
            {
                return true;
            }
            return false;
        }
    }
}
