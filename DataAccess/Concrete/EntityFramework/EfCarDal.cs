using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NewTableCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (NewTableCarContext context = new NewTableCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailDto { CarId = c.Id, 
                                 BrandName = b.BrandName, 
                                 ColorName = co.ColorName, 
                                 CarName = c.CarName, 
                                 ModelYear=c.ModelYear, 
                                 DailyPrice = c.DailyPrice, 
                                 Description=c.Description};
                             return result.ToList();
            }
        }
    }
}
