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
    public partial class EditPlayerPage : ContentPage {

        private int playerId;

        public EditPlayerPage(int playerId) {
            InitializeComponent();

            this.playerId = playerId;
        }

        protected override void OnAppearing() {
            base.OnAppearing();

            BindingContext = new EditPlayerViewModel(playerId);
        }
    }
}