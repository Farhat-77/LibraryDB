using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace LibraryDB
{
    public partial class BestLibraryEntities : DbContext
    {
        public BestLibraryEntities()
            : base("name=BestLibraryEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<BooksInLibrary> BooksInLibrary { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
    }
}