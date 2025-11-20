using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    [Table("experience")]
    public class Experience : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required (ErrorMessage = "Required")]
        [RegularExpression (@"^[a-zA-Z\s]+$", ErrorMessage = "Letters only.")]
        [MaxLength (50)]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        [Required (ErrorMessage = "Please enter a description.")]
        public string Description { get; set; } = string.Empty;

        [Column("start_date")]
        [Required(ErrorMessage = "Required")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        [Required(ErrorMessage = "Required")]
        public DateTime EndDate { get; set; }
    }
}
