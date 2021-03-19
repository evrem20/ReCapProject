using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        //List<CarDetailDto> GetByBrandIdDetails(int id);
        //List<CarDetailDto> GetByColorIdDetails(int id);

    }

}

