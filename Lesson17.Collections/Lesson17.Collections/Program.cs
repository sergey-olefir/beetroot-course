using System;
using System.Collections.Generic;
using System.Linq;
using Lesson17.Collections;

var hashSet = new HashSet<int>();
hashSet.Add(2);
Console.WriteLine(hashSet.Contains(2));

var personHashset = new HashSet<Person>();
var person = new Person
{
    Name = "Serhii",
    Age = 10
};
personHashset.Add(person);
Console.WriteLine(personHashset.Contains(person));           // true

var clonedPerson = person.Clone();
Console.WriteLine(personHashset.Contains(clonedPerson));     // false

var namedHashSet = new HashSet<Person>(new PersonNameComparer());
namedHashSet.Add(person);

Console.WriteLine(personHashset.Contains(person));           // true
Console.WriteLine(personHashset.Contains(new Person
{
    Name = "Serhii",
    Age = 20
}));           // false


var list = new Lesson17.Collections.LinkedList<int>();
list.Add(1);
list.Add(2);
list.Add(3);
list.Add(4);

foreach (var item in list.GetAll())
{
    Console.WriteLine(item);
}

Console.WriteLine("______________________________");
for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list.GetByIndex(i));
}
Console.WriteLine("______________________________");

var array = Enumerable.Range(1, 5).ToArray();
for (int j = 0; j < array.Length; j++)
{
    Console.WriteLine(array[j]);
}
Console.WriteLine("______________________________");

Console.WriteLine("______________________________");

foreach (var item in array)
{
    Console.WriteLine(item);
}
Console.WriteLine("______________________________");

Console.WriteLine("______________________________");

foreach (var item in list)
{
    Console.WriteLine(item);
}
Console.WriteLine("______________________________");

Print(list.GetEnumerator());

Console.WriteLine("______________________________");


IEnumerable<int> enumerable = list;
IEnumerator<int> enumerator = enumerable.GetEnumerator();

Print(enumerator);

int q = 2;
IComparable<int> comparable = q;

void Print(IEnumerator<int> iterator)
{
    iterator.Reset();
    while (iterator.MoveNext())
    {
        Console.WriteLine(iterator.Current);
    }
}

IEnumerable<int> Get()
{
    for (int i = 0; i < 4; i++)
    {
        yield return i;
    }
}

var e = Get();
foreach (var i in e)
{
    Console.WriteLine(i);
}



var index = 2;
Console.WriteLine($"{index} item of list is {list.GetByIndex(index)}");

Console.WriteLine(list.Contains(2));            // true
Console.WriteLine(list.Contains(100));          // false

var stringList = new Lesson17.Collections.LinkedList<string>
{
    "sfsfd",
    "24234"
};

foreach (var item in stringList.GetAll())
{
    Console.WriteLine(item);
}

var set = new Set<int>(100);
set.Add(1);
set.Add(2);
set.Add(3);
set.Add(33);

Console.WriteLine(set.Contains(1));
Console.WriteLine(set.Contains(3));
Console.WriteLine(set.Contains(33));
Console.WriteLine(set.Contains(45));

public class Person
{
    protected bool Equals(Person other)
        => this.Name == other.Name && this.Age == other.Age;

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != this.GetType())
        {
            return false;
        }

        return Equals((Person)obj);
    }

    public override int GetHashCode()
        => HashCode.Combine(this.Name, this.Age);

    public string Name { get; set; }
    public int Age { get; set; }

    public Person Clone()
    {
        return new Person
        {
            Age = this.Age,
            Name = this.Name
        };
    }
}

class PersonNameComparer : IComparer<Person>, IEqualityComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if (ReferenceEquals(x, y))
        {
            return 0;
        }

        if (ReferenceEquals(null, y))
        {
            return 1;
        }

        if (ReferenceEquals(null, x))
        {
            return -1;
        }

        var nameComparison = string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        if (nameComparison != 0)
        {
            return nameComparison;
        }

        return x.Age.CompareTo(y.Age);
    }

    public bool Equals(Person x, Person y)
    {
        if (ReferenceEquals(x, y))
        {
            return true;
        }

        if (ReferenceEquals(x, null))
        {
            return false;
        }

        if (ReferenceEquals(y, null))
        {
            return false;
        }

        if (x.GetType() != y.GetType())
        {
            return false;
        }

        return x.Name == y.Name;
    }

    public int GetHashCode(Person obj)
    {
        return HashCode.Combine(obj.Name);
    }
}

// n - кількість, що не здали       100
// m - загальна кількість           15000
// O(m)                             15000
// O(m*n)                           1500000