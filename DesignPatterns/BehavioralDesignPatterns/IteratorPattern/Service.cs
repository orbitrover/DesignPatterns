using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IteratorPattern
{
    public class ProgramRun
    {
        public static void Run()
        {
            Console.WriteLine("======================================Checking Struct Memory==================================================");
            Console.WriteLine("");
            // Here I am Creating a 3 Struct Objects that will Contain 3 employee data with EmpTypeId = {1,2,3}
            // As we know structs are data structures that can contain data members and function members, but unlike classes, structs are value types and do not require heap allocation.
            // and value types memory can  not travel entire application or we can say it can not be access in entire application by its currently created instance.

            EmployeeStruct empStruct1 = new EmployeeStruct() { Id = 1, EmpTypeId = 1, Name = "Orbit Rover", Salary = 12456.25f };
            Service.modifyEmployeeStruct(empStruct1);
            var jsonStruct1 = JsonConvert.SerializeObject(empStruct1);
            Console.WriteLine($"1. EmployeeStruct: {jsonStruct1}");

            EmployeeStruct empStruct2 = new EmployeeStruct() { Id = 2, EmpTypeId = 2, Name = "Nion Tesla", Salary = 12456.25f };
            Service.modifyEmployeeStruct(empStruct2);
            var jsonStruct2 = JsonConvert.SerializeObject(empStruct2);
            Console.WriteLine($"2. EmployeeStruct: {jsonStruct2}");

            EmployeeStruct empStruct3 = new EmployeeStruct() { Id = 3, EmpTypeId = 3, Name = "Rocky Rikky", Salary = 12456.25f };
            Service.modifyEmployeeStruct(empStruct3);
            var jsonStruct3 = JsonConvert.SerializeObject(empStruct3);
            Console.WriteLine($"3. EmployeeStruct: {jsonStruct3}");

            Console.WriteLine("");
            Console.WriteLine("========================================Checking Class Memory================================================");
            Console.WriteLine("");
            // Here I am Creating a 3 Class Objects that will Contain 3 employee data with EmpTypeId = {1,2,3}
            // As we know classes are data structures that can contain data members and function members, but unlike structs, classes are data types and require heap allocation.
            // and Heep memory can travel entire application or we can say it can be access in entire application by its currently created instance.

            EmployeeClass empClass1 = new EmployeeClass() { Id = 1, EmpTypeId = 1, Name = "Orbit Rover", Salary = 12456.25f };
            Service.modifyEmployeeClass(empClass1);
            var jsonClass1 = JsonConvert.SerializeObject(empClass1);
            Console.WriteLine($"1. EmployeeClass: {jsonClass1}");

            EmployeeClass empClass2 = new EmployeeClass() { Id = 2, EmpTypeId = 2, Name = "Nion Tesla", Salary = 12456.25f };
            Service.modifyEmployeeClass(empClass2);
            var jsonClass2 = JsonConvert.SerializeObject(empClass2);
            Console.WriteLine($"2. EmployeeClass: {jsonClass2}");

            EmployeeClass empClass3 = new EmployeeClass() { Id = 3, EmpTypeId = 3, Name = "Rocky Rikky", Salary = 12456.25f };
            Service.modifyEmployeeClass(empClass3);
            var jsonClass3 = JsonConvert.SerializeObject(empClass3);
            Console.WriteLine($"3. EmployeeClass: {jsonClass3}");

            Console.WriteLine("");
            Console.WriteLine("=============================================================================================================");
        }
    }
    ///<summary>
    ///Here I have Create a Struct For Employee
    ///</summary>
    public struct EmployeeStruct
    {
        public int Id { get; set; }
        public int EmpTypeId { get; set; }
        public string Name { get; set; }
        public float Salary { get; set; }
        public float Bonus { get; set; }
    }
    ///<summary>
    ///Here I have Create a Class For Employee.
    /// Both EmployeeStruct and EmployeeClass have Same number of Property with the same datatype
    ///</summary>
    public class EmployeeClass
    {
        public int Id { get; set; }
        public int EmpTypeId { get; set; }
        public string Name { get; set; }
        public float Salary { get; set; }
        public float Bonus { get; set; }
    }
    internal class Service
    {
        public static void modifyEmployeeStruct(EmployeeStruct empStruct)
        {
            if (empStruct.EmpTypeId == 1 && empStruct.Salary > 0)
            {
                empStruct.Bonus = empStruct.Salary * 0.08f;
            }
            else if (empStruct.EmpTypeId == 2 && empStruct.Salary > 0)
            {
                empStruct.Bonus = empStruct.Salary * 0.12f;
            }
            else
            {
                empStruct.Bonus = empStruct.Salary * 0.01f;
            }
        }
        public static void modifyEmployeeClass(EmployeeClass empClass)
        {
            if (empClass.EmpTypeId == 1 && empClass.Salary > 0)
            {
                empClass.Bonus = empClass.Salary * 0.08f;
            }
            else if (empClass.EmpTypeId == 2 && empClass.Salary > 0)
            {
                empClass.Bonus = empClass.Salary * 0.12f;
            }
            else
            {
                empClass.Bonus = empClass.Salary * 0.01f;
            }
        }
    }
}
