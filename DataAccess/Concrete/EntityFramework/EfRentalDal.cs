using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,ReCapProjectContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapProjectContext dbCarContext = new ReCapProjectContext())
            {
                var result =
                    from rental in dbCarContext.Rentals
                    join car in dbCarContext.Cars on rental.CarId equals car.Id
                    join brand in dbCarContext.Brands on car.BrandId equals brand.Id
                    join color in dbCarContext.Colors on car.ColorId equals color.Id
                    join customer in dbCarContext.Customers on rental.CustomerId equals customer.Id
                    join user in dbCarContext.Users on customer.UserId equals user.Id
                    select new RentalDetailDto()
                    {
                        RentalId = rental.Id,
                        CustomerName = user.FirstName,
                        CompanyName = customer.CompanyName,
                        BrandName = brand.BrandName,
                        ColorName = color.ColorName,
                        ModelYear = car.ModelYear,
                        DailyPrice = car.DailyPrice,
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate
                    };
                return result.ToList();
            }
        }
    }
}
