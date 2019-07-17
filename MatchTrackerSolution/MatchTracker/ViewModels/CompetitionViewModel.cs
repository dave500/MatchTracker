using Caliburn.Micro;
using MatchTracker.Helpers;
using MatchTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MatchTracker.ViewModels
{
    public class CompetitionViewModel : Screen
    {
        private readonly IMatchTrackerRepo _matchTrackerRepo;
        private readonly IWindowManager _windowManager;


        public CompetitionViewModel(IMatchTrackerRepo matchTrackerRepo, IWindowManager windowManager)
        {
            _matchTrackerRepo = matchTrackerRepo;
            _windowManager = windowManager;
            Competitions = CompetitionHelper.CurrentCompetitons(_matchTrackerRepo.GetCompetitions());

         }

        private BindableCollection<CompetitionModel> _competitions = new BindableCollection<CompetitionModel>();
        private String _title = "Match Checker";
        private String _compDDLabel = "Select Competition";

        public String Title {
            get { return _title; }
            set {_title = value; }
        }

        public String  CompDDLabel {
            get { return _compDDLabel; }
            set { _compDDLabel = value; }
        }

        public BindableCollection<CompetitionModel> Competitions
        {
            get { return _competitions; }
            set { _competitions = value; }
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

        public void LoadMatchDetails()
        {

            _windowManager.ShowWindow(new MatchViewModel(_matchTrackerRepo, _windowManager, SelectedCompetition));
            (GetView() as Window).Close();
        }


    }
}
