using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Utn.PWA.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Utn.PWA.Api.Controllers
{
    public class Person
    {
        public String Name { get; set; }
        public DateTime DOB { get; set; }
        public String Email { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        IEnumerable<Person> persons = new List<Person>() {
            new Person() { Name = "Nancy Davolio", DOB = DateTime.Parse("1948-12-08"), Email = "nancy.davolio@test.com" },
            new Person() { Name = "Andrew Fuller", DOB = DateTime.Parse("1952-02-19"), Email = "andrew.fuller@test.com" },
            new Person() { Name = "Janet Leverling", DOB = DateTime.Parse("1963-08-30"), Email = "janet.leverling@test.com" },
            new Person() { Name = "Margaret Peacock", DOB = DateTime.Parse("1937-09-19"), Email = "margaret.peacock@test.com" },
            new Person() { Name = "Steven Buchanan", DOB = DateTime.Parse("1955-03-04"), Email = "steven.buchanan@test.com" },
            new Person() { Name = "Michael Suyama", DOB = DateTime.Parse("1963-07-02"), Email = "michael.suyama@test.com" },
            new Person() { Name = "Robert King", DOB = DateTime.Parse("1960-05-29"), Email = "robert.king@test.com" },
            new Person() { Name = "Laura Callahan", DOB = DateTime.Parse("1958-01-09"), Email = "laura.callahan@test.com" },
            new Person() { Name = "Anne Dodsworth", DOB = DateTime.Parse("1966-01-27"), Email = "anne.dodsworth@test.com" }
            };

        // GET api/values  
        [HttpGet]
        public ActionResult<PagedCollectionResponse<Person>> Get([FromQuery] FilterBasic filter)
        {

            //Filtering logic  
            Func<FilterBasic, IEnumerable<Person>> filterData = (filterModel) =>
            {
                return persons.Where(p => p.Name.StartsWith(filterModel.Term ?? String.Empty, StringComparison.InvariantCultureIgnoreCase))
                .Skip((filterModel.Page - 1) * filter.Limit)
                .Take(filterModel.Limit);
            };

            //Get the data for the current page  
            var result = new PagedCollectionResponse<Person>
            {
                Items = filterData(filter)
            };

            //Get next page URL string  
            FilterBasic nextFilter = filter.Clone() as FilterBasic;
            nextFilter.Page += 1;
            String nextUrl = filterData(nextFilter).Count() <= 0 ? null : this.Url.Action("Get", null, nextFilter, Request.Scheme);

            //Get previous page URL string  
            FilterBasic previousFilter = filter.Clone() as FilterBasic;
            previousFilter.Page -= 1;
            String previousUrl = previousFilter.Page <= 0 ? null : this.Url.Action("Get", null, previousFilter, Request.Scheme);

            result.NextPage = !String.IsNullOrWhiteSpace(nextUrl) ? new Uri(nextUrl) : null;
            result.PreviousPage = !String.IsNullOrWhiteSpace(previousUrl) ? new Uri(previousUrl) : null;

            return result;

        }
    }
}
