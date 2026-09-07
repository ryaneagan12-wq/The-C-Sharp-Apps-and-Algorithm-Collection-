using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TheHUB
{
    class Student
    {
        public int student_id;
        public string name;
        public int grade_level;
        public int enrollment_year;

        public Student(int student_id, string name, int grade_level, int enrollment_year)
        {
            this.student_id = student_id;
            this.name = name;
            this.grade_level = grade_level;
            this.enrollment_year = enrollment_year;
        }
        public int GetStudentID()
        {
            return student_id;
        }
        public string GetName()
        {
            return name;
        }
        public int GetGradelevel()
        {
            return grade_level;
        }
        public int GetEnrollmentYear()
        {
            return enrollment_year;
        }
        public string SubResults()
        {
            return $"ID{student_id}-{name}(Grade:{grade_level},Enrolled:{enrollment_year})";
        }
        public string FinalResults()
        {
            return $"{student_id},{name},{grade_level},{enrollment_year}";
        }
    }
    class Course
    {
        public int course_id;
        public string course_name;
        public string instructor;
        public int max_student;
        public List<string> enrolled_students;

        public Course(int course_id, string course_name, string instructor, int max_student,List<string>enrolled_students)
        {
            this.course_id = course_id;
            this.course_name = course_name;
            this.instructor = instructor;
            this.max_student = max_student;
            this.enrolled_students = new List<string>();
        }

        public int GetCourseID()
        {
            return course_id;
        }
        public string GetCourseName()
        {
            return course_name;
        }
        public string GetInstructor()
        {
            return instructor;
        }
        public int GetMaxStudent()
        {
            return max_student;
        }
        public List<string> GetEnrolledStudents()
        {
            return enrolled_students;
        }
        public string Initialize()
        {
            return $"Course:{course_name}by{instructor}({enrolled_students.Count}/{max_student}students)";
        }
        public Course LoadEnrolledStudents(List<string> id_list)
        {
            this.enrolled_students = id_list;
            return this;
        }
        public string FinalInitialize()
        {
            string enrolled_ids = string.Join(";", enrolled_students);
            return $"{course_id},{course_name},{instructor},{max_student},{enrolled_ids}";
        }
    }
    class TuitionCenter
    {
        public List<Student> students = new List<Student>();
        public List<Course> courses = new List<Course>();

        public TuitionCenter()
        {
            this.students = new List<Student>();
            this.courses = new List<Course>();
        }
        public List<Student> GetStudents()
        {
            return students;
        }
        public List<Course> GetCourses()
        {
            return courses;
        }
        public Student Find_student(int student_id)
        {
            foreach (Student Student in students)
            {
                if (Student.GetStudentID() == student_id)
                {
                    return Student;
                }
            }
            return null;
        }
        public Course Find_course(int course_id)
        {
            foreach (Course Course in courses)
            {
                if (Course.GetCourseID() == course_id)
                {
                    return Course;
                }
            }
            return null;
        }
        public Student Add_student(int student_id, string name, int grade_level, int enrollment_year)
        {
            if (Find_student(student_id) != null)
            {
                Console.WriteLine("The student of the same student id already exist");
                return null;
            }
            Student new_student = new Student(student_id, name, grade_level, enrollment_year);
            students.Add(new_student);
            Console.WriteLine($"Student:{name}(ID Number:{student_id},has been successfully added.)");
            return new_student;
        }
        public Course Add_course(int courseid, string coursename, string instructor, int maxstudents, List<string> enrolled_students)
        {
            if (Find_course(courseid) != null)
            {
                Console.WriteLine("The Course id already exist");
                return null;
            }
            Course new_course = new Course(courseid, coursename, instructor, maxstudents, enrolled_students);
            courses.Add(new_course);
            Console.WriteLine($"Course:{coursename}(ID Number:{courseid},has been successfully added");
            return new_course;
        }
        public Student Enroll_students(int student_id, int course_id)
        {
            Student student = Find_student(student_id);
            Course course = Find_course(course_id);

            if (student == null)
            {
                Console.WriteLine("Student is not found");
                return null;
            }
            if (course == null)
            {
                Console.WriteLine("Course is not found");
                return null;
            }
            if (course.GetEnrolledStudents().Count >= course.GetMaxStudent())
            {
                Console.WriteLine("Max space reached, failed to add student id.");
                return null;
            }
            if (course.enrolled_students.Contains(student_id.ToString()))
            {
                Console.WriteLine("Student already exists try again");
                return null;
            }

            course.enrolled_students.Add(student_id.ToString());
            Console.WriteLine($"Student:{student.GetName()}, has been successfully enrolled in: {course.GetCourseName()}");
            return student;
        }
        public Student Display_students()
        {
            if (students == null)
            {
                Console.WriteLine("No students found please try again.");
                return null;
            }
            Console.WriteLine("Current Students: ");
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.SubResults()}");
            }
            return null;
        }
        public Course Display_courses()
        {
            if (courses == null)
            {
                Console.WriteLine("No Courses found please try again.");
                return null;
            }
            Console.WriteLine("Current Courses: ");
            foreach (Course course in courses)
            {
                Console.WriteLine($"{course.Initialize()}");
                if (course.GetEnrolledStudents().Count > 0)
                {
                    List<string> enrolled_names = new List<string> { };
                    foreach (string student_id in course.GetEnrolledStudents())
                    {
                        Student student = Find_student(Convert.ToInt32(student_id));
                        if (student != null)
                        {
                            enrolled_names.Add(student.GetName());
                        }
                    }
                    Console.WriteLine($"Enrolled:{string.Join(",", enrolled_names)}");
                }
                else
                {
                    Console.WriteLine("Enrolled students: None");
                }
            }
            return null;
        }
        public void Save_Data(string student_filename, string course_filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(student_filename))
                {
                    foreach (Student student in students)
                    {
                        writer.WriteLine(student.FinalResults());
                    }
                }
                using (StreamWriter writer = new StreamWriter(course_filename))
                {
                    foreach (Course course in courses)
                    {
                        writer.WriteLine(course.FinalInitialize());
                    }
                }
                Console.WriteLine("Successfully saved data.");
            }
            catch (Exception)
            {
                Console.WriteLine("Couldn't save to file please try again.");
            }
        }
        public void Load_data(string student_filename, string course_filename)
        {
            students = new List<Student>();
            courses = new List<Course>(); 
            try
            {
                using (StreamReader Reader = new StreamReader(student_filename))
                {
                    string line;
                    while ((line = Reader.ReadLine()) != null)
                    {
                        if (line.Trim() != "")
                        {
                            string[] parts = line.Split(',');

                            if (parts.Length >= 4)
                            {
                                try
                                {
                                    int student_id = int.Parse(parts[0]);
                                    string name = parts[1];
                                    int grade_level = int.Parse(parts[2]);
                                    int enrollment_year = int.Parse(parts[3]);
                                    Student new_student = new Student(student_id, name, grade_level, enrollment_year);
                                    students.Add(new_student);
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Warning: Skipping Malformed line.");
                                }
                            }
                        }
                    }
                }

                using (StreamReader Reader = new StreamReader(course_filename))
                {
                    string line;
                    while ((line = Reader.ReadLine()) != null)
                    {
                        if (line.Trim() != "")
                        {
                            string[] parts = line.Split(',');

                            if (parts.Length >= 4)
                            {
                                try
                                {
                                    int course_id = int.Parse(parts[0]);
                                    string course_name = parts[1];
                                    string instructor = parts[2];
                                    int max_students = int.Parse(parts[3]);
                                    List<string> enrolled_ids = new List<string>(parts[4].Split(';'));
                                    Course new_course = new Course(course_id, course_name, instructor, max_students, enrolled_ids);
                                    courses.Add(new_course);
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Warning: Skipping malformed line.");
                                }
                            }
                        }
                    }
                }
                Console.WriteLine($"Data Loaded Successfully! Loaded {students.Count} student/s and {courses.Count} Course/s.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File is not found please try another.");
                this.students = new List<Student>();
                this.courses = new List<Course>();
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected error please try again.");
                this.students = new List<Student>();
                this.courses = new List<Course>();
            }
        }
        public void Sorting()
        {
            int Classmates = students.Count();
            int Comparison = 0;

            for (int i = 0; i < Classmates; i++)
            {
                for (int x = 0; x < Classmates - i - 1; x++)
                {
                    Comparison++;
                    if (this.students[x].name.CompareTo(this.students[x + 1].name) > 0)
                    {
                        Student temp = this.students[x];
                        this.students[x] = this.students[x + 1];
                        this.students[x + 1] = temp;
                    }
                }
            }
            Console.WriteLine("Sorted List:");
            Display_students();
        }
    }
    class TuitionCenterApp
    {
        public void Run()
        {
            Console.WriteLine("Tuition system started!");
            TuitionCenter center = new TuitionCenter();
            string Student_file = "C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Tuition Center Management System\\Tuition Center Management System\\students.csv";
            string Course_file = "C:\\Users\\ryan\\OneDrive\\Documents\\C#\\Tuition Center Management System\\Tuition Center Management System\\courses.csv";

            Console.WriteLine("Welcome to the Tuition Center Management System!");
            Console.WriteLine($"Loading Student Files and Course Files:,{Student_file}{Course_file}");
            center.Load_data(Student_file,Course_file);


            while (true)
            {
                Console.WriteLine("1. Add a new student");
                Console.WriteLine("2. Add a new course");
                Console.WriteLine("3. Enroll a student in a course");
                Console.WriteLine("4. Display all Students");
                Console.WriteLine("5. Display all Courses");
                Console.WriteLine("6. Sort Students By Name (challenge)");
                Console.WriteLine("7. Save Data to Files");
                Console.WriteLine("8. Load Data from Files");
                Console.WriteLine("9. Exit");
                Console.WriteLine("Choose a number from 1-9:");
                int Options = Convert.ToInt32(Console.ReadLine());

                if (Options == 1)
                {
                    try
                    {
                        Console.WriteLine("Enter the student ID: ");
                        int student_id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter student Name:");
                        string student_name = Console.ReadLine();
                        Console.WriteLine("Enter the Grade Level:");
                        int grade_level = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Enrollment Year:");
                        int Enrollment_year = Convert.ToInt32(Console.ReadLine());
                        center.Add_student(student_id, student_name, grade_level, Enrollment_year);

                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Invalid input please try again.");
                    }
                }
                else if (Options == 2)
                {
                    try
                    {
                        Console.WriteLine("Enter the Course ID:");
                        int courseid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Course Name:");
                        string course_name = Console.ReadLine();
                        Console.WriteLine("Enter the Instructor Name:");
                        string instructor = Console.ReadLine();
                        Console.WriteLine("Enter the number of Max Students: ");
                        int max_students = Convert.ToInt32(Console.ReadLine());
                        center.Add_course(courseid, course_name, instructor, max_students, new List<string>());
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Invalid input please try again.");
                    }
                }
                else if (Options == 3)
                {
                    Console.WriteLine("Enter the Student ID to enroll in: ");
                    int student_id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the Course ID to enroll in: ");
                    int course_id = Convert.ToInt32(Console.ReadLine());
                    center.Enroll_students(student_id, course_id);
                }
                else if (Options == 4)
                {
                    center.Display_students();
                }
                else if (Options == 5)
                {
                    center.Display_courses();
                }
                else if (Options == 6)
                {
                    center.Sorting();
                }
                else if (Options == 7)  
                {
                    center.Save_Data(Student_file, Course_file);
                }
                else if (Options == 8)
                {
                    center.Load_data(Student_file, Course_file);
                }
                else if (Options == 9)
                {
                    Console.WriteLine("Exiting the Program");
                    break;
                }
                else
                {
                    Console.WriteLine("Choice is invalid please try to input a number from 1 - 9 again.");
                }
            }
        }
    }

}

