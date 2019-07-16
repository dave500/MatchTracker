using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MatchTracker.Models;
using MatchTrackerLib;

namespace MatchTracker.Helpers
{
    public static class CompetitionHelper
    {
        internal static BindableCollection<CompetitionModel> CurrentCompetitons(List<Competition> competitions)
        {
            var Competitions = new BindableCollection<CompetitionModel>();

            foreach (var item in competitions)
            {
                Competitions.Add(new CompetitionModel { Id = item.Id, Code = item.Code, Name = item.Name });
            }

            return Competitions;
        }

        internal static BindableCollection<MatchModel> MatchConvertor(List<Match> matches)
        {
            var Matches = new BindableCollection<MatchModel>();

            foreach (var item in matches)
            {
                Matches.Add(new MatchModel { Id = item.Id, Name = item.Name, MatchDate = item.MatchDate});
            }

            return Matches;
        }

        internal static List<Match> MatchListConvertor(BindableCollection<MatchModel> matches)
        {
            var lMatches = new List<Match>();

            foreach (var item in matches)
            {
                lMatches.Add(new Match { Id = item.Id, Name = item.Name });
            }

            return lMatches;
        }
    }
}
