﻿using System;
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
                 Console.WriteLine(car.CarName);
             }
         }

         private static void CarTest()
         {
             CarManager carManager = new CarManager(new EfCarDal());
             foreach (var car in carManager.GetCarDetails())
             {
                 System.Console.WriteLine(car.CarName + " / "+car.BrandName+" / "+car.ColorName+" / "+car.DailyPrice);
             }
         }
    }
}
