using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    [Table("certification")]
    public class Certification : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("title")]
        [Required(ErrorMessage = "Certificate title is required")]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Column("description")]
        [Required(ErrorMessage = "Certificate title is required")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;

        [Column("issuer")]
        [Required(ErrorMessage = "Issuing organization is required")]
        [MaxLength(100)]
        public string Issuer { get; set; } = string.Empty;

        [Column("issue_date")]
        [Required(ErrorMessage = "Issue date is required")]
        public DateTime IssueDate { get; set; }

        [Column("expiry_date")]
        public DateTime? ExpiryDate { get; set; } // Nullable if no expiration

        [Column("credential_id")]
        [MaxLength(50)]
        public string CredentialId { get; set; } = string.Empty;

        [Column("verification_link")]
        [Url(ErrorMessage = "Invalid URL format")]
        public string VerificationLink { get; set; } = string.Empty;
    }

}
