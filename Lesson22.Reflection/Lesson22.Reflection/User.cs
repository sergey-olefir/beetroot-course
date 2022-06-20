using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lesson22.Reflection
{
    [Flags]
    enum UserPermission
    {
        Read = 1,
        Append = 2,
        Change = Read | Append,
        All = Read | Append | Change
    }

    public class Customer<[MinValue(2)]T>
    {
    }

    [AttributeUsage(AttributeTargets.GenericParameter | AttributeTargets.Class | AttributeTargets.Delegate)]
    public class MinValueAttribute : Attribute
    {
        public MinValueAttribute(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

    public class User
    {
        public User()
        {

        }

        public User(string name)
        {
            this.Name = name;
        }

        [MinLength(10)]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        [DefaultValue(50)]
        public int Age { get; set; }

        public void Method(int value = 10)
        {

        }
    }
}