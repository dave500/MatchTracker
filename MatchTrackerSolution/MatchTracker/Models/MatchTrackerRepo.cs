using Caliburn.Micro;
using MatchTrackerDAL;
using MatchTrackerLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTracker.Models
{
    public class MatchTrackerRepo : IMatchTrackerRepo
    {
        private DALManager dataMgr = new DALManager();

        public List<Competition> GetCompetitions()
        {
          
            List<Competition> competitionList;
            return competitionList = dataMgr.CurrentCompetitions();  
        }


        public List<Match> GetMatchesForCompetition(int code)
        {

            List<Match> competitionList;
            return competitionList = dataMgr.GetMatchesForCompetition(code);
        }

        public void UpdateMatches(List<Match> matches)
        {
            dataMgr.UpdateMatches(matches);
        }

        


    }
}
