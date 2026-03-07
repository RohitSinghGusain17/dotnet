using StudentPro.Models;
using StudentPro.Repositories;

namespace StudentPro.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateStudentAsync(Student student)
        {
            await _repository.AddAsync(student);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _repository.UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<bool> StudentExistsAsync(int id)
        {
            return await _repository.ExistsAsync(id);
        }
    }
}
