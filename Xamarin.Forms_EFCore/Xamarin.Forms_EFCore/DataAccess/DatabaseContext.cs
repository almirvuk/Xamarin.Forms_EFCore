using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms_EFCore.Helpers;
using Xamarin.Forms_EFCore.Models;

namespace Xamarin.Forms_EFCore.DataAccess {

    public class DatabaseContext : DbContext {

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        public DatabaseContext() {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            var dbPath = DependencyService.Get<IDBPath>().GetDbPath();
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
