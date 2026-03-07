using StudentPro.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentPro.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentPortalDbContext _context;

        public StudentRepository(StudentPortalDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students
                .FirstOrDefaultAsync(x => x.StudentId == id);
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Students.AnyAsync(x => x.StudentId == id);
        }
    }
}
