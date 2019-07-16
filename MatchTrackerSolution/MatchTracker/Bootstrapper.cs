using Caliburn.Micro;
using MatchTracker.Models;
using MatchTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MatchTracker
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer container = new SimpleContainer();


        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()

        {

            container = new SimpleContainer();

            container.Singleton<IMatchTrackerRepo, MatchTrackerRepo>();
            container.Singleton<IEventAggregator, EventAggregator>();
            container.Singleton<IWindowManager, WindowManager>();



            container.PerRequest<CompetitionViewModel>();

        }



        protected override void OnStartup(object sender, StartupEventArgs e)

        {

            

            DisplayRootViewFor<CompetitionViewModel>();

        }



        protected override object GetInstance(Type service, string key)

        {

            return container.GetInstance(service, key);

        }



        protected override IEnumerable<object> GetAllInstances(Type service)

        {

            return container.GetAllInstances(service);

        }



        protected override void BuildUp(object instance)

        {
            container.BuildUp(instance);
        }
    }
}
