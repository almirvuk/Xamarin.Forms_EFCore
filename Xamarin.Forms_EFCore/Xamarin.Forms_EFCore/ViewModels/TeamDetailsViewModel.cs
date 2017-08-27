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

    public class TeamDetailsViewModel : BaseViewModel {

        private string title;
        public string Title {
            get { return title; }
            set {
                title = value;
                OnPropertyChanged();
            }
        }

        private string manager;
        public string Manager {
            get { return manager; }
            set {
                manager = value;
                OnPropertyChanged();
            }
        }

        private string city;
        public string City {
            get { return city; }
            set {
                city = value;
                OnPropertyChanged();
            }
        }

        private string stadiumName;
        public string StadiumName {
            get { return stadiumName; }
            set {
                stadiumName = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Player> players;
        public ObservableCollection<Player> Players {
            get { return players; }
            set { players = value; }
        }

        public ICommand AddPlayerCommand { get; private set; }
        public ICommand EditTeamCommand { get; private set; }
        public ICommand DeleteTeamCommand { get; private set; }

        private DatabaseContext _context;

        private int _teamId;

        public TeamDetailsViewModel(int teamId) {

            _teamId = teamId;

            _context = new DatabaseContext();

            var team = _context.Teams.Find(teamId);

            // Setting property values from team object
            // that we get from database
            Title = team.Title;
            City = team.City;
            StadiumName = team.StadiumName;
            Manager = team.Manager;

            Players = new ObservableCollection<Player>(_context.Players.Where(p => p.TeamId == teamId));

            // Commands for toolbar items
            AddPlayerCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new AddPlayerPage(team.TeamId)));
            EditTeamCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new EditTeamPage(team.TeamId)));
            DeleteTeamCommand = new Command(DeleteTeam);

        }

        void DeleteTeam() {

            var team = _context.Teams.Find(_teamId);

            _context.Teams.Remove(team);
            _context.SaveChanges();

            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}