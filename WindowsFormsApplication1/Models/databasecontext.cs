

namespace Models
{
    class DatabaseContext :System.Data.Entity.DbContext
    {
        public DatabaseContext()
        {

        }
        public System.Data.Entity.DbSet<user> users { get; set; }
    }
}
