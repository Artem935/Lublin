
using System;
using System.Diagnostics;
using Transport.Models.Objects;
using Transport.Repository;

namespace Transport.DisplayConsole
{
    public delegate void MenuDelegate();
    public class MainDisplay : IDisplay
    {
        public void Start()
        {
            IRepository<Car> car = new RepositoryCar();
            IRepository<Airplane> airPlane = new RepositoryAirplane();
            while (true)
            {
                int result = Menu();
                if (result == 1)
                {
                    int transportType = TransportType();
                    int amount = new DataVerification().CorrectDataInt("Amoumt: ");
                    if (transportType == 1)
                    {
                        for (int i = 0; i < amount; i++)
                            car.AddList(AddCar());

                    }
                    else if (transportType == 2)
                    {
                        for (int i = 0; i < amount; i++)
                            airPlane.AddList(AddAirplane());
                    }
                }
                else if (result == 2)
                {
                    car.ShowAll();
                    Console.Write('\n');
                    airPlane.ShowAll();
                }
                else if (result == 3)
                {
                    int type = TransportType();
                    if (type == 1)
                    {
                        int choice = new DataVerification().CorrectDataInt($"Find by {new Car().PrintAvailableProperties()}");
                        car.FindObject(choice);
                    }
                    else if (type == 2)
                    {
                        int choice = new DataVerification().CorrectDataInt($"Find by {new Airplane().PrintAvailableProperties()}");
                        airPlane.FindObject(choice);
                    }   
                }
                else if (result == 4)
                {
                    int type = TransportType();
                    if (type == 1)
                        car.DeliteObject(new DataVerification().CorrectDataInt($"Delete by :{new Car().PrintAvailableProperties()}"));
                    else if (type == 2)
                        airPlane.DeliteObject(new DataVerification().CorrectDataInt($"Delete by :{new Airplane().PrintAvailableProperties()}")); 
                }
            }
        }
        private Car AddCar()
        {
            DataVerification dataVerification = new DataVerification();
            return new Car(0, dataVerification.CorrectDataString("Model: "), dataVerification.CorrectDataString("Brand: "),
                dataVerification.CorrectDataFLoat("Fuil Consumption: "), dataVerification.CorrectDataDecimal("Price: "));

        }
        private Airplane AddAirplane()
        {
            DataVerification dataVerification = new DataVerification();
            return new Airplane(0, dataVerification.CorrectDataString("Model: "), dataVerification.CorrectDataString("Brand: "),
                dataVerification.CorrectDataFLoat("Fuel Consumpton: "), dataVerification.CorrectDataDecimal("Price: "));
        }
        public int Menu()
        {
            Console.WriteLine("1. Add objects");
            Console.WriteLine("2. Show al");
            Console.WriteLine("3. Find objects");
            Console.WriteLine("4. Delit object");
            Console.WriteLine("=========================");
            return new DataVerification().CorrectDataInt("Point: ");
        }
        private int TransportType()
        {
            Console.WriteLine("What type of transport ?");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Airplane");
            return new DataVerification().CorrectDataInt("Point: ");
        }
    }
}
