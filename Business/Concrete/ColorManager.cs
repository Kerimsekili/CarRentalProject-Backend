using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    internal class ColorManager:IColorService
    {
        public IColorService _colorDal;
        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public List<Color> GetById(int id)
        {
           return _colorDal.GetById(id);
        }

        public void Add(Color color)
        {
            _colorDal.Add(color);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
        }
    }
}
