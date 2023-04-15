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

    [RoutePrefix("role")]
    public class RoleController : ApiController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {

            _roleService = roleService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Role rol)
        {
            if (rol == null) return BadRequest("Request is null");
            int id = _roleService.Add(rol);
            if (id < 0) return BadRequest("Unable to Create User");
            var payload = new { Id = id };
            return Ok(payload);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            bool deleted = _roleService.Delete(id);
            if (!deleted) return NotFound();
            return Ok();
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Role rol = _roleService.Get(id);
            if (rol == null) return NotFound();
            return Ok(rol);
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] Role rol)
        {
            if (rol == null) return BadRequest("Request is null");
            rol.Id = id;
            bool updated = _roleService.Update(rol);
            if (!updated) return BadRequest("Unable to update User");
            return Ok(rol);
        }

    }
}


