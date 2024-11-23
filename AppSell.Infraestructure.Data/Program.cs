using AppSell.Infraestructure.Data.Context;

namespace AppSell.Infraestructure.Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating the DB if not exists!");
            SellContext db = new SellContext();
            db.Database.EnsureCreated();
            Console.WriteLine("DB Creted!!!");
            Console.ReadKey();
        }
    }
}
