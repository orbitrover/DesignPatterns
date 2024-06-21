using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.CustomIteratorDesignPatternIntro
{
    public static class CustomIterator
    {
        public static void Run()
        {
            // Build a collection
            ConcreteCollection collection = new ConcreteCollection();
            List<Employee> list = new List<Employee>() {
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
            collection.AddEmployeeList(list);


            // Create iterator
            Iterator iterator = collection.CreateIterator();
            //looping iterator      
            Console.WriteLine("Iterating over collection:");

            for (Employee emp = iterator.First(); !iterator.IsCompleted; emp = iterator.Next())
            {
                Console.WriteLine($"ID : {emp.Id} & Name : {emp.Name}");
            }
        }
    }
}
