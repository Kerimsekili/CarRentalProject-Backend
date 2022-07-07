using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,ReCapProjectContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result =
                    from customer in context.Customers
                    join user in context.Users
                        on customer.UserId equals user.Id
                    select new CustomerDetailDto()
                    {
                        UserId = user.Id,
                        UserFirstName = user.FirstName,
                        UserLastName = user.LastName,
                        Email = user.Email,
                        CompanyName = customer.CompanyName,
                        CustomerId = customer.Id,
                    };
                return result.ToList();
            }
        }
    }
}
