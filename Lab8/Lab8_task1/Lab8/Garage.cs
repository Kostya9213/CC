using System;
using System.Collections.Generic;

class Garage
{
    private List<Car> cars;

    public Garage()
    {
        cars = new List<Car>();
    }

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public void RemoveCar(Car car)
    {
        cars.Remove(car);
    }

    public List<Car> FindCarsByCriteria(Car searchCar)
    {
        List<Car> matchingCars = new List<Car>();

        foreach (Car car in cars)
        {
            if (MatchCar(car, searchCar))
            {
                matchingCars.Add(car);
            }
        }

        return matchingCars;
    }

    private bool MatchCar(Car car, Car searchCar)
    {
        return (string.IsNullOrEmpty(searchCar.Name) || car.Name.Equals(searchCar.Name, StringComparison.OrdinalIgnoreCase))
            && (string.IsNullOrEmpty(searchCar.Color) || car.Color.Equals(searchCar.Color, StringComparison.OrdinalIgnoreCase))
            && (searchCar.Speed == 0 || car.Speed == searchCar.Speed)
            && (searchCar.Year == 0 || car.Year == searchCar.Year);
    }
}

class Car
{
    public string Name { get; set; }
    public string Color { get; set; }
    public int Speed { get; set; }
    public int Year { get; set; }

    public Car(string name, string color, int speed, int year)
    {
        Name = name;
        Color = color;
        Speed = speed;
        Year = year;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Garage sheikhGarage = new Garage();

        Car car1 = new Car("BMW", "Blue", 310, 2019);
        Car car2 = new Car("Ford", "White", 350, 2015);
        Car car3 = new Car("Ferrari", "Red", 400, 2022);

        sheikhGarage.AddCar(car1);
        sheikhGarage.AddCar(car2);
        sheikhGarage.AddCar(car3);

        Console.WriteLine("All cars in the sheikh's garage:");
        List<Car> allCars = sheikhGarage.FindCarsByCriteria(new Car(null, null, 0, 0));
        PrintCars(allCars);

        Console.WriteLine("\nCars with color 'Red':");
        List<Car> redCars = sheikhGarage.FindCarsByCriteria(new Car(null, "Red", 0, 0));
        PrintCars(redCars);

        Console.WriteLine("\nCars with speed greater than 350:");
        List<Car> fastCars = sheikhGarage.FindCarsByCriteria(new Car(null, null, 350, 0));
        PrintCars(fastCars);

        sheikhGarage.RemoveCar(car2);

        Console.WriteLine("\nAfter removing Ford:");
        allCars = sheikhGarage.FindCarsByCriteria(new Car(null, null, 0, 0));
        PrintCars(allCars);

        Console.ReadKey();
    }

    static void PrintCars(List<Car> cars)
    {
        foreach (Car car in cars)
        {
            Console.WriteLine($"Name: {car.Name}, Color: {car.Color}, Speed: {car.Speed}, Year: {car.Year}");
        }
    }
}
