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
            //CarTest();
            BrandTest();
            //ColorTest();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("**********Color*GetAll*********");

            foreach (var c in colorManager.GetAll())
            {
                Console.WriteLine(c.ColorName);
            }

            Console.WriteLine("**********Color*GetById*********");

            Color color = colorManager.GetById(2);
            Console.WriteLine(color.ColorName);

            Console.WriteLine("**********Color*Update*********");

            Color color1 = new Color { ColorId = 1, ColorName = "Siyah" };
            colorManager.Update(color1);

            Console.WriteLine("**********Color*Delete*********");

            Color color2 = new Color { ColorId = 4 };
            colorManager.Delete(color2);

           
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("**********Brand*GetAll*********");

            foreach (var b in brandManager.GetAll())
            {
                Console.WriteLine(b.BrandName);

            }

            Console.WriteLine("**********Brand*GetById*********"); 

            Brand brand = brandManager.GetById(2);
           
            Console.WriteLine(brand.BrandName);

            Console.WriteLine("**********Brand*Update*********");

            Brand brand1 = new Brand { BrandId = 3, BrandName = "Hyduai" };
            brandManager.Update(brand1);

            Console.WriteLine("**********Brand*Delete*********");

            Brand brand2 = new Brand { BrandId = 4 };
            brandManager.Delete(brand2);

            
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("**********Car*GetAll*********");

            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.DailyPrice);
            }

            Console.WriteLine("**********Car*GetById*********");

            Car car = carManager.GetById(2);

            Console.WriteLine(car.CarName+ "/" + car.DailyPrice);


            Console.WriteLine("**********Car*Update*********");

            Car car1 = new Car { Id = 1, BrandId=2, CarName="Audi Q3", ColorId= 3, DailyPrice=150, Description= "Audi Q3 1.5 TFSI Desing", ModelYear = 2015 };
            carManager.Update(car1);

            Console.WriteLine("**********Car*Delete*********");

            Car car2 = new Car { Id = 7, };
            carManager.Delete(car2);

            Console.WriteLine("**********Car*GetCarDetails*********");

            foreach (var c in carManager.GetCarDetails())
            {
                Console.WriteLine(c.CarName + "," + c.BrandName + "," + c.ColorName );
            }

            Console.WriteLine("**********Car*GetCarsByColorId*********");

            foreach (var c in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(c.Description);
            }

            Console.WriteLine("**********Car*CarAdd*********");

            carManager.Add(new Car { Id = 7, BrandId = 2, ColorId = 1, CarName = "BMW 3 Serisi", ModelYear = 2018, DailyPrice = 100, Description = "BMV 3 Serisi Coupé" });





        }
    }
}
