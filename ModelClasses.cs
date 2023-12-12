namespace _017_web_Ass2.Models
{
    public class ModelClasses
    {
        public class Student
        {
            public int Sid { get; set; }
            public string Sname { get; set; }
            public string Major { get; set; }
            public string Standing { get; set; }

            public List<Enrolled> Enrollments { get; set; }
        }

        public class Faculty
        {
            public int Fid { get; set; }
            public string Fname { get; set; }
            public int Deptid { get; set; }
            public string Standing { get; set; }

            public List<Class> Classes { get; set; }
        }

        public class Class
        {
            public int Cid { get; set; }
            public string Name { get; set; }
            public string RoomNumber { get; set; }
            public int Fid { get; set; }

            public Faculty Faculty { get; set; }
            public List<Enrolled> Enrollments { get; set; }
        }

        public class Enrolled
        {
            public int Id { get; set; }
            public int Sid { get; set; }
            public int Cid { get; set; }

            public ModelClasses Student { get; set; }
            public Class Class { get; set; }
        }
    }
}