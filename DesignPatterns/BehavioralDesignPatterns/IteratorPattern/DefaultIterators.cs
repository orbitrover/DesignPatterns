using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IteratorPattern
{
    public static class DefaultIterators
    {
        public static void RunForeachIteratorForList()
        {
            List<Employee> collection = new List<Employee>() {
            new Employee(1, "Orbit Rover"),
            new Employee(2, "Nion Tesla"),
            new Employee(3, "Riky Rat"),
            new Employee(4, "Famous Fox"),
            new Employee(5, "Rare Rabbit"),
            new Employee(6, "Tough Tiger"),
            new Employee(7, "Loud Lion"),
            new Employee(8, "Ginni Giraf"),
            new Employee(9, "Happy Hippo"),
            };
            Console.WriteLine("Fetching Items From List Collection using Foreach Loop Below");
            foreach (Employee e in collection)
                Console.WriteLine($"Id: {e.Id} & Name: {e.Name}");
        }
        public static void RunForeachIteratorForArray()
        {
            Employee[] collection = new Employee[] {
            new Employee(1, "Orbit Rover"),
            new Employee(2, "Nion Tesla"),
            new Employee(3, "Riky Rat"),
            new Employee(4, "Famous Fox"),
            new Employee(5, "Rare Rabbit"),
            new Employee(6, "Tough Tiger"),
            new Employee(7, "Loud Lion"),
            new Employee(8, "Ginni Giraf"),
            new Employee(9, "Happy Hippo"),
            };
            Console.WriteLine("Fetching Items From Arrat[] Collection using Foreach Loop Below");
            foreach (Employee e in collection)
                Console.WriteLine($"Id: {e.Id} & Name: {e.Name}");
        }
        public static void RunForeachIteratorForArrayList()
        {
            ArrayList array = new ArrayList();
            Employee[] collection = new Employee[] {
            new Employee(1, "Orbit Rover"),
            new Employee(2, "Nion Tesla"),
            new Employee(3, "Riky Rat"),
            new Employee(4, "Famous Fox"),
            new Employee(5, "Rare Rabbit"),
            new Employee(6, "Tough Tiger"),
            new Employee(7, "Loud Lion"),
            new Employee(8, "Ginni Giraf"),
            new Employee(9, "Happy Hippo"),
            };
            array.AddRange(collection);
            Console.WriteLine("Fetching Items From ArrayList Collection using Foreach Loop Below");
            foreach (Employee e in array)
                Console.WriteLine($"Id: {e.Id} & Name: {e.Name}");
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee()
        {
        }
        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
