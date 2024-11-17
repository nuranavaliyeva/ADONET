using ADONET.Data;
using ADONET.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET.Services
{
    internal class StudentService
    {
        private static Sql _sql;
        public StudentService()
        {
            _sql = new Sql();

        }
        public void Add(Student student)
        {
            int result = _sql.ExecuteCommand($"INSERT INTO Students VALUES('{student.Name}','{student.Surname}','{student.Age}')");
            if (result > 0)
            {
                Console.WriteLine("Student created");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
           DataTable table = _sql.ExecuteQuery("SELECT * FROM Students");
            foreach (DataRow item in table.Rows)
            {
                Student student = new Student
                {
                    Id = (int)item["Id"],
                    Name = item["Name"].ToString(),
                    Surname = item["Surname"].ToString(),
                    Age =(int)item["Age"]
                };
                students.Add(student);
            }
            return students;
        }
        public void Delete(int id)
        {
            _sql.ExecuteCommand($"DELETE FROM Students WHERE Id={id}");
        }
        public void Update(Student student, int id)
        {
             int result = _sql.ExecuteCommand($"UPDATE Students SET Name='{student.Name}',Surname ='{student.Surname}',Age={student.Age} WHERE Id={id}");
        }
        public List<Student> GetStudentId(int id)
        {
            List<Student> students = new List<Student>();
            DataTable table = _sql.ExecuteQuery($"SELECT * FROM Students WHERE Id={id}");
            foreach (DataRow item in table.Rows)
            {
                Student student = new Student
                {
                    Id = (int)item["Id"],
                    Name = item["Name"].ToString(),
                    Surname = item["Surname"].ToString(),
                    Age = (int)item["Age"]
                };
                students.Add(student);
            }
            return students;
        }

    }
    }



