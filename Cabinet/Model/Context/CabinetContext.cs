using Cabinet.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Cabinet.Model.Context
{
    internal class CabinetContext : DbContext
    {
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Medic> Medic { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Operation> Operation { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-ND1IOQ4;Database=CabinetDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
