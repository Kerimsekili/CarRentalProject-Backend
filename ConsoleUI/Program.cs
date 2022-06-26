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
             foreach (var car in carManager.GetAll())
             {
                 Console.WriteLine(car.Description);
             }
         }

         private static void CarTest()
         {
             CarManager carManager = new CarManager(new EfCarDal());
             foreach (var car in carManager.getCarDetails())
             {
                 System.Console.WriteLine(car.Description+" / "+car.Name+" / "+car.DailyPrice);
             }
         }
    }
}
