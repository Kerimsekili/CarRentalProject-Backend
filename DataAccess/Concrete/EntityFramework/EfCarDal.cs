using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                //var result = from c in context.Cars
                //    join b in context.Brands
                //        on c.BrandId equals b.Id
                //    select new CarDetailDto
                //    {
                //        Id = c.Id, Name = b.BrandName,
                //        CarName = c.CarName,
                //        DailyPrice = c.DailyPrice
                //    };
                var result = from c in context.Cars
                    join co in context.Colors
                        on c.ColorId equals co.Id
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    select new CarDetailDto
                    {
                        CarName = c.CarName,
                        BrandName = b.BrandName,
                        ColorName = co.ColorName,
                        DailyPrice = c.DailyPrice
                    };
                return result.ToList();

            }
        }




    }
}
