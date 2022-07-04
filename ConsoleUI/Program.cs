using System;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    public class Program
    {
         static void Main(string[] args)
         {
             CarTest();
             //CarTest2();
         }

         private static void CarTest2()
         {
             CarManager carManager = new CarManager(new EfCarDal());
             var result = carManager.GetAll();

         }

         private static void CarTest()
         {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var product in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(product.CarName + " / " + product.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Messege);
            }

         }
    }
}
