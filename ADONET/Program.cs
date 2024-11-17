using ADONET.Data;
using ADONET.Models;
using ADONET.Services;

namespace ADONET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentService studentService = new StudentService();
            Student student = new Student { Name = "Ayxan", Surname = "Mammadli", Age = 19};
            Student student2 = new Student { Name = "Allahverdi", Surname = "Sultanov", Age = 19 };
            //studentService.Add(student);

            //studentService.Delete(2);

            //List<Student> students = studentService.GetAll(); 
            //foreach (var item in students)
            //{
            //    Console.WriteLine(item.Id + " " + item.Name + " " + item.Surname + " " + item.Age);
            //}

            //List<Student> students1 = studentService.GetStudentId(1);
            //foreach (var item in students1)
            //{
            //    Console.WriteLine(item.Id + " " + item.Name + " " + item.Surname + " " + item.Age);
            //}
            studentService.Update(student2, 1);
        }
    }
}
