using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;


namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        public ICarDal _carDal;

        public CarManager(InMemoryCarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
    }
}
