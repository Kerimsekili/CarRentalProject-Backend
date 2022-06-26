using System.Collections.Generic;
using Business.Abstract;
using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;


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

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }
    }
}
