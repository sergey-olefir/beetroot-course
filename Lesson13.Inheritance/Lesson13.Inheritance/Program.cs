using System;

namespace Lesson13.Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[100];
            foreach (var item in array)
            {
                
            }
            Animal animal = new Animal
            {
                Name = "Сіма",
                PawsCount = 4
            };

            Cat cat = new Cat
            {
                Name = "Капучінка",
                PawsCount = 4
            };

            Dog dog = new Dog
            {
                Name = "Лакі",
                PawsCount = 4
            };

            Console.WriteLine($"Animal {animal.Name} with {animal.PawsCount} paws");
            Console.WriteLine($"Cat {cat.Name} with {cat.PawsCount} paws");

            animal.MakeNoise();
            cat.MakeNoise();
            dog.MakeNoise();

            Animal a;

            a = new Cat
            {
                Name = "Буся"
            };
            a.MakeNoise();
            Console.WriteLine(a.GetType());
            Console.WriteLine(a is Cat);
            Console.WriteLine(a is Dog);

            a = new Dog
            {
                Name = "Лакі"
            };
            a.MakeNoise();
            Console.WriteLine(a.GetType());
            Console.WriteLine(a is Cat);
            Console.WriteLine(a is Dog);

            Cat anotherCat = new Cat
            {
                Name = "Варіс",
                PawsCount = 4
            };
            Console.WriteLine($"{cat.Name} equal {anotherCat.Name} = {cat.Equals(anotherCat)}");
            Console.WriteLine(cat.Equals(cat));

            object obj1 = 4;
            object obj2 = "якась стрічка";
            obj2 = new Cat();
            
            Console.WriteLine(obj1.ToString());
            Console.WriteLine(obj2.ToString());
            Console.WriteLine(obj1.GetType());
            Console.WriteLine(obj2.GetType());

            obj1 = false;
            Console.WriteLine(obj1.ToString());
            Console.WriteLine(obj1.GetType());
            Console.WriteLine(obj1 as Nullable<int>);

            Noise noise;
            noise = new FlyNoise();
            noise.MakeNoise();
            
            noise = new JustNoise();
            noise.MakeNoise();

            var duck = new Duck(new FlyNoise());
            var duck1 = new Duck(new JustNoise());
            duck.MakeNoise();
            duck1.MakeNoise();
        }
    }

    public abstract class Noise
    {
        public abstract void MakeNoise();
    }

    public class FlyNoise : Noise
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Літаючий кря!");
        }
    }

    public class SilentNoise : Noise
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Тихий кря!");
        }
    }

    public class JustNoise : Noise
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Просто кря!");
        }
    }

    public class Duck
    {
        private readonly Noise _noise;
        
        public Duck(Noise noise)
        {
            this._noise = noise;
        }

        public virtual void MakeNoise()
        {
            this._noise.MakeNoise();
        }
    }

    public class RubberDuck : Duck
    {
        public RubberDuck(Noise noise) : base(noise)
        {
        }
    }

    public class RealDuck : Duck
    {
        public RealDuck(Noise noise) : base(noise)
        {
        }
    }

    public class FlyDuck : RealDuck
    {
        public FlyDuck(Noise noise) : base(noise)
        {
        }
    }

    public class Animal
    {
        public string Name { get; set; }

        public int PawsCount { get; set; }

        public int Size { get; set; }

        public virtual void MakeNoise()
        {

        }
        
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            Animal? animal = obj as Animal;
            if (animal == null)
            {
                return false;
            }

            if (this.Name != animal.Name) return false;
            if (this.Size != animal.Size) return false;
            if (this.PawsCount != animal.PawsCount) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }

    public class Cat : Animal
    {
        public override void MakeNoise()
        {
            Console.WriteLine($"{this.Name} сказала Няв!");
        }
    }

    public class Dog : Animal
    {
        public override void MakeNoise()
        {
            Console.WriteLine($"{this.Name} сказала Гав!");
        }
    }
}