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
            //BrandTest();
            //ColorTest();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { Id=1, CarId = 4, CustomerId = 1, RentDate = new DateTime(2021,2,5), ReturnDate=new DateTime(2021,2,12)});
            Console.WriteLine(result.Message);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("**********Color*GetAll*********");

            var result = colorManager.GetAll();

            if (result.Success==true)
            {
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Console.WriteLine("**********Color*GetById*********");

            var result1 = colorManager.GetById(2);
            Color color = result1.Data;
            Console.WriteLine(color.ColorName);

            Console.WriteLine("**********Color*Update*********");

            Color color1 = new Color { Id = 1, ColorName = "Siyah" };
            var result2 = colorManager.Update(color1);
            Console.WriteLine(result2.Message);

            Console.WriteLine("**********Color*Delete*********");

            Color color2 = new Color { Id = 4 };
            var result3 =colorManager.Delete(color2);
            Console.WriteLine(result3.Message);

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("**********Brand*GetAll*********");

            var result = brandManager.GetAll();

            if (result.Success==true)
            {
                foreach (var b in result.Data)
                {
                    Console.WriteLine(b.BrandName);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            

            Console.WriteLine("**********Brand*GetById*********"); 

            var result1= brandManager.GetById(2);
            Brand brand = result1.Data;
           
            Console.WriteLine(brand.BrandName);

            Console.WriteLine("**********Brand*Update*********");

            Brand brand1 = new Brand { Id = 3, BrandName = "Hyduai" };
            var result2 = brandManager.Update(brand1);
            Console.WriteLine(result2.Message);

            Console.WriteLine("**********Brand*Delete*********");

            Brand brand2 = new Brand { Id = 4 };
            var result3 = brandManager.Delete(brand2);
            Console.WriteLine(result3.Message);

            
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("**********Car*GetAll*********");

            var result = carManager.GetAll();

            if (result.Success==true)
            {
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.DailyPrice);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            Console.WriteLine("**********Car*GetById*********");

            var result1 = carManager.GetById(2);

            Car car = result1.Data;

            Console.WriteLine(car.CarName+ "/" + car.DailyPrice + "  " +result1.Message);


            Console.WriteLine("**********Car*GetCarDetails*********");

            var result2 = carManager.GetCarDetails();

            if (result2.Success == true)
            {
                foreach (var c in result2.Data)
                {
                    Console.WriteLine(c.CarName + "/" + c.BrandName + "/" + c.ColorName);
                }
                Console.WriteLine(result2.Message);
            }
            else
            {
                Console.WriteLine(result2.Message);
            }


            Console.WriteLine("**********Car*GetAllByColorId*********");

            var result3 = carManager.GetAllByColorId(2);

            foreach (var c in result3.Data)
            {
                Console.WriteLine(c.CarName);
            }
            Console.WriteLine( result3.Message);

            Console.WriteLine("**********Car*GetAllByBrandId*********");

            var result4 = carManager.GetAllByBrandId(3);

            foreach (var c in result4.Data)
            {
                Console.WriteLine(c.CarName);
            }
            Console.WriteLine(result4.Message);

            Console.WriteLine("**********Car*Add*********");

            var result5=carManager.Add(new Car {Id=6, BrandId = 2, ColorId = 1, CarName = "BMW 3 Serisi", ModelYear = 2018, DailyPrice = 100, Description = "BMV 3 Serisi Coupé" });
            Console.WriteLine(result5.Message);


            Console.WriteLine("**********Car*Delete*********");

            Car car1 = new Car { Id = 6 };

            var result6 = carManager.Delete(car1);
            Console.WriteLine(result6.Message);
     

            Console.WriteLine("**********Car*Update*********");

            Car car2 = new Car { Id = 1, BrandId = 2, CarName = "Audi Q3", ColorId = 2, DailyPrice = 150, Description = "Audi Q3 1.5 TFSI Desing", ModelYear = 2015 };

            var result7= carManager.Update(car2);
            Console.WriteLine(result7.Message);
            
            



            





        }
    }
}
