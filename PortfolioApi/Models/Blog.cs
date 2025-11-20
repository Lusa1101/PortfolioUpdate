using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    [Table("blog")]
    public class Blog : BaseModel
    {
        [PrimaryKey("id")]
        [Key]
        public int Id { get; set; }

        [Column("heading")]
        public string Heading { get; set; } = string.Empty;

        [Column("subheading")]
        public string SubHeading { get; set; } = string.Empty;

        [Column("body")]
        public string Body { get; set; } = string.Empty;

        [Column("consclusion")]
        public string Conclusion { get; set; } = string.Empty;

        [Column("date_created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
