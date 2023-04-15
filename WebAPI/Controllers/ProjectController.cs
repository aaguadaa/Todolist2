using Business.Contracts;
using Business.Implementation;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{

    [RoutePrefix("project")]
    public class ProjectController : ApiController
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {

            _projectService = projectService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Project proj)
        {
            if (proj == null) return BadRequest("Request is null");
            int id = _projectService.Add(proj);
            if (id < 0) return BadRequest("Unable to Create User");
            var payload = new { Id = id };
            return Ok(payload);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            bool deleted = _projectService.Delete(id);
            if (!deleted) return NotFound();
            return Ok();
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Project proj = _projectService.Get(id);
            if (proj == null) return NotFound();
            return Ok(proj);
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] Project proj)
        {
            if (proj == null) return BadRequest("Request is null");
            proj.Id = id;
            bool updated = _projectService.Update(proj);
            if (!updated) return BadRequest("Unable to update User");
            return Ok(proj);
        }

    }
}


