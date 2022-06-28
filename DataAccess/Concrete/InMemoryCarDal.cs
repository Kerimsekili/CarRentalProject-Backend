

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal :ICarDal

    {
         List<Car> _cars;

         public InMemoryCarDal()
         {
             _cars = new List<Car>
             {
                 new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2015,DailyPrice=600,CarName="Audi A6"},
                 new Car{Id=2,BrandId=2,ColorId=2,ModelYear = 2022,DailyPrice = 1000,CarName = "Ford Mustang"},
                 new Car{Id=3,BrandId=3,ColorId=3,ModelYear = 1999,DailyPrice = 750,CarName = "Dodge Charger,V12 Engine(Old Boy)"},
                 new Car{Id = 4,BrandId =3,ColorId =3,ModelYear = 2005,DailyPrice = 800,CarName = "Dodge Challanger,Big Machine"}

             };
         }





       
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Insert(Car car)
        {
            
        }

        public void Update(Car car)
        {
            //Gönderdiğim ürün Idsine sahip olan listedei ürünü bul
            Car carToUpdate = carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.CarName = car.CarName;

        }

        public void Delete(Car car)
        {
            Car carToDelete = carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
