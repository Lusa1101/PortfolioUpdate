using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    [Table("reference")]
    public class Reference : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("names")]
        [Required (ErrorMessage = "Required")]
        [MaxLength (50)]
        [RegularExpression (@"^[a-zA-Z\s]+$", ErrorMessage = "Invalid. Letters only.")]
        public string Names { get; set; } = string.Empty;

        [Column("email")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email.")]
        public string Email { get; set; } = string.Empty;

        [Column("cell")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(50)]
        [RegularExpression(@"^\+?[0-9]\d{1,14}$", ErrorMessage = "Invalid cell.")]
        public string Cell { get; set; } = string.Empty;

        [Column("relation")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(50)]
        [RegularExpression(@"^[\w\s]+$", ErrorMessage = "Invalid.")]
        public string Relation { get; set; } = string.Empty;

        [Column("date_created")]
        public DateTime DateCreated { get; set; }
    }
}
