using System;
using Microsoft.EntityFrameworkCore;
using TkLib.Dal.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Collections.Generic;

namespace TkLib.Dal
{
    public class TrainKeepContext: DbContext
    {
        static public string Hostname { get; set; }
        static public string DatabaseName { get; set; }
        static public string Username { get; set; }
        static public string Password { get; set; }


        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql($"Host={Hostname};Database={DatabaseName};Username={Username};");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("items");
            modelBuilder.Entity<ItemModel>().ToTable("item_models");
            modelBuilder.Entity<Manufacturer>().ToTable("manufacturer");
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemModel> Models { get; set; }
        public DbSet<Prototype> Prototypes { get; set; }
    }
}
