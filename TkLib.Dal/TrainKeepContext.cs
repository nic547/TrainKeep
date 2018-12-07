using System;
using Microsoft.EntityFrameworkCore;
using TkLib.Dal.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Collections.Generic;

namespace TkLib.Dal
{
    public class TrainKeepContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=tk_testdb;Username=postgres;"); // TODO: Undo the const. connection string

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("items");
            modelBuilder.Entity<ItemModel>().ToTable("item_models");
            modelBuilder.Entity<Manufacturer>().ToTable("manufacturer");
        }

        public List<Item> Items { get; set; }
    }
}
