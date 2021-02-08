using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{Id=1, BrandId=5, ColorId=1, ModelYear=2018, DailyPrice=300, Description="Hyundai ix35, 1.6 GDI, 2.0 R" },
                new Car{Id=2, BrandId=4, ColorId=8, ModelYear=2015, DailyPrice=150, Description="Fiat 500 X, 1.4 T, 1.6 Multijet"},
                new Car{Id=3, BrandId=3, ColorId=5, ModelYear=2017, DailyPrice=250, Description="Ford EcoSport, 1.0 EcoBoost, 1.5 TDCI" },
                new Car{Id=4, BrandId=2, ColorId=6, ModelYear=2020, DailyPrice=400, Description="Citroen C3 Aiircross, 1.2 PureTech, 1.5 BlueHDI" },
                new Car{Id=5, BrandId=1, ColorId=2, ModelYear=2021, DailyPrice=500, Description="BMW X6, 30d xDrive, 40d xDrive" },
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(carToDelete);
            
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }
        public List<Car> GetAllColor(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
