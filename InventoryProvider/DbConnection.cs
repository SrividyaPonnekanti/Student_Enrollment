using ModelLib;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DbContextLib
{
    public class DbConnection:DbContext
    {
        public DbConnection()
            : base("DefaultConnection")
        {

        }
        //public DbSet<InventoryItemDto> objInventoryDto { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Types().Configure(t => t.MapToStoredProcedures());
        }
        public class DbConnectionDBinitilizer:CreateDatabaseIfNotExists<DbConnection>
        {

        }

    }

}

