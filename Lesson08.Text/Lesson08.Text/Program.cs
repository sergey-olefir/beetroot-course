using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lesson08.Text
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Guid("6719D7B8-75FD-4F01-8FAC-2B1450733AB3"));
            Console.WriteLine(Guid.Parse("6719D7B8-75FD-4F01-8FAC-2B1450733AB3"));

            Console.WriteLine(Guid.NewGuid());
            string filePath = "Phone book.csv";
            //string filePath = null;

            string[] content = null;
            try
            {
                try
                {
                    content = File.ReadAllLines(filePath);
                    // print file content
                    foreach (var item in content)
                    {
                        Console.WriteLine(item);
                    }
                }
                catch (ArgumentNullException exception)
                {
                    throw new Exception(exception.Message);
                }
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine($"Error: {exception.Message}, type: {exception.GetType()}");
                content = Array.Empty<string>();
            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine($"Error: {exception.Message}, type: {exception.GetType()}");
                content = Array.Empty<string>();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error: {exception.Message}, type: {exception.GetType()}");
                content = Array.Empty<string>();
            }
            catch
            {
                Console.WriteLine($"Error");
                content = Array.Empty<string>();
            }
            finally
            {
                Console.WriteLine("Finally block");
            }

            // (int a, int b) tuple;
            //
            // tuple.b = 3;
            // tuple.a = 1;
            // int c = tuple.a + tuple.b;

            // print deserialized data
            foreach ((string name, int number) item in Deserialize(content))
            {
                Console.WriteLine($"Name is {item.name}, number is {item.number}");
            }

            var phoneBook = Deserialize(content);

            var newRecord = (name: "Nick", number: 1212);
            Add(ref phoneBook, newRecord);

            var indexToUpdate = -1;

            try
            {
                if (indexToUpdate > 0 && phoneBook.Length > indexToUpdate)
                {
                    Update(phoneBook, newRecord, indexToUpdate);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error type: {e.GetType()}");
            }
            //Delete(ref phoneBook, 0);

            // print serialized data
            var serializedBook = Serialize(phoneBook);
            foreach (var item in serializedBook)
            {
                Console.WriteLine(item);
            }

            //File.WriteAllLines(filePath, serializedBook);
            StreamReader reader;

            try
            {
                using (reader = new StreamReader(filePath))
                {
                    try
                    {
                        reader.Peek();
                    }
                    catch
                    {
                        Console.WriteLine("Error");
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                reader = new StreamReader(filePath);
                try
                {
                    reader.Peek();
                }
                catch
                {
                    Console.WriteLine("Error");
                }
            }
            finally
            {
                reader.Dispose();
            }
        }

        private static void Add(ref (string name, int number)[] content, (string name, int number) newItem)
        {
            var newBook = new (string name, int number)[content.Length + 1];
            content.CopyTo(newBook, 0);
            newBook[content.Length] = newItem;
            content = newBook;
        }

        private static void Update((string name, int number)[] content, (string name, int number) updatedItem, int index)
        {
            try
            {
                content[index] = updatedItem;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Can't update record with index {index}");
                throw;
            }
        }

        private static void Delete(ref (string name, int number)[] content, int index)
        {
            var newBook = new (string name, int number)[content.Length - 1];
            int j = 0;
            // ReSharper disable once ForCanBeConvertedToForeach
            for (int i = 0; i < content.Length; i++)
            {
                if (i != index)
                {
                    newBook[j++] = content[i];
                }
            }

            content = newBook;
        }

        private static string[] Serialize((string name, int number)[] content)
        {
            var strings = new string[content.Length];
            for (int i = 0; i < content.Length; i++)
            {
                strings[i] = $"{content[i].name};{content[i].number}";
            }

            return strings;
        }

        private static (string name, int number)[] Deserialize(string[] content)
        {
            var regexp = new Regex(@"^(?<name>\w+);(?<number>\d+)$");
            var book = new (string name, int number)[content.Length];
            for (int i = 0; i < content.Length; i++)
            {
                var item = content[i];
                var match = regexp.Match(item);

                if (match.Success)
                {
                    book[i].name = match.Groups["name"].Value;
                    book[i].number = int.Parse(match.Groups["number"].Value);
                }
            }
            return book;
        }
    }
}