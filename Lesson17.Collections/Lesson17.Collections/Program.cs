using System;
using Lesson17.Collections;

var list = new LinkedList<int>();
list.Add(1);
list.Add(2);
list.Add(3);
list.Add(4);

foreach (var item in list.GetAll())
{
    Console.WriteLine(item);
}

Console.WriteLine(list.Contains(2));            // true
Console.WriteLine(list.Contains(100));          // false

var stringList = new LinkedList<string>
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

// n - кількість, що не здали       100
// m - загальна кількість           15000
// O(m)                             15000
// O(m*n)                           1500000