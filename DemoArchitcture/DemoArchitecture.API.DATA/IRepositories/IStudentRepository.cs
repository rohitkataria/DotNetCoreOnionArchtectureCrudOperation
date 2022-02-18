using DemoArchitecture.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoArchitecture.API.Data.IRepositories
{
    public interface IStudentRepository
    {
        Task<StudentModel> GetStudent(int Id);
        Task<IEnumerable<StudentModel>> GetAllStudent();
        Task<StudentModel> AddStudent(StudentModel studentModel);
        Task<bool> DeleteStudent(int id);
        Task<StudentModel> UpdateStudent(StudentModel studentModel);

    }
}
