namespace _017_web_Ass2.Models
{
    

        public class SchoolService
        {
            private readonly SchoolDbContext _dbContext;

            public SchoolService(SchoolDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            // LINQ queries

            public IEnumerable<object> GetClassesWithMoreThan100Students()
            {
                return _dbContext.Classes
                    .Where(c => c.Enrollments.Count > 100)
                    .Select(c => new { c.Name, c.RoomNumber });
            }

            public IEnumerable<object> GetStudentsWithNoClassesInDept22()
            {
                return _dbContext.Students
                    .Where(s => !s.Enrollments.Any(e => e.Class.Faculty.Deptid == 22))
                    .Select(s => new { s.Sid, s.Major });
            }

            public IEnumerable<string> StudentsWithNoMarks()
            {
                return _dbContext.Students
                    .Where(s => s.Enrollments.Any(e => !e.Marks.Any()))
                    .Select(s => s.Sname);
            }

            public IEnumerable<object> StudentsEnrolledInMoreThanTwoClasses()
            {
                return _dbContext.Students
                    .Where(s => s.Enrollments.Count > 2)
                    .Select(s => new
                    {
                        StudentName = s.Sname,
                        NumberOfClasses = s.Enrollments.Count
                    });
            }

            public IEnumerable<object> FacultyNamesWithTotalClasses()
            {
                return _dbContext.Faculties
                    .OrderByDescending(f => f.Classes.Count)
                    .Select(f => new
                    {
                        FacultyName = f.Fname,
                        TotalClasses = f.Classes.Count
                    });
            }

        }

    }

