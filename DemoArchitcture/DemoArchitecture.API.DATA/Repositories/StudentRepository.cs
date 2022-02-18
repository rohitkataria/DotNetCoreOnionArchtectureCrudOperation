using DemoArchitecture.API.Data.Context;
using DemoArchitecture.API.Data.IRepositories;
using DemoArchitecture.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoArchitecture.API.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public readonly ApplicationDBContext _applicationDBContext;
        public StudentRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public async Task<IEnumerable<StudentModel>> GetAllStudent()
        {
            return await _applicationDBContext.Student.ToListAsync();
        }

        public async Task<StudentModel> GetStudent(int Id)
        {
            return await _applicationDBContext.Student.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<StudentModel> AddStudent(StudentModel studentModel)
        {
            var result = await _applicationDBContext.AddAsync(studentModel);
            await _applicationDBContext.SaveChangesAsync();
            return result.Entity;
        }


        public async Task<bool> DeleteStudent(int id)
        {
            var student = _applicationDBContext.Student.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                _applicationDBContext.Student.Remove(student);
                var res = await _applicationDBContext.SaveChangesAsync();
                return res > 0;
            }
            return false;
        }

        public async Task<StudentModel> UpdateStudent(StudentModel studentModel)
        {
            var result = await _applicationDBContext.Student.FirstOrDefaultAsync(x => x.Id == studentModel.Id);
            if (result != null)
            {
                result.Id = studentModel.Id;
                result.Name = studentModel.Name;
                result.City = studentModel.City;
                result.Age = studentModel.Age;
                await _applicationDBContext.SaveChangesAsync();
                return result;
            }
            return studentModel;
        }
    }
}
