using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Tasks
    {
        #region First Task

        // Write a method that from a given array of students finds all students whose
        // first name is before its last name alphabetically. Use LINQ query operators.
        public static IEnumerable<Student> FirstNameBeforeLastName(Student[] students)
        {
            return from student in students
                   where student.FirstName.CompareTo(student.LastName) < 0
                   select student;
        }

        #endregion

        #region Second Task

        // Write a LINQ query that finds the first name and last name of all
        // students with age between 18 and 24.
        public static IEnumerable<Student> StudentsBetween18And24(Student[] students)
        {
            return from student in students
                   where student.Age >= 18 && student.Age <= 24
                   select student;
        }

        #endregion

        #region Third Task

        // Using the extension methods OrderBy() and ThenBy() with lambda expressions
        // sort the students by first name and last name in descending order.
        // Rewrite the same with LINQ.

        public static IEnumerable<Student> DescendingOrderMethods(Student[] students)
        {
            return students.OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName);
        }

        public static IEnumerable<Student> DescendingOrderLinq(Student[] students)
        {
            return from student in students
                   orderby student.FirstName descending,
                           student.LastName descending
                   select student;
        }

        #endregion

        static void Main()
        {
            var students = Student.Students;

            var firstTask = FirstNameBeforeLastName(students);
            Student.Print("First Task: ", firstTask);

            var secondTask = StudentsBetween18And24(students);
            Student.Print("Second Task: ", secondTask);

            var thirdTaskMethods = DescendingOrderMethods(students);
            Student.Print("Third Task With Extension Methods: ", thirdTaskMethods);

            var thirdTaskLinq = DescendingOrderLinq(students);
            Student.Print("Third Task With LINQ: ", thirdTaskLinq);
        }
    }
}
