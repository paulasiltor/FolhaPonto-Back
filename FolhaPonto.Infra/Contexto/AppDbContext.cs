using FolhaPonto.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FolhaPonto.Infra.Contexto
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Collaborators> Collaborators { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TimeTrackers> TimeTrackers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FolhaPonto;Trusted_Connection=True;");
        }
    }
}