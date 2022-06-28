using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;


namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        public ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void Add(Car car)
        {
            if ((car.DailyPrice > 0) && (car.CarName.Length > 2))
            {
                _carDal.Add(car);
            }
            else
            {
                throw new Exception("Günlük fiyat 0'dan küçük olamaz, Araba ismi 2 karakterden küçük olamaz. ");
            }
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
