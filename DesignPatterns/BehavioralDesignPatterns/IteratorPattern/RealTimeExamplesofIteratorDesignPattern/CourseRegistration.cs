using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.RealTimeExamplesofIteratorDesignPattern
{
    /// <summary>
    /// Client Code
    /// </summary>
    public static class CourseRegistration
    {
        public static void Run()
        {
            var mathsCourse = new Course();
            mathsCourse.RegisterStudent(new Student("Pranaya", "1001"));
            mathsCourse.RegisterStudent(new Student("Rout", "1002"));
            var physicsCourse = new Course();
            physicsCourse.RegisterStudent(new Student("Anurag", "1003"));
            var university = new University();
            university.AddCourse(mathsCourse);
            university.AddCourse(physicsCourse);
            var iterator = university.CreateIterator();
            while (iterator.HasNext())
            {
                var student = iterator.Next();
                Console.WriteLine($"Name: {student.Name}, ID: {student.ID}");
            }

        }
    }
    //Define the Student
    public class Student
    {
        public string Name { get; private set; }
        public string ID { get; private set; }
        public Student(string name, string id)
        {
            Name = name;
            ID = id;
        }
    }
    
    //Implement a concrete aggregate, Course, and the collection University:
    public class Course : INextAggregate<Student>
    {
        private List<Student> _students = new List<Student>();
        public void RegisterStudent(Student student)
        {
            _students.Add(student);
        }
        public INextIterator<Student> CreateIterator()
        {
            return new CourseIterator(this);
        }
        private class CourseIterator : INextIterator<Student>
        {
            private Course _course;
            private int _currentIndex = 0;
            public CourseIterator(Course course)
            {
                _course = course;
            }
            public bool HasNext()
            {
                return _currentIndex < _course._students.Count;
            }
            public Student Next()
            {
                return _course._students[_currentIndex++];
            }
        }
    }
    public class University : INextAggregate<Student>
    {
        private List<Course> _courses = new List<Course>();
        public void AddCourse(Course course)
        {
            _courses.Add(course);
        }
        public INextIterator<Student> CreateIterator()
        {
            return new UniversityIterator(this);
        }
        private class UniversityIterator : INextIterator<Student>
        {
            private University _university;
            private int _courseIndex = 0;
            private INextIterator<Student> _currentCourseIterator;
            public UniversityIterator(University university)
            {
                _university = university;
                if (_university._courses.Any())
                {
                    _currentCourseIterator = _university._courses[_courseIndex].CreateIterator();
                }
            }
            public bool HasNext()
            {
                if (_currentCourseIterator == null) return false;
                if (_currentCourseIterator.HasNext()) return true;
                // Move to the next course
                if (_courseIndex < _university._courses.Count - 1)
                {
                    _currentCourseIterator = _university._courses[++_courseIndex].CreateIterator();
                    return _currentCourseIterator.HasNext();
                }
                return false;
            }
            public Student Next()
            {
                if (_currentCourseIterator != null && _currentCourseIterator.HasNext())
                {
                    return _currentCourseIterator.Next();
                }
                return null;
            }
        }
    }
}
