using DemoArchitecture.API.Models;
using DemoArchitecture.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;
namespace DemoArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public readonly IStudentServices _studentServices;
        public StudentController(IConfiguration configuration, IStudentServices studentServices)
        {
            _configuration = configuration;
            _studentServices = studentServices;
        }

        [HttpGet("Get all Student")]
        public async Task<ActionResult> GetAllStudent()
        {
            try
            {
                return Ok(await _studentServices.GetAllStudent());
            }
            catch (Exception)
            {
               return  StatusCode(StatusCodes.Status500InternalServerError, "Error is retreiving from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudentModel>> GetStudent(int id)
        {
            try
            {
                var result = await _studentServices.GetStudent(id);
                if(result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error is retreiving from database");
            }
        }

        // Add Student record
        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent(StudentModel studentModel){
            var result = await _studentServices.AddStudent(studentModel);
            if (result !=null)
                return Ok(new { Data = result, message = "Insert student data"});

            return StatusCode(StatusCodes.Status400BadRequest, "Not Added");
        }

        //Delete student by Id
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteStudent(int id)
        {
            try
            {   
                  return await _studentServices.DeleteStudent(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error is retreiving from database");
            }
        }

        //Update Student Records
        [HttpPut("Update student")]
        public async Task<ActionResult<StudentModel>> UpdateStudent( StudentModel studentModel)
        {
            try
            {
               
                return Ok( await _studentServices.UpdateStudent(studentModel));
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error is retreiving from database");

            }
        }


    }
}
