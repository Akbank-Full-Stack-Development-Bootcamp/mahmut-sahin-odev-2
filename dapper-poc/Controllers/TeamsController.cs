using dapper_poc.Models;
using dapper_poc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace dapper_poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private ITeamService service;

        public TeamsController(ITeamService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allTeams = service.GetAllTeams();
            return Ok(allTeams);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var team = service.GetById(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOneEntity(int id)
        {
            bool isChanged = service.UpdateOneTeam(id);
            if (isChanged == false)
            {
                return BadRequest("Takım bulunamadı!");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult InsertOneEntity(Team newTeam)
        {
            service.AddOneTeam(newTeam);
            return Created($"/api/{newTeam.Id}", newTeam);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOneEntity(int id)
        {
            bool isDeleted = service.DeleteTeam(id);
            if (isDeleted == false)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}