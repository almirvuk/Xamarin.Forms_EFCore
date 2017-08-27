using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms_EFCore.DataAccess;
using Xamarin.Forms_EFCore.Helpers;
using Xamarin.Forms_EFCore.Models;
using Xamarin.Forms_EFCore.Views;

namespace Xamarin.Forms_EFCore.ViewModels {

    public class TeamListViewModel : BaseViewModel {

        private ObservableCollection<Team> allTeams;
        public ObservableCollection<Team> AllTeams {
            get { return allTeams; }
            set {
                allTeams = value;
            }
        }

        public ICommand AddTeamCommand { get; private set; }
        private DatabaseContext _context;

        public TeamListViewModel() {

            _context = new DatabaseContext();

            var teamList = _context.Teams.ToList();

            AllTeams = new ObservableCollection<Team>(teamList);

            AddTeamCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new AddTeamPage()));
        }
    }
}