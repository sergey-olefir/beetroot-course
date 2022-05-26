namespace Lesson11.IntroToOop
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.FirstName = "Serhii";
            person.LastName = "Olefir";
            person.PropAge = 30;
            Console.WriteLine(person.PropAge);

            person.SetAge(12);

            // var fName = "Se";
            // var lName = "Ol";
            // var age = 12;
            
            var anotherPerson = new Person("Andrew", "Demchuk", 40);
            var thirdPerson = Person.Create("Lev", "Tolstoy", 200);

            var fourthPerson = new Person
            {
                FirstName = "Nick",
                LastName = "Someone"
            };
            
            fourthPerson.SetAge(30);

            Print(person);
            Print(anotherPerson);
            Print(thirdPerson);
            Print(fourthPerson);

            var records = new PhoneBookRecord[]
            {
                new PhoneBookRecord(person, 123),
                new PhoneBookRecord(anotherPerson, 456),
                new PhoneBookRecord(thirdPerson, 789),
                new PhoneBookRecord(fourthPerson, 000)
            };
            var phoneBook = new PhoneBook(records);
            foreach (var item in phoneBook.Records)
            {
                Console.WriteLine(item.FullInfo);
            }
        }

        private static void Print(Person person)
        {
            Console.WriteLine(person.FullInfo());
        }
    }
}