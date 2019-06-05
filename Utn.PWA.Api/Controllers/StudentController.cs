using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utn.PWA.DTOs;
using Utn.PWA.Services.Interfaces;

namespace Utn.PWA.Api.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService service)
        {
            studentService = service;
        }

        [HttpGet]
        [Produces("application/json", Type = typeof(IEnumerable<StudentDTO>))]
        public IActionResult GetAllStudents()
        {
            try
            {
                return Ok(studentService.GetAllStudents());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(StudentDTO))]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                return Ok(studentService.GetStudentById(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult Delete(int Id)
        {
            try
            {
                var student = studentService.GetStudentById(Id);

                return Ok(studentService.Delete(student));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult Post([FromBody]StudentDTO student)
        {
            try
            {
                return Ok(studentService.CreateOrUpdate(student));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
