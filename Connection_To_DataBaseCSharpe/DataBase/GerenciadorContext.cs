using Connection_To_DataBaseCSharpe.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Connection_To_DataBaseCSharpe.DataBase
{
    internal class GerenciadorContext: DbContext
    {                                     
        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Contas> Contas { get; set; }

        private string connectionString = "Server=DESKTOP-KM1NEG8;Database=TestConnectionToDataBaseV10;User Id=sa;Password=123456;TrustServerCertificate=True;\r\n";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contas>().HasKey(c => c.IdConta);

            modelBuilder.Entity<Contas>().Property(c => c.Saldo).HasPrecision(18,2); 
        }
    }
}
