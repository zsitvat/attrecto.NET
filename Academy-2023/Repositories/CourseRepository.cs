using Academy_2023.Data;

namespace Academy_2023.Repositories
{
    public class CourseRepository
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course? GetById(int id)
        {
            return _context.Courses.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Course data)
        {
            _context.Courses.Add(data);

            _context.SaveChanges();
        }

        public Course? Update(int id, Course data)
        {
            var user = _context.Courses.FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                user.Name = data.Name;
                user.Description = data.Description;

                _context.SaveChanges();
            }

            return user;
        }

        public bool Delete(int id)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Id == id);

            if (course != null)
            {
                _context.Courses.Remove(course);

                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
