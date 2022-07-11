using System;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using WhaleExtApi.Models.Database;

namespace WhaleExtApi.Database
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Species> Species { get; set; }
        public DbSet<Sighting> Sightings { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder
        )
        {
            optionsBuilder.UseNpgsql(GetConnectionString());
        }

        private static string GetConnectionString()
        {
            var databaseUrl =
                Environment.GetEnvironmentVariable("DATABASE_URL");
            if (databaseUrl == null)
            {
                throw new Exception("Environment variable 'DATABASE_URL' must not be null");
            }

            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');

            var builder =
                new NpgsqlConnectionStringBuilder
                {
                    Host = databaseUri.Host,
                    Port = databaseUri.Port,
                    Username = userInfo[0],
                    Password = userInfo[1],
                    Database = databaseUri.LocalPath.TrimStart('/')
                };

            return builder.ToString();
        }
    }
}
