using System;
using System.Linq;
using Lesson28.EF.DataAccess;

namespace Lesson28.EF
{
    public static class Program
    {
        public static void Main()
        {
            var context = new ShopDataContext();
            var count = context.Categories.Count();
            Console.WriteLine(count);
        }
    }
}