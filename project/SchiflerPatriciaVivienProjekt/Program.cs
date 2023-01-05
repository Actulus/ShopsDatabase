using Microsoft.EntityFrameworkCore;
using SchiflerPatriciaVivienProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchiflerPatriciaVivienProjekt
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


        public class LocationDbContext : DbContext
        {
            public DbSet<Location> Locations { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseOracle(@"User Id=C##Tavk7;password=DEF567mop;Data Source=217.73.170.84:44678/orcl;");
            }
        }
    }
}
