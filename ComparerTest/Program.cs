using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var v0 = new Employee { School = new School { City = "Beijing" } };
            var v1 = new Employee { School = new School { City = "Beijing" } };
            var v2 = new Employee { School = new School { City = "Shanghai" } };
            var v3 = new Employee { School = null };
            var v4 = new Employee { School = null };

            List<Employee> employees = new List<Employee>();
            employees.Add(v0);
            employees.Add(v1);
            employees.Add(v2);
            employees.Add(v3);

            var companylComparer = Equality<School>.CreateComparer(i => i.City);
            var employeeComparer = Equality<Employee>.CreateComparer(i => i.School, companylComparer);

            List<Employee> aa = employees.Distinct(employeeComparer).ToList();

            var b1 = employeeComparer.Equals(v0, v1);   // true
            var b2 = employeeComparer.Equals(v0, v2);   // false
            var b3 = employeeComparer.Equals(v0, v3);   // false
            var b4 = employeeComparer.Equals(v3, v4);   // false
        }

        public static class Equality<T>
        {
            public static IEqualityComparer<T> CreateComparer<V>(Func<T, V> keySelector)
            {
                return new CommonEqualityComparer<V>(keySelector);
            }
            public static IEqualityComparer<T> CreateComparer<V>(Func<T, V> keySelector, IEqualityComparer<V> comparer)
            {
                return new CommonEqualityComparer<V>(keySelector, comparer);
            }

            class CommonEqualityComparer<V> : IEqualityComparer<T>
            {
                private Func<T, V> keySelector;
                private IEqualityComparer<V> comparer;

                public CommonEqualityComparer(Func<T, V> keySelector, IEqualityComparer<V> comparer)
                {
                    this.keySelector = keySelector;
                    this.comparer = comparer;
                }
                public CommonEqualityComparer(Func<T, V> keySelector)
                    : this(keySelector, EqualityComparer<V>.Default)
                { }

                public bool Equals(T x, T y)
                {
                    if (x == null || y == null) return false;
                    return comparer.Equals(keySelector(x), keySelector(y));
                }
                public int GetHashCode(T obj)
                {
                    if (obj == null) return 0;
                    return comparer.GetHashCode(keySelector(obj));
                }
            }
        }

        public class Employee
        {
            public School School { get; set; }
        }
        public class School
        {
            public string City { get; set; }
        }
    }
}
