using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_11
{
    class Course: IAnalytics
    {
        protected int ID { get; set; }
        protected string Title { get; set; }
        protected List<Student> StudentList { get; set; }
        protected bool IsActive { get; set; }
        public Course(int ID, string Title)
        {
            this.ID = ID;
            this.Title = Title;
            IsActive = true;
        }
        public Course(int ID, string Title, List<Student> StudentList)
        {
            this.ID = ID;
            this.Title = Title;
            this.StudentList = StudentList;
            IsActive = true;
        }
        public void UpdateStudentList(List<Student> StudentList)
        {
            if (!IsActive)
            {
                Console.WriteLine("Cannot perform action, this course is inactive");
            }
            else
            {
                this.StudentList = StudentList;
            }
        }
        public void PrintStudentList()
        {
            if (!IsActive)
            {
                Console.WriteLine("Cannot perform action, this course is inactive");
            }
            else
            {
                foreach (Student student in StudentList)
                {
                    Console.WriteLine(student.ReturnStudentFullName() + ": " + student.ReturnStudentGrade());
                }
            }
        }
        public List<Student> ReturnStudentList()
        {
            if (!IsActive)
            {
                Console.WriteLine("This student list is part of an inactive course");
            }
                return StudentList;
        }
        public void SortStudentListByGrades()
        {
            List<Student> SortedStudentList = new List<Student>();
            if (StudentList.Count() == 1)
            {
                SortedStudentList.Add(StudentList[0]);
            }
            if (StudentList.Count() == 2)
            {
                if (StudentList[0].ReturnStudentGrade() < StudentList[1].ReturnStudentGrade())
                {
                    SortedStudentList.Add(StudentList[0]);
                    SortedStudentList.Add(StudentList[1]);
                }
                if (StudentList[0].ReturnStudentGrade() > StudentList[1].ReturnStudentGrade())
                {
                    SortedStudentList.Add(StudentList[1]);
                    SortedStudentList.Add(StudentList[2]);
                }
            }
            if(StudentList.Count() > 2)
            {
                if (StudentList[0].ReturnStudentGrade() < StudentList[1].ReturnStudentGrade())
                {
                    SortedStudentList.Add(StudentList[0]);
                    SortedStudentList.Insert(1, StudentList[1]);
                }
                if (StudentList[0].ReturnStudentGrade() > StudentList[1].ReturnStudentGrade())
                {
                    SortedStudentList.Add(StudentList[1]);
                    SortedStudentList.Insert(1, StudentList[2]);
                }
                RemoveStudent(StudentList[0].ReturnID());
                RemoveStudent(StudentList[1].ReturnID());
                foreach(Student student in StudentList)
                {
                    if(student.ReturnStudentGrade() < SortedStudentList[0].ReturnStudentGrade())
                    {
                        SortedStudentList.Add(StudentList[0]);
                    }
                    for (int i = 0; i < SortedStudentList.Count()-1; i++)
                    {
                        if (i < SortedStudentList.Count() -2 && student.ReturnStudentGrade() > SortedStudentList[i].ReturnStudentGrade() && student.ReturnStudentGrade() < SortedStudentList[i+1].ReturnStudentGrade())
                        {
                            SortedStudentList.Insert(i, student);
                        }
                        if(i == SortedStudentList.Count() - 1 && student.ReturnStudentGrade() > SortedStudentList[i].ReturnStudentGrade())
                        {
                            SortedStudentList.Add(student);
                        }
                    }
                }
            }
            StudentList = SortedStudentList;
        }
        public void RemoveStudent(int RemoveID)
        {
            if (!IsActive)
            {
                Console.WriteLine("This course is currently inactive");
            }
            foreach (Student student in StudentList)
            {
                if (student.ReturnID() == RemoveID)
                {
                    StudentList.Remove(student);
                }
            }
        }
        public void AddStudent(Student student)
        {
            if (!IsActive)
            {
                Console.WriteLine("This course is currently inactive");
            }
            StudentList.Add(student);
        }
        public void RemoveCourse()
        {
            this.IsActive = false;
        }
        public decimal StudentGradeAverage()
        {
            decimal average = 0;
            foreach(Student student in StudentList)
            {
                average += student.ReturnStudentGrade();
            }
            average = average / StudentList.Count;
            return average;
        }
        public decimal Minimum()
        {
            decimal minimum = 100;
            foreach(Student student in StudentList)
            {
                if (student.ReturnStudentGrade() < minimum)
                {
                    minimum = student.ReturnStudentGrade();
                }
            }
            return minimum;
        }
        public decimal Maximum()
        {
            decimal maximum = 0;
            foreach(Student student in StudentList)
            {
                if(student.ReturnStudentGrade() > maximum)
                {
                    maximum = student.ReturnStudentGrade();
                }
            }
            return maximum;
        }
        public decimal Median()
        {
            int middle = StudentList.Count() / 2;
            SortStudentListByGrades();
            if (StudentList.Count() %2 == 1)
            {
                return StudentList[middle].ReturnStudentGrade();
            }
            else
            {
                Console.WriteLine("There is an even number of students in this course, the median would be: ");
                return ((StudentList[middle].ReturnStudentGrade() + StudentList[middle + 1].ReturnStudentGrade()) / 2);
            }
        }
        public decimal PercentA()
        {
            Console.WriteLine("Still needs to be implemented");
            return Convert.ToDecimal(0);
        }
        public decimal PercentB()
        {
            Console.WriteLine("Still needs to be implemented");
            return Convert.ToDecimal(0);
        }
        public decimal PercentC()
        {
            Console.WriteLine("Still needs to be implemented");
            return Convert.ToDecimal(0);
        }
        public decimal PercentD()
        {
            Console.WriteLine("Still needs to be implemented");
            return Convert.ToDecimal(0);
        }
        public decimal PercentF()
        {
            Console.WriteLine("Still needs to be implemented");
            return Convert.ToDecimal(0);
        }

    }
    class MathCourse:Course
    {
        public MathCourse(int ID, string Title): base(ID, Title)
        {
            this.ID = ID;
            this.Title = Title;
        }
        public MathCourse(int ID, string Title, List<Student> StudentList): base(ID, Title, StudentList)
        {
            this.ID = ID;
            this.Title = Title;
            this.StudentList = StudentList;
        }
    }
    class EnglishCourse : Course
    {
        public EnglishCourse(int ID, string Title): base(ID, Title)
        {
            this.ID = ID;
            this.Title = Title;
        }
        public EnglishCourse(int ID, string Title, List<Student> StudentList): base(ID, Title, StudentList)
        {
            this.ID = ID;
            this.Title = Title;
            this.StudentList = StudentList;
        }
    }

    public interface IAnalytics
    {
        decimal StudentGradeAverage();
        decimal Minimum();
        decimal Maximum();
        decimal Median();
        decimal PercentA();
        decimal PercentB();
        decimal PercentC();
        decimal PercentD();
        decimal PercentF();

    }
    class Student
    {
        protected int ID { get; set; }
        protected string FirstName { get; set; }
        protected string LastName { get; set; }
        protected decimal Grade { get; set; }
        Student(int ID, string FirstName, string LastName)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        Student(int ID, string FirstName, string LastName, decimal Grade)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Grade = Grade;
        }
        public void UpdateGrade(decimal Grade)
        {
            this.Grade = Grade;
        }
        public string ReturnStudentFullName()
        {
            string A = "";
            A = FirstName + " " + LastName;
            return A;
        }
        public decimal ReturnStudentGrade()
        {
            return Grade;
        }
        public int ReturnID()
        {
            return ID;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            bool IsRunning = true;
            string MenuInput = "";
            string Input1 = "";
            string Input2 = "";
            string Input3 = "";
            while (IsRunning)
            {
                Console.WriteLine("Welcome to the main menu.");
                Console.WriteLine("1. Enter Course");
                Console.WriteLine("2. Enter Students");
                Console.WriteLine("3. Remove Students");
                Console.WriteLine("4. Remove Course");
                Console.WriteLine("5. Enter Student Grade");
                Console.WriteLine("6. Grade Analytics");
                Console.WriteLine("7. Quit");
                MenuInput = Console.ReadLine();
                
                if (MenuInput == "7")
                    IsRunning = false;
                if (MenuInput == "1")
                {
                    Console.WriteLine("Enter 1 to add a Math Course, Enter 2 to add an English Course");
                    //REMEMBER TO ADD CODE SPECIFIC TO MATH AND ENGLISH
                    Input3 = Console.ReadLine();
                    if (Input3 == "1")
                    {
                        Console.WriteLine("Please enter the name of the course you want to add: ");
                        Input1 = Console.ReadLine();
                        Console.WriteLine("Please enter the ID of the course you want to add: ");
                        Input2 = Console.ReadLine();
                        //MathCourse Input1 = new MathCourse(Convert.ToInt32(Input2), Convert.ToString(Input1));
                    }
                }
            }
        }
    }
}
