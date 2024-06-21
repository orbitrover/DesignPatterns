using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.CustomIteratorDesignPatternIntro
{
    // ConcreteAggregate Class
    // The following class going to implement the Iterator interface to return an instance of the proper ConcreteIterator
    public class ConcreteCollection : IAbstractCollection
    {
        //The following collection object is going to hold a list of items or elements
        private List<Employee> listEmployees = new List<Employee>();
        //Implementing the CreateIterator method of the IAbstractCollection interface
        //The following method is going to Create and return the Iterator Object
        //Later we will implement the Iterator
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        // The following method is going to return the count of the elements present in the collection
        public int Count
        {
            get { return listEmployees.Count; }
        }
        //Add items to the collection
        public void AddEmployee(Employee employee)
        {
            listEmployees.Add(employee);
        }
        //Add Employee collection
        public void AddEmployeeList(List<Employee> employees)
        {
            listEmployees.AddRange(employees);
        }
        //Get items from the collection based on the Index Position
        //Index is started from 0
        public Employee GetEmployee(int IndexPosition)
        {
            return listEmployees[IndexPosition];
        }
    }
}
