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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService service)
        {
            companyService = service;
        }

        [HttpGet]
        [Produces("application/json", Type = typeof(IEnumerable<CompanyDTO>))]
        public IActionResult GetAllCompanies()
        {
            try
            {
                return Ok(companyService.GetAllCompanies());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(CompanyDTO))]
        public IActionResult GetCompanyById(int id)
        {
            try
            {
                return Ok(companyService.GetCompanyById(id));
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
                var company = companyService.GetCompanyById(Id);

                return Ok(companyService.Delete(company));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult Post([FromBody]CompanyDTO company)
        {
            try
            {
                return Ok(companyService.CreateOrUpdate(company));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}