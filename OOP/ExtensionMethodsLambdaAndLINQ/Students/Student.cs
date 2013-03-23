using System;
using System.Collections.Generic;

namespace Students
{
    public class Student
    {
        #region Properties

        public static Student[] Students { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public byte Age { get; private set; }

        #endregion

        #region Constructors

        static Student()
        {
            Students = new Student[]
            {
                new Student("Ivancho", "Ivanchov", 23),
                new Student("Pesho", "Peshov", 27),
                new Student("Joro", "Jorov", 19),
                new Student("Zlatko", "Alexandrov", 7),
                new Student("Alex", "Alexandrova", 33)
            };
        }

        private Student(string firstName, string lastName, byte age = 20)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        #endregion

        #region Public Methods

        public static void Print(string title, IEnumerable<Student> students)
        {
            Console.WriteLine(title);

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();
        }

        public override string ToString()
        {
            return string.Format("FirstName: {0}, LastName: {1}, Age: {2}",
                this.FirstName, this.LastName, this.Age);
        }

        #endregion
    }
}
