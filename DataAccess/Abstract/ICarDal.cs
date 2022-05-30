

using System.Collections.Generic;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        public List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        public List<Car> GetById(int id);


    }
}
