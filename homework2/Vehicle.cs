﻿namespace homework2
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

        public abstract decimal calculateRentalCosts(int tripDuration, int travelDistance);

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

        public override string ToString()
        {
            return $"Cargo Vehicle - ID: {Id}, Brand: {Brand}";
        }

    }
}