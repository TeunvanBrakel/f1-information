using f1_information_backend.Models;
using f1_information_backend.Services;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController
    {
        private readonly TeamService teamService;
        public TeamController(TeamService service)
        {
            teamService = service;
        }

        [HttpGet]
        public ActionResult<List<Team>> GetAll() =>
            teamService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Team> Get(int id)
        {
            var team = teamService.Get(id);

            if (team == null)
                return null;

            return team;
        }
        [HttpPost]
        public async void CreateTeam(Team team)
        {
            if (team != null)
            {
                await teamService.Add(team);
            }
        }
        // POST action

        [HttpPut("{id}")]
        public ActionResult Update(int id, Team team)
        {
            if (team.Id == id)
            {
                teamService.Update(team);
                return new OkResult();
            }
            return new BadRequestResult();
        }
        // PUT action

        // DELETE action
    }
 }
