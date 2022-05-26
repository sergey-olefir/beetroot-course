namespace Lesson11.IntroToOop
{
    public class Person
    {
        private const int Divisor = 2;
        //private static int Divisor = 2;
        private int _age;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PropAge
        {
            get { return this._age; }
            set { this._age = value / Divisor; }
        }

        public Person()
        {

        }

        public int GetAge()
        {
            return this._age;
        }

        public void SetAge(int age)
        {
            this._age = age / Divisor;
        }

        public static Person Create(string firstName, string lastName, int age)
        {
            Person person = new Person();
            person.FirstName = firstName;
            person.LastName = lastName;
            person._age = age;

            return person;
        }

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this._age = age;
        }

        public string FullName
        {
            get { return $"{this.FirstName} {this.LastName}"; }
        }

        public string FullInfo() => $"{this.FullName}, {this._age} years old";
        // public string FullInfo()
        // {
        //     return $"{this.FullName}, {this.Age} years old";
        // }
    }
}