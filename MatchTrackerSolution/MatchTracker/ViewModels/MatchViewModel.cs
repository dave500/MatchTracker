using Caliburn.Micro;
using MatchTracker.Helpers;
using MatchTracker.Models;
using MatchTrackerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MatchTracker.ViewModels
{
    public class MatchViewModel : Screen
    {
        private readonly IMatchTrackerRepo _matchTrackerRepo;
        private readonly IWindowManager _windowManager;


        public MatchViewModel(IMatchTrackerRepo matchTrackerRepo, IWindowManager windowManager, CompetitionModel selectedCompetition)
        {
            _matchTrackerRepo = matchTrackerRepo;
            _windowManager = windowManager;
            Matches = CompetitionHelper.MatchConvertor(_matchTrackerRepo.GetMatchesForCompetition(selectedCompetition.Code));
        }

        private CompetitionModel _selectedCompetition;
        public CompetitionModel SelectedCompetition
        {
            get { return _selectedCompetition; }
            set
            {
                _selectedCompetition = value;
                NotifyOfPropertyChange(() => SelectedCompetition);
            }
        }


        private BindableCollection<MatchModel> _matches = new BindableCollection<MatchModel>();
        public BindableCollection<MatchModel> Matches
        {
            get { return _matches; }
            set
            {
                _matches = value;
                NotifyOfPropertyChange(() => Matches);
            }
        }

        private String _title = "Match Data Update";
        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public void UpdateMatches()
        {
            List<Match> lMatches = CompetitionHelper.MatchListConvertor(Matches);
            _matchTrackerRepo.UpdateMatches(lMatches);
        }

        public void BackToCompetitions()
        {

            _windowManager.ShowWindow(new CompetitionViewModel(_matchTrackerRepo, _windowManager));
            (GetView() as Window).Close();
        }
    }
}
