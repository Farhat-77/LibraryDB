using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDB
{
    public partial class Books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            this.BooksInLibrary = new HashSet<BooksInLibrary>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BooksInLibrary> BooksInLibrary { get; set; }
    }
}
