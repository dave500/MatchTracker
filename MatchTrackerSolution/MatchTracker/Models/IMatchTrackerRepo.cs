using MatchTrackerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTracker.Models
{
    public interface IMatchTrackerRepo
    {
        List<Competition> GetCompetitions();

        List<Match> GetMatchesForCompetition(int code);

        void UpdateMatches(List<Match> matches);
    }
}
