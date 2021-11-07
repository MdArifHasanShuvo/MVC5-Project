using PublisherAndBooks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublisherAndBooks.ViewModels
{
    public class BookViewModel
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
        public HttpPostedFileBase Picture { get; set; }
        [Required]
        public int PublisherID { get; set; }
        public virtual Publisher Publisher { get; set; }

    }
}