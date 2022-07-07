using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        public IRentalDal _rentalDal;
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<List<Rental>> GetById(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.Id == id));
        }

        public IResult Add(Rental rental)
        {

            foreach (Rental item in _rentalDal.GetAll())
            {
                if (item.CarId == rental.CarId)
                {
                    if (item.ReturnDate > rental.RentDate)
                    {
                        return new ErrorResult(Messeges.RentalFailed);
                    }
                }
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messeges.GeneralAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messeges.GeneralDelete);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messeges.GeneralUpdate);
        }

        public IResult UpdateReturnDate(Rental rental)
        {
            var result = _rentalDal.GetAll(p => p.Id == rental.Id);
            var updateRental = result.LastOrDefault();

            if (updateRental != null)
            {
                return new ErrorResult(Messeges.UpdateFailed);
            }

            updateRental.ReturnDate = rental.ReturnDate;
            _rentalDal.Update(updateRental);
            return new SuccessResult(Messeges.GeneralUpdate);
        }
    }
}
