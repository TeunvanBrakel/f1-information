using f1_information_backend.Database;
using f1_information_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace f1_information_backend.Services
{
    public class TeamService
    {
        private readonly DbContext context;
        private List<Team> Teams { get; }
        public TeamService(DbContext dbContext)
        {
            context = dbContext;
            Team redbull = new Team("RedBull", 203, 543);
            Team mercedes = new Team("Mercedes", 403, 555);

            Teams = new List<Team>
            {
                redbull,
                mercedes,
            };
            Test();
        }
        private async void Test()
        {
            if (context.Teams.Count() < 2)
            {
                await Add(Teams[0]);
                await Add(Teams[1]);
            }
        }

        public List<Team> GetAll()
        {
            var result = context.Teams.ToList();
            return result;
        }

        public Team Get(int id)
        {
            var result = context.Teams.Find(id);
            return result;
        }

        public async Task Add(Team team)
        {
            context.Teams.Add(team);
            await context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var team = Get(id);
            if (team is null)
                return;

            context.Teams.Remove(team);
        }

        public void Update(Team team)
        {
            var index = Teams.FindIndex(p => p.Id == team.Id);
            if (index == -1)
                return;

            Teams[index] = team;
        }
    }
}
