using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using Evaluation_Manager.Models;

namespace Evaluation_Manager.Repositories
{
    public class TeacherRepository
    {
        public static Teacher GetTeacher(int id)
        {
            return FetchTeacher($"SELECT * FROM Teacher WHERE Id = {id}");
        }
        public static Teacher GetTeacher(string username)
        {
            return FetchTeacher($"SELECT * FROM Teacher WHERE Username = '{username}'");
        }

        private static Teacher FetchTeacher(string sql)
        {
            Teacher teacher = null;
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                teacher = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return teacher;
        }

        public static List<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            string sql = "SELECT * FROM Teacher";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Teacher teacher = CreateObject(reader);
                teachers.Add(teacher);
            }
            reader.Close();
            DB.CloseConnection();
            return teachers;
        }

        private static Teacher CreateObject(System.Data.SqlClient.SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string firstName = reader["FirstName"].ToString();
            string lastName = reader["LastName"].ToString();
            int.TryParse(reader["Grade"].ToString(), out int grade);

            var teacher = new Teacher
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                //rade = grade
            };

            return teacher;
        }
    }
}
