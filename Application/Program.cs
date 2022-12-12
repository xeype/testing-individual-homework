using System;

namespace Application
{
    public class Car
    {
        public string Name { get; }
        public string Brand { get; }
        public float TankVolume { get; }
        public int NumberOfDoors { get; }
        public string BodyType { get; }

        public Car(string name, string brand, float tankVolume, int numberOfDoors, string bodyType)
        {
            Name = name;
            Brand = brand;
            TankVolume = tankVolume;
            NumberOfDoors = numberOfDoors;
            BodyType = bodyType;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("TestName", "TestBrand", 2, 3, "TestBody");
            Console.WriteLine(myCar.Name);
        }
    }
}