using System;
using CommandLine;
using Lesson23.DataAccess;
using Lesson23.Domain;

namespace Lesson23.Dependencies
{
    class Program
    {
        public class Options
        {
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }

            [Option('n', "name", Required = false, HelpText = "Set output to verbose messages.")]
            public string Name { get; set; }
        }

        public static void Main(string[] args)
        {
            var service = new RoomService(new FileDataAccess());
            //var rooms = service.GetAll();

            foreach (var item in args)
            {
                Console.WriteLine(item);
            }

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    if (!string.IsNullOrEmpty(o.Name))
                    {
                        Console.WriteLine(o.Name);
                    }
                });
        }
    }
}