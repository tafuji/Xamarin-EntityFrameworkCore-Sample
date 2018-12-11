using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XamarinEFCoreSample.Models
{
    [Table("item")]
    public class Item
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }
        [Column("text")]
        public string Text { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}