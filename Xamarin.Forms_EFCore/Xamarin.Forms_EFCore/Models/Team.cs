using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms_EFCore.Models {

    public class Team {

        public int TeamId { get; set; }

        public string Title { get; set; }

        public string Manager { get; set; }
        public string City { get; set; }

        public string StadiumName { get; set; }
    }
}
