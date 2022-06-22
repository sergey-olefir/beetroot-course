using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lesson24.Async
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // var coffee = PourACupOfCoffee();
            // var tee = PourACupOfTee();
            //
            // Task<string> drink = await Task.WhenAny(coffee, tee);
            // Console.WriteLine(drink.Result);
            //
            // await HeatUpAPen();
            //
            // Task shower = TakeAShower();
            // Task teeth = BrushMyTeeth();
            //
            // await Task.WhenAll(shower, teeth);
            //
            // await AddButterToToast().ConfigureAwait(false);
            // await AddJamToToast().ContinueWith(x => Console.WriteLine($"Задача закінчилася за статусом {x.Status}"));
            // await ScreamAsync();

            var httpClient = new HttpClient();
            var requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri("https://foodish-api.herokuapp.com/api")
            };

            var responseMessage = await httpClient.SendAsync(requestMessage);
            var stringResponse = await responseMessage.Content.ReadAsStringAsync();

            var image = JsonConvert.DeserializeObject<ImageResponse>(stringResponse);

            Console.WriteLine(stringResponse);
            Console.WriteLine($"got image with url {image!.Image}");

            var imageResponse = await httpClient.SendAsync(new HttpRequestMessage
            {
                RequestUri = new Uri(image.Image)
            });

            // CPU
            // I/O

            await using var stream = await imageResponse.Content.ReadAsStreamAsync();
            await using var fileStream = File.Create("food.jpg");
            stream.Seek(0, SeekOrigin.Begin);
            await stream.CopyToAsync(fileStream);
        }

        private class ImageResponse
        {
            public string Image { get; set; }
        }

        private static void Scream()
        {
            Console.WriteLine("AAAAAAAAAAA!");
        }

        private static Task ScreamAsync()
        {
            return Task.Run(() => Scream());
        }

        private static async Task<string> PourACupOfTee()
        {
            await Task.Delay(1000);
            return "Чай готовий";
        }

        private static async Task<string> PourACupOfCoffee()
        {
            await Task.Delay(2000);
            return "Кава готова";
        }

        private static async Task HeatUpAPen()
        {
            await Task.Delay(1000);
            Console.WriteLine("Гріємо");
        }

        private static async Task TakeAShower()
        {
            await Task.Delay(1000);
            Console.WriteLine("Приймаємо душ");
        }

        private static async Task BrushMyTeeth()
        {
            await Task.Delay(1000);
            Console.WriteLine("Чистимо зубки");
        }

        private static async Task AddButterToToast()
        {
            await Task.Delay(1000);
            Console.WriteLine("Додаємо хліб");
        }

        private static async Task AddJamToToast()
        {
            await Task.Delay(1000);
            Console.WriteLine("Додаємо джем до тосту");
        }
    }
}