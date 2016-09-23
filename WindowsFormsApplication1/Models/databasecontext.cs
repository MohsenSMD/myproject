

namespace Models
{
    class databasecontext  :System.Data.Entity.DbContext
    {
        public databasecontext()
        {

        }

      public System.Data.Entity.DbSet<Person> people { get; set; }
    }
}
