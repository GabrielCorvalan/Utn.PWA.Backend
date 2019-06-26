using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Utn.PWA.DTOs;
using Utn.PWA.Services.Interfaces;

namespace Utn.PWA.Api.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyTutorController : ControllerBase
    {
        private readonly ICompanyTutorService companyTutorService;

        public CompanyTutorController(ICompanyTutorService service)
        {
            companyTutorService = service;
        }

        [HttpGet]
        [Produces("application/json", Type = typeof(IEnumerable<CompanyTutorDTO>))]
        public IActionResult GetAllCompanyTutors()
        {
            try
            {
                return Ok(companyTutorService.GetAllCompanyTutors());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(CompanyTutorDTO))]
        public IActionResult GetCompanyTutorById(int id)
        {
            try
            {
                return Ok(companyTutorService.GetCompanyTutorById(id));
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
                var companyTutor = companyTutorService.GetCompanyTutorById(Id);

                return Ok(companyTutorService.Delete(companyTutor));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult Post([FromBody]CompanyTutorDTO companyTutor)
        {
            try
            {
                return Ok(companyTutorService.CreateOrUpdate(companyTutor));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}