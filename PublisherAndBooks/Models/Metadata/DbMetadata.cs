using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublisherAndBooks.Models.Metadata
{
    public partial class BookType
    {
        public int BookId { get; set; }
        [Required, StringLength(50)]
        public string Title { get; set; }
        [Required, StringLength(50)]
        public string Genre { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "Publish Date")]
        public System.DateTime Publish { get; set; }

        [Required, StringLength(150)]
        public string Picture { get; set; }
        [Required]
        public int PublisherID { get; set; }

        //public virtual Publisher Publisher { get; set; }
    }
    public class PublisherType
    {
        public int PublisherId { get; set; }
        [Required, StringLength(50), Display(Name = "Publisher Name")]
        public string PublisherName { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "Establish Date")]

        public System.DateTime Establish { get; set; }
    }
}