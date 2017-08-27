using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms_EFCore.DataAccess;
using Xamarin.Forms_EFCore.Helpers;

namespace Xamarin.Forms_EFCore.ViewModels {

    public class EditPlayerViewModel : BaseViewModel {

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

        private int _playerId;
        private DatabaseContext _context;

        public EditPlayerViewModel(int playerId) {

            _playerId = playerId;

            // usage of using with db context
            using (_context = new DatabaseContext()) {

                var players = _context.Players.ToList();

                var player = _context.Players.Include(x => x.Team).SingleOrDefault(x => x.PlayerId == _playerId);
                // player.Team = _context.Teams.Find(player.TeamId);

                TeamName = player.Team.Title;

                Name = player.Name;
                Position = player.Position;
                JerseyNumber = player.JerseyNumber.ToString();

                SavePlayerCommand = new Command(SavePlayer);
            }
        }

        void SavePlayer() {

            using (_context = new DatabaseContext()) {

                var player = _context.Players.Find(_playerId);

                player.Position = Position;
                player.Name = Name;
                player.JerseyNumber = Int32.Parse(JerseyNumber);

                _context.Players.Update(player);
                _context.SaveChanges();
            }
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
