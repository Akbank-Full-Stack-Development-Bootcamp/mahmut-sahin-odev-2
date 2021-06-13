using Dapper.Contrib.Extensions;
using dapper_poc.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace dapper_poc.Services
{
    public class TeamService : ITeamService
    {
        private string connString;

        public TeamService(string connString)
        {
            this.connString = connString;
        }

        public void AddOneTeam(Team newTeam)
        {
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                long newGenreId = connection.Insert<Team>(newTeam);
            }
        }

        public bool DeleteTeam(int id)
        {
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var entityToDel = connection.Get<Team>(id);
                if (entityToDel == null)
                {
                    return false;
                }
                connection.Delete<Team>(entityToDel);
                return true;
            }
        }

        public IList<Team> GetAllTeams()
        {
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var allTeams = connection.GetAll<Team>().ToList();
                return allTeams;
            }
        }

        public Team GetById(int id)
        {
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var team = connection.Get<Team>(id);
                return team;
            }
        }

        public bool UpdateOneTeam(int id)
        {
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var entityToUpdate = connection.Get<Team>(id);
                if (entityToUpdate == null)
                {
                    return false;
                }
                entityToUpdate.Name = "San Antonio Spurs";
                connection.Update<Team>(entityToUpdate);
                return true;
            }
        }
    }
}