using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utn.PWA.DTOs;
using Utn.PWA.Services.Interfaces;

namespace Utn.PWA.Api.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController, Authorize]
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
                var Id = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
                
                return Ok(internshipService.CreateOrUpdate(internship, Id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost("Cancel/{id}")]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult CancelInternship([FromForm]string cancelationDescription, int id, [FromForm]DateTime? cancelationDate = null)
        {
            try
            {

                var userId = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;

                return Ok(internshipService.CancelInternship(cancelationDescription, id, int.Parse(userId), cancelationDate));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Renove/{id}")]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult RenoveInternship(int id, [FromForm]DateTime? renovationDate = null)
        {
            try
            {
                var userId = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;

                return Ok(internshipService.RenoveInternship(id, int.Parse(userId), renovationDate));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}