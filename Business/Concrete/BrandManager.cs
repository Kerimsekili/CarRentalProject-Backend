using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    internal class BrandManager:IBrandService
    {
        public IBrandService _brandDal;
        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public List<Brand> GetById(int id)
        {
            return _brandDal.GetById(id);
        }

        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }
    }
}
