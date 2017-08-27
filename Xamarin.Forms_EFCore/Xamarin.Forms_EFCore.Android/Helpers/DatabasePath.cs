using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms_EFCore.Helpers;
using System.IO;
using Xamarin.Forms_EFCore.Droid.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePath))]
namespace Xamarin.Forms_EFCore.Droid.Helpers {

    public class DatabasePath : IDBPath {

        public DatabasePath() {
        }

        public string GetDbPath() {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "EFCoreDB.db");
        }
    }
}