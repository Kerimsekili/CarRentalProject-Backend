using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        public IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IDataResult<List<Color>> GetAll()
        {
            //if (DateTime.Now.Hour == 22)
            //{
            //    return new ErrorDataResult<List<Color>>(Messeges.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messeges.GeneralListed);
        }

        public IDataResult<List<Color>> GetById(int id)
        {
           return new SuccessDataResult<List<Color>>(_colorDal.GetById(id));
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messeges.GeneralAdded);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messeges.GeneralUpdate);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messeges.GeneralDelete);
        }
    }
}
