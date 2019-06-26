using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utn.PWA.DTOs;
using Utn.PWA.Helpers;
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
            var internship = internshipService.GetAllInternships();
            return Ok(internship);
        }

        [HttpGet("filter")]
        public IActionResult FilterGetAllInternship([FromQuery]InternshipFilterDTO filter)
        {
            var internship = internshipService.FilterGetAllInternship(filter);
            return Ok(internship);
        }

        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(InternshipDTO))]
        public IActionResult GetInternshipById(int id)
        {
            var internship = internshipService.GetInternshipById(id);

            if (internship == null) 
            {
                return NotFound(new ApiResponse(404, $"No se encontro la pasantia con id {id}"));
            }

            return Ok(internship);
        }

        [HttpDelete("{id}")]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult Delete(int Id)
        {
            var internship = internshipService.GetInternshipById(Id);

            return Ok(internshipService.Delete(internship));
        }


        [HttpPost]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult Post([FromBody]InternshipDTO internship)
        {
            var Id = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            
            return Ok(internshipService.CreateOrUpdate(internship, Id));
        }

        [HttpPost("Cancel/{id}")]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult CancelInternship([FromForm]string cancelationDescription, int id, [FromForm]DateTime? cancelationDate = null)
        {
            var userId = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;

            return Ok(internshipService.CancelInternship(cancelationDescription, id, int.Parse(userId), cancelationDate));
        }

        [HttpPost("Renove/{id}")]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult RenoveInternship(int id, [FromForm]DateTime? renovationDate = null)
        {
            var userId = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;

            return Ok(internshipService.RenoveInternship(id, int.Parse(userId), renovationDate));
        }
    }
}