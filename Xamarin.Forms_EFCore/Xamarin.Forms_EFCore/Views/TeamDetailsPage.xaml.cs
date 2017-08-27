using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms_EFCore.Models;
using Xamarin.Forms_EFCore.ViewModels;

namespace Xamarin.Forms_EFCore.Views {

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamDetailsPage : ContentPage {

        private int teamId;

        public TeamDetailsPage(int teamId) {
            InitializeComponent();

            this.teamId = teamId;
        }

        protected override void OnAppearing() {
            base.OnAppearing();

            BindingContext = new TeamDetailsViewModel(teamId);
        }

        public async void OnPlayerTapped(object sender, ItemTappedEventArgs e) {

            if (e.Item  != null) {

                var player = (Player)e.Item;
                await Navigation.PushAsync(new EditPlayerPage(player.PlayerId));
            }
        }
    }
}