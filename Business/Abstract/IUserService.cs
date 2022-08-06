using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        IDataResult<List<User>> GetAll(); 

        //GETBYMAIL METHODU KONTROL EDİLECEK ?
        User GetByMail(string email);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
