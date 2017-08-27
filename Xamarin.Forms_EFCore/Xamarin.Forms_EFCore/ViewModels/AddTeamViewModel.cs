using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms_EFCore.DataAccess;
using Xamarin.Forms_EFCore.Helpers;
using Xamarin.Forms_EFCore.Models;

namespace Xamarin.Forms_EFCore.ViewModels {

    public class AddTeamViewModel : BaseViewModel {

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
        private DatabaseContext _context;

        public AddTeamViewModel() {

            _context = new DatabaseContext();
            SaveTeamCommand = new Command(SaveTeam);
        }

        async void SaveTeam() {

            Team team = new Team {

                City = City,
                StadiumName = StadiumName,
                Title = Title,
                Manager = Manager
            };

            _context.Teams.Add(team);
            _context.SaveChanges();

            // After adding new entry to database close this page
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}