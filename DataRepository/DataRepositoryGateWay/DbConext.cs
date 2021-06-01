using DataRepository.DataRepositoryEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DataRepository.GateWay
{
    public class DbConext:DbContext
    {
        private static DbConext dbConext;
        public DbConext()
        {
           

           

            
        }


        internal static DbConext GetContextInstance()
        {
            if (dbConext == null)
            {
                dbConext = new DbConext();
            }
            return dbConext;
        }
        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            AppConfiguration configuration = new AppConfiguration();

          
            string conn = configuration.ConnectionString;

            optionsBuilder.UseSqlServer(conn);
         
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.Entity<User>().HasKey(o => o.Id);
            modelBuilder.Entity<PasswordComplexityRule>().HasKey(o => o.Id);
          

        }
    
    




        public  DbSet<PasswordComplexityRule> PasswordComplexityRule { get; set; }

        public DbSet<User> Users { get; set; }

     


    }
}
