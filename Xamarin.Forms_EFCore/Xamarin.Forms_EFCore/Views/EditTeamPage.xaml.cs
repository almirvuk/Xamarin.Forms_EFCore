using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms_EFCore.ViewModels;

namespace Xamarin.Forms_EFCore.Views {

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTeamPage : ContentPage {

        private int teamId;

        public EditTeamPage(int teamId) {
            InitializeComponent();

            this.teamId = teamId;
        }

        protected override void OnAppearing() {
            base.OnAppearing();

            BindingContext = new EditTeamViewModel(teamId);
        }
    }
}