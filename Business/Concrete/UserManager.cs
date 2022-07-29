using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constans.Messeges;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        public IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messeges.GeneralAdded);
        }

        public IResult Update(User user)
        {
           _userDal.Update(user);
           return new SuccessResult(Messeges.GeneralUpdate);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messeges.GeneralDelete);
        }
    }
}
