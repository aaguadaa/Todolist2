using Business.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebAPI.Controllers
{
    [RoutePrefix("task")]
    public class TaskController : ApiController
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {

            _taskService = taskService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Task tsk)
        {
            if (tsk == null) return BadRequest("Request is null");
            int id = _taskService.Add(tsk);
            if (id < 0) return BadRequest("Unable to Create Task");
            var payload = new {Id=id};
            return Ok(tsk);



        }


        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Task tsk = _taskService.Get(id);
            if (tsk == null) return NotFound();
            return Ok(tsk);

        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] Task tsk)
        {
            if (tsk == null) return BadRequest("Request is null");
            tsk.Id = id;
            bool updated = _taskService.Update(tsk);
            if (!updated) return BadRequest("Unable to update Task");
            return Ok(tsk);



        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            bool deleted = _taskService.Delete(id);
            if (!deleted) return NotFound();
            return Ok(deleted);

        }
    }
}