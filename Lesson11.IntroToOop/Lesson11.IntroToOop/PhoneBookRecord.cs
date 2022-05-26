namespace Lesson11.IntroToOop
{
    public class PhoneBookRecord
    {
        private readonly Person _person;
        private readonly int _number;

        public PhoneBookRecord(Person person, int number)
        {
            this._person = person;
            this._number = number;
        }

        public string FullInfo => $"{this._person.FullName} with phone number {this._number}";
        // public string FullInfo
        // {
        //     get { return $"{this._person.FullInfo()} with phone number {this._number}"; }
        // }
    }
}