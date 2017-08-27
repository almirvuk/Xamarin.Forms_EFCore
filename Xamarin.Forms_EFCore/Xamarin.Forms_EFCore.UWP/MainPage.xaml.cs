using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Xamarin.Forms_EFCore.UWP {
    public sealed partial class MainPage {
        public MainPage() {
            this.InitializeComponent();

       //     LoadApplication(new Xamarin.Forms_EFCore.App(Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "EFCoreExample.db")));
        }
    }
}
