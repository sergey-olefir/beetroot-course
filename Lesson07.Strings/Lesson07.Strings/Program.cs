using System.Text;

namespace Lesson07.Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Serhii";
            string hisName = "Nick";
            string placeholder = "Hello, {0} and {1}";

            Console.WriteLine("Hello, " + name);                                //Hello, Serhii
            Console.WriteLine($"Hello, {name}, {hisName}");                     //Hello, Serhii, Nick
            Console.WriteLine(string.Format("Hello, {0}, {1}", name, hisName)); //Hello, Serhii, Nick
            Console.WriteLine(string.Format(placeholder, name, hisName));       //Hello, Serhii and Nick

            var hello = $"Hello, {name}, {hisName}";
            char symbol = hello[5];
            Console.WriteLine(symbol);

            for (int i = 0; i < hello.Length; i++)
            {
                Console.Write(hello[i]);
            }
            
            Console.WriteLine();
            
            Console.WriteLine(char.IsDigit(symbol));            // false
            Console.WriteLine(char.IsLetter(symbol));           // false
            Console.WriteLine(char.IsLower(symbol));            // false
            Console.WriteLine(char.IsPunctuation(symbol));      // true
            Console.WriteLine(char.ToUpper('a'));               // A
            Console.WriteLine(char.ToUpper(','));               // ,
            
            Console.WriteLine(string.Concat("string", " ", "string"));
            Console.WriteLine(hello.Contains('H'));             // true
            Console.WriteLine(hello.Contains("H"));             // true
            Console.WriteLine(hello.Contains("s"));             // false
            Console.WriteLine(hello.Contains("s", StringComparison.InvariantCultureIgnoreCase)); // true            // false
            
            Console.WriteLine(hello.Insert(0, "Some inserted string "));             // 
            Console.WriteLine(hello.Insert(7, "Alex, "));                            // 
            Console.WriteLine(hello.Remove(7));                                      // 
            Console.WriteLine(hello.Remove(7, 2));                                   // 
            Console.WriteLine(hello.Replace(name, hisName));                         // Hello, Nick, Nick
            Console.WriteLine(hello.ToUpperInvariant());                         //
            Console.WriteLine(hello.ToLowerInvariant());                         //
            Console.WriteLine(hello.Replace(name, name.ToUpper()));                         //
           
            Console.WriteLine($"    {name}   ".Trim());                          //
            foreach (var item in hello.Split('i', StringSplitOptions.RemoveEmptyEntries))
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine(1.CompareTo(2));                  // -1
            Console.WriteLine(2.CompareTo(2));                  // 0
            Console.WriteLine(3.CompareTo(2));                  // 1
            
            Console.WriteLine(string.Equals("abc", "abc"));     // true
            Console.WriteLine(string.Equals("abc", "bcd"));     // false
            Console.WriteLine(string.Compare("abc", "abc"));    // 0
            Console.WriteLine("abc".CompareTo("abc"));          // 0
            Console.WriteLine(string.Compare("abc", "bcd"));    // -1
            Console.WriteLine(string.Compare("abc", "abd"));    // -1
            Console.WriteLine(string.Compare("pbc", "abc"));    // 1
            Console.WriteLine(string.Compare("abcd", "abc"));   // 1
            
            Console.WriteLine(string.Compare("abc", "Abc", StringComparison.InvariantCultureIgnoreCase));    // 0
            Console.WriteLine("abc" == "bcd");
            Console.WriteLine("abc" != "bcd");

            // "abcdbc" => ["c", "b"];
            
            var emptyString = string.Empty;
            const int N = 1000;

            for (int i = 0; i < N; i++)
            {
                emptyString = emptyString + $"{i}, ";
            }

            var stringBuilder = new StringBuilder();
            for (int j = 0; j < N; j++)
            {
                stringBuilder.AppendFormat("{0} ", j);
            }
            
            Console.WriteLine(emptyString);
            Console.WriteLine(stringBuilder.ToString());

            // string1 + string2 == string1string2

            // user1, user2, user3
        }

        private void Print(string placeholder, string name)
        {
            Console.WriteLine(string.Format(placeholder, name));
            Console.WriteLine($"Hello, {name}");
        }

        private bool Compare(string str1, string str) => string.Equals(str, str1);
    }
}