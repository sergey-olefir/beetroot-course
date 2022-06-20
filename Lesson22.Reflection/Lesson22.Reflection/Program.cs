using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Lesson22.Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 -> 0001
            // 2 -> 0010
            // 1 | 2
            //      0011 -> 3

            UserPermission permission = (UserPermission)1;
            Console.WriteLine(permission & UserPermission.All);
            Console.WriteLine(permission == UserPermission.Read);

            Type userType = typeof(User);
            Type dateTimeType = typeof(DateTime);

            Console.WriteLine($"{userType.Name} is {(userType.IsClass ? "class" : "some other type")}");
            Console.WriteLine($"{dateTimeType.Name} is {(dateTimeType.IsClass ? "class" : "some other type")}");

            Console.WriteLine($"{userType.Name} consists from {userType.GetProperties().Length} properties");

            foreach (PropertyInfo propertyInfo in userType.GetProperties())
            {
                Console.WriteLine($"Property {propertyInfo.Name} of type {propertyInfo.PropertyType.Name}");
            }

            foreach (MethodInfo methodInfo in typeof(string).GetMethods())
            {
                Console.WriteLine($"Method {methodInfo.Name} with {methodInfo.GetParameters().Length} params, which returns {methodInfo.ReturnType.Name}");
            }

            MethodInfo method = userType.GetMethod(nameof(User.Method));
            ParameterInfo parameter = method.GetParameters().First();
            object defaultValue = parameter.DefaultValue;
            Console.WriteLine(defaultValue);

            if (parameter.ParameterType == typeof(int))
            {
                int intValue = (int)defaultValue;
                Console.WriteLine(intValue);
            }

            object user1 = Activator.CreateInstance(typeof(User), "Den");
            User user2 = Activator.CreateInstance<User>();

            var u = new User(default);

            user2.Name = "ALex";

            var userName = userType.GetProperty(nameof(User.Name))!.GetValue(user2);
            Console.WriteLine(userType.GetProperty(nameof(User.Name))!.GetValue(user1));
            Console.WriteLine(userName);

            userType.GetProperty(nameof(User.Name))!.SetValue(user2, "Nick");

            Console.WriteLine(user2.Name);
            Console.WriteLine(user2.Age);

            var agePropertyInfo = userType.GetProperty(nameof(User.Age));
            var attribute = agePropertyInfo!.GetCustomAttribute<DefaultValueAttribute>();
            Console.WriteLine(attribute.Value);
            agePropertyInfo.SetValue(user2, attribute.Value);

            Console.WriteLine($"{user2.Name}, {user2.Age} years old");

            Console.WriteLine(userType.Assembly.Location);
            foreach (Type exportedType in userType.Assembly.ExportedTypes)
            {
                Console.WriteLine(exportedType.FullName);
                //Activator.CreateInstance(exportedType);
            }

            var user = new User
            {
                Name = "Serhii",
                Age = 10
            };

            Console.WriteLine($"User {user.Name} is {(Validate(user) ? "valid" : "invalid")}");
        }

        private static bool Validate(User user)
        {
            var agePropertyInfo = user.GetType().GetProperty(nameof(User.Age));
            var attribute = agePropertyInfo!.GetCustomAttribute<MinValueAttribute>();

            var actualValue = (int)agePropertyInfo.GetValue(user)!;
            var requiredValue = attribute!.Value;

            return actualValue > requiredValue;
        }
    }
}