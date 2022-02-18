using DemoArchitecture.API.Data.IRepositories;
using DemoArchitecture.API.Models;
using DemoArchitecture.API.Services.IServices;

namespace DemoArchitecture.API.Services.Services
{
    public class StudentServices : IStudentServices
    {
        public readonly IStudentRepository studentRepository;
        public StudentServices(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }
        //Get all employees
        public async Task<IEnumerable<StudentModel>> GetAllStudent()
        {
            return await studentRepository.GetAllStudent();
        }
        //Get Student by Id
        public async Task<StudentModel> GetStudent(int Id)
        {
            return await studentRepository.GetStudent(Id);
        }
        //Add Student Records

        public async Task<StudentModel> AddStudent(StudentModel studentModel)
        {
            return await studentRepository.AddStudent(studentModel);
        }

        //Delete student by Id
        public async Task<bool> DeleteStudent(int id)
        {
            return await studentRepository.DeleteStudent(id);
        }

        public Task<StudentModel> UpdateStudent(StudentModel studentModel)
        {
           return studentRepository.UpdateStudent(studentModel);
        }
    }
}
