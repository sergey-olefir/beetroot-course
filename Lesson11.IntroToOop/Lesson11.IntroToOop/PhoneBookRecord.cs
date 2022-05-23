namespace Lesson11.IntroToOop
{
    public class PhoneBookRecord
    {
        public Person Person;
        public int Number;

        public PhoneBookRecord(Person person, int number)
        {
            this.Person = person;
            this.Number = number;
        }

        public string FullInfo()
        {
            return $"{this.Person.FullInfo()} with phone number {this.Number}";
        }
    }
}