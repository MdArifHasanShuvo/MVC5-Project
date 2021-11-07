//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PublisherAndBooks.Models
{
    using PublisherAndBooks.Models.Metadata;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(BookType))]
    public partial class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public System.DateTime Publish { get; set; }
        public string Picture { get; set; }
        public int PublisherID { get; set; }
    
        public virtual Publisher Publisher { get; set; }
    }
}