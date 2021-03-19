using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetAll();   
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetByBrandIdDetails(int id);
        IDataResult<List<CarDetailDto>> GetByColorIdDetails(int id);
        IDataResult<List<CarDetailDto>> GetByCarIdDetails(int id);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IResult AddTransactionalTest(Car car);



    }
}

