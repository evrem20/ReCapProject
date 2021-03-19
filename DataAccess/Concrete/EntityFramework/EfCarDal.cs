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

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (NewTableCarContext context = new NewTableCarContext())
            {
                IQueryable<CarDetailDto> carDetailsDtos = from c in filter is null ? context.Cars : context.Cars.Where(filter)
                                                          join b in context.Brands
                                                          on c.BrandId equals b.Id
                                                          join co in context.Colors
                                                          on c.ColorId equals co.Id
                                                          select new CarDetailDto
                                                          {
                                                              CarId = c.Id,
                                                              BrandName = b.BrandName,
                                                              ColorName = co.ColorName,
                                                              CarName = c.CarName,
                                                              ModelYear = c.ModelYear,
                                                              DailyPrice = c.DailyPrice,
                                                              Description = c.Description
                                                          };
                return carDetailsDtos.ToList();
            }

        }
        //public List<CarDetailDto> GetCarDetails()
        //{
        //    using (NewTableCarContext context = new NewTableCarContext())
        //    {
        //        var result = from c in context.Cars
        //                     join b in context.Brands
        //                     on c.BrandId equals b.Id
        //                     join co in context.Colors
        //                     on c.ColorId equals co.Id
        //                     select new CarDetailDto
        //                     {
        //                         CarId = c.Id,
        //                         BrandName = b.BrandName,
        //                         ColorName = co.ColorName,
        //                         CarName = c.CarName,
        //                         ModelYear = c.ModelYear,
        //                         DailyPrice = c.DailyPrice,
        //                         Description = c.Description
        //                     };
        //        return result.ToList();
        //    }
        //}
        //public List<CarDetailDto> GetByBrandIdDetails(int id)
        //{
        //    using (NewTableCarContext context = new NewTableCarContext())
        //    {
        //        var result = from c in context.Cars
        //                     join b in context.Brands
        //                     on c.BrandId equals b.Id
        //                     join co in context.Colors
        //                     on c.ColorId equals co.Id
        //                     where c.BrandId==id
        //                     select new CarDetailDto
        //                     {
        //                         CarId = c.Id,
        //                         BrandName = b.BrandName,
        //                         ColorName = co.ColorName,
        //                         CarName = c.CarName,
        //                         ModelYear = c.ModelYear,
        //                         DailyPrice = c.DailyPrice,
        //                         Description = c.Description
        //                     };
        //        return result.ToList();
        //    }
        //}

        //public List<CarDetailDto> GetByColorIdDetails(int id)
        //{
        //    using (NewTableCarContext context = new NewTableCarContext())
        //    {
        //        var result = from c in context.Cars
        //                     join b in context.Brands
        //                     on c.BrandId equals b.Id
        //                     join co in context.Colors
        //                     on c.ColorId equals co.Id
        //                     where c.ColorId == id
        //                     select new CarDetailDto
        //                     {
        //                         CarId = c.Id,
        //                         BrandName = b.BrandName,
        //                         ColorName = co.ColorName,
        //                         CarName = c.CarName,
        //                         ModelYear = c.ModelYear,
        //                         DailyPrice = c.DailyPrice,
        //                         Description = c.Description
        //                     };
        //        return result.ToList();
        //    }
        //}
   
    }
}
