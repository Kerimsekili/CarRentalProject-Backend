using Business.Concrete;
using DataAccess.Concrete;

namespace ConsoleUI
{
    public class Program
    {
         static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                System.Console.WriteLine(car.Description);
            }
        }
    }
}
