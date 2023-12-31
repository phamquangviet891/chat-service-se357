﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;

namespace chat_service_se357.Models
{
    public class DataContext: DbContext
    {
        public static Random random = new Random();
        public DbSet<SqlConversation>? conversations { get; set; }
        public DbSet<SqlMessage>? messages { get; set; }
        public DbSet<SqlUser>? users { get; set; }

        public static string randomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string configSql = "Host=ep-silent-hill-65750190.ap-southeast-1.postgres.vercel-storage.com:5432;Database=verceldb;Username=default;Password=8isowjIMlJG4";
        //public static string configSql = "Host=localhost:5434;Database=SE347;Username=postgres;Password=12345678";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(configSql);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
