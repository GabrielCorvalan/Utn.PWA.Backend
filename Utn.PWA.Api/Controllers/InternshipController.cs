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
    public class InternshipController : ControllerBase
    {
        private readonly IInternshipService internshipService;

        public InternshipController(IInternshipService service)
        {
            internshipService = service;
        }

        [HttpGet]
        [Produces("application/json", Type = typeof(IEnumerable<InternshipDTO>))]
        public IActionResult GetAllInternships()
        {
            try
            {
                return Ok(internshipService.GetAllInternships());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(InternshipDTO))]
        public IActionResult GetInternshipById(int id)
        {
            try
            {
                return Ok(internshipService.GetInternshipById(id));
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
                var internship = internshipService.GetInternshipById(Id);

                return Ok(internshipService.Delete(internship));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult Post([FromBody]InternshipDTO internship)
        {
            try
            {
                return Ok(internshipService.CreateOrUpdate(internship));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}