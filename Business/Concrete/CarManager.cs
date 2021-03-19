using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect (typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarNameExists(car.CarName),
                CheckIfCarCountOfBrandCorrent(car.BrandId));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);

        }

        [CacheRemoveAspect("ICarService.get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
            
        }


        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==20)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed );
           
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), Messages.CarDailyPriceListed);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id),Messages.CarPropertyListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails(), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetByBrandIdDetails(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails(c=>c.BrandId==id), Messages.CarBrandIdListed);
        }

        public IDataResult<List<CarDetailDto>> GetByColorIdDetails(int id)
        {
         
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails(c=>c.ColorId==id), Messages.CarColorIdListed);
        }
        public IDataResult<List<CarDetailDto>> GetByCarIdDetails(int id)
        {

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.Id == id), Messages.CarColorIdListed);
        }

        [CacheRemoveAspect("ICarService.get")]
        public IResult Update(Car car)
        {
            if (CheckIfCarCountOfBrandCorrent(car.BrandId).Success)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            return new ErrorResult();
           
        }

        private IResult CheckIfCarCountOfBrandCorrent(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 20)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarNameExists(string carName)
        {
            var result = _carDal.GetAll(c => c.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 150)
            {
                throw new Exception("");
            }

            Add(car);

            return null;
        }
    }
}
