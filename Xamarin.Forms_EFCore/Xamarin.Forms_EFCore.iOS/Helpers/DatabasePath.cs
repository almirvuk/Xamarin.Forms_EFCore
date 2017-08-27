using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms_EFCore.iOS.Helpers;
using Xamarin.Forms_EFCore.Helpers;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePath))]
namespace Xamarin.Forms_EFCore.iOS.Helpers {

    public class DatabasePath : IDBPath {

        public string GetDbPath() {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "EFCoreDB.db");
        }
    }
}