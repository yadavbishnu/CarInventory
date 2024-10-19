using System;

namespace CarInventory
{
    internal class Car
    {
        // Properties
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public bool IsNew { get; set; }

        // Default constructor
        public Car()
        {
            Make = "Unknown";
            Model = "Unknown";
            Year = DateTime.Now.Year;
            Color = "Unknown";
            Price = 0;
            IsNew = false;
        }

        // Parameterized constructor
        public Car(string make, string model, int year, string color, decimal price, bool isNew)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            Price = price;
            IsNew = isNew;
        }

        // Override ToString to display the car's details in the ListView
        public override string ToString()
        {
            return $"{Year} {Make} {Model}, {Color}, Price: {Price:C}, {(IsNew ? "New" : "Used")}";
        }
    }
}
