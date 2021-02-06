using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //foreach (var car in carManager.GetCarsByColorId(3))
            //{
              //  Console.WriteLine(car.Description);
            //}

            carManager.Add(new Car { BrandId = 3, ColorId = 1, ModelYear = 2018, DailyPrice = 100, Description = "BMV" });
        }
    }
}
