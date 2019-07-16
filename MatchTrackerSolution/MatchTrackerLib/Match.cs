using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTrackerLib
{
    public class Match
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime MatchDate { get; set; }
        public decimal HomeWin { get; set; }
        public decimal AwayWin { get; set; }
        public decimal Draw { get; set; }
        public string FracHome { get; set; }
        public string FracDraw { get; set; }
        public string FracAway { get; set; }
        public int CompetitionCode { get; set; }
        public bool HasComment { get; set; }
        public DateTime MatchKickOff { get; set; }
    }
}
