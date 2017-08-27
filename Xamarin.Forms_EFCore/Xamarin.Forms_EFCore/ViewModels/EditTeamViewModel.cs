using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms_EFCore.DataAccess;
using Xamarin.Forms_EFCore.Helpers;

namespace Xamarin.Forms_EFCore.ViewModels {

    public class EditTeamViewModel : BaseViewModel {

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

        public ICommand SaveTeamCommand { get; private set; }

        private int _teamId;
        private DatabaseContext _context;

        public EditTeamViewModel(int teamId) {

            _context = new DatabaseContext();

            var team = _context.Teams.Find(teamId);
            _teamId = team.TeamId;

            Title = team.Title;
            Manager = team.Manager;
            StadiumName = team.StadiumName;
            City = team.City;

            SaveTeamCommand = new Command(SaveTeam);
        }

        async void SaveTeam() {

            var team = _context.Teams.Find(_teamId);

            team.Title = Title;
            team.Manager = Manager;
            team.StadiumName = StadiumName;
            team.City = City;

            // Other approach
            // _context.Entry(team).State = EntityState.Modified; 

            _context.Teams.Update(team);
            _context.SaveChanges();

            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}