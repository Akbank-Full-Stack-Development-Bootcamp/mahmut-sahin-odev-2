using dapper_poc.Models;
using System.Collections.Generic;

namespace dapper_poc.Services
{
    public interface ITeamService
    {
        IList<Team> GetAllTeams();

        Team GetById(int id);

        bool UpdateOneTeam(int id);

        void AddOneTeam(Team newTeam);

        bool DeleteTeam(int id);
    }
}