using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    [Table("contact")]
    public class Contact : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("names")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression (@"^[a-zA-Z\s]+$", ErrorMessage = "Invalid. Please use only letters")]
        [MaxLength(50)]
        public string Names { get; set; } = string.Empty;

        [Column("email")]
        [Required(ErrorMessage = "Requied")]
        [RegularExpression (@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; } = string.Empty;

        [Column("cell")]
        [RegularExpression(@"^\+?[0-9]\d{1,14}$", ErrorMessage = "Please enter a valid phone number")]
        public string Phone { get; set; } = string.Empty;

        [Column("message")]
        [Required(ErrorMessage = "Please write your message here.")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; } = string.Empty;

        [Column("date_created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
