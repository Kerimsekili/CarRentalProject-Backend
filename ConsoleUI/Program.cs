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
             //CarTest();
             CarManager carManager = new CarManager(new EfCarDal());
             foreach (var car in carManager.GetAll())
             {
                 Console.WriteLine(car.Description);
             }
         }

         private static void CarTest()
         {
             CarManager carManager = new CarManager(new EfCarDal());
             foreach (var car in carManager.GetAll())
             {
                 System.Console.WriteLine(car.Description);
             }
         }
    }
}
