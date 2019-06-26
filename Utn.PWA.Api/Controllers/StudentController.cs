using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utn.PWA.DTOs;
using Utn.PWA.Helpers;
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
            var student = studentService.GetStudentById(id);

            if (student == null) 
            {
                return NotFound(new ApiResponse(404, $"No se encontro el estudiante con id {id}"));
            }
            return Ok(student);
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
            var result = studentService.CreateOrUpdate(student);
            return Ok(new ApiOkResponse(new {succes = result, message = "Estudiante creado correctamente"}));
        }

        [HttpGet("validateDni")]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult ValidateDni([FromQuery]string dni)
        {
            try
            {
                var isInvalid = studentService.ValidateDni(dni);

                return Ok(isInvalid);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("validateCuil")]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult ValidateCuil([FromQuery]string cuil)
        {
            try
            {
                var isInvalid = studentService.ValidateCuil(cuil);

                return Ok(isInvalid);
            }
            catch (Exception ex)
            {

                return NotFound(new ApiResponse(500, ex.InnerException.Message));
            }
        }
    }
}
