using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utn.PWA.DTOs;
using Utn.PWA.Services.Interfaces;

namespace Utn.PWA.Api.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService teacherService;

        public TeacherController(ITeacherService service)
        {
            teacherService = service;
        }

        [HttpGet]
        [Produces("application/json", Type = typeof(IEnumerable<TeacherDTO>))]
        public IActionResult GetAllTeachers()
        {
            try
            {
                return Ok(teacherService.GetAllTeachers());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(TeacherDTO))]
        public IActionResult GetTeacherById(int id)
        {
            try
            {
                return Ok(teacherService.GetTeacherById(id));
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
                var teacher = teacherService.GetTeacherById(Id);

                return Ok(teacherService.Delete(teacher));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult Post([FromBody]TeacherDTO teacher)
        {
            try
            {
                return Ok(teacherService.CreateOrUpdate(teacher));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}