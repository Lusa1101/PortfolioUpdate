using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    [Table("qualification")]
    public class Qualification : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Required (ErrorMessage = "Required")]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        [Required(ErrorMessage = "Requied")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;

        [Column("start_date")]
        [Required (ErrorMessage = "Required")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        [Required(ErrorMessage = "Required")]
        public DateTime EndDate { get; set; }
    }
}
