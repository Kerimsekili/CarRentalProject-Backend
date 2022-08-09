using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Core.Aspect.Autofac.Validation;

namespace Business.Concrete
{ // ctrl + r + g
    public class ColorManager:IColorService
    {
        public IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.GeneralListed);
        }

        public IDataResult<List<Color>> GetById(int id)
        {
           return new SuccessDataResult<List<Color>>(_colorDal.GetById(id));
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.GeneralAdded);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.GeneralUpdate);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.GeneralDelete);
        }
    }
}
