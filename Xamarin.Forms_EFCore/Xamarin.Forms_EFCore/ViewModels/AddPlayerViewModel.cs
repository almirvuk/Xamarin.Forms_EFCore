using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms_EFCore.DataAccess;
using Xamarin.Forms_EFCore.Helpers;
using Xamarin.Forms_EFCore.Models;

namespace Xamarin.Forms_EFCore.ViewModels {

    public class AddPlayerViewModel : BaseViewModel {

        private string teamName;
        public string TeamName {
            get { return teamName; }
            set {
                teamName = value;
                OnPropertyChanged();
            }
        }

        private string name;
        public string Name {
            get { return name; }
            set {
                name = value;
                OnPropertyChanged();
            }
        }

        private string position;
        public string Position {
            get { return position; }
            set {
                position = value;
                OnPropertyChanged();
            }
        }

        private string jerseyNumber;
        public string JerseyNumber {
            get { return jerseyNumber; }
            set {
                jerseyNumber = value;
                OnPropertyChanged();
            }
        }

        public ICommand SavePlayerCommand { get; private set; }

        private int _teamId;
        private DatabaseContext _context;

        public AddPlayerViewModel(int teamId) {

            _teamId = teamId;
            _context = new DatabaseContext();

            var team = _context.Teams.Where(t => t.TeamId == teamId).FirstOrDefault();

            TeamName = team.Title;

            SavePlayerCommand = new Command(SavePlayer);
        }

        void SavePlayer() {

            var team = _context.Teams.Where(t => t.TeamId == _teamId).FirstOrDefault();

            Player player = new Player() {

                JerseyNumber = Int32.Parse(JerseyNumber),
                Name = Name,
                Position = Position,
                TeamId = _teamId
            };

            _context.Players.Add(player);
            _context.SaveChanges();

            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}