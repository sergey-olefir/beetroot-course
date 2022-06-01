using System;
using System.Net.Http;

namespace Lesson14.Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Cat(new ConsoleNotification());
            animal.Noise();

            INotification notification = new ConsoleNotification();
            notification.Notify("dfd");
            
            INotification notification1 = new HttpNotification();
            notification1.Notify("34234");
            
            new MyClass().Print(4);
            new Person("Serhii").Print();
        }

        public class Person
        {
            private readonly string _name;

            public Person(string name)
            {
                this._name = name;
            }

            public void Print()
            {
                Console.WriteLine(this._name);
            }
        }
        
        public class MyClass
        {
            public void Print(int a)
            {
                Console.WriteLine(a);
            }
        }

        public interface INotification
        {
            void Notify(string message);
        }

        public class ConsoleNotification : INotification
        {
            public void Notify(string message)
            {
                Console.WriteLine("Котик каже няв!");
            }
        }
        
        public class HttpNotification : INotification
        {
            public void Notify(string message)
            {
                Console.WriteLine("Через http котик каже няв!");
            }
        }

        public abstract class Animal
        {
            public abstract void Noise();
        }

        public class Cat : Animal
        {
            private INotification notification;

            public Cat(INotification notification)
            {
                this.notification = notification;
            }

            public override void Noise()
            {
                this.notification.Notify("ads");
            }
        }
        
        public enum NoiseType
        {
            Console = 1,
            Http = 2,
            Smtp = 3
        }
    }
}