using System.ComponentModel.DataAnnotations;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Portfolio.Models
{
    [Table("project")]
    public class Project : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        [Required (ErrorMessage = "Required")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;

        [Column ("start_date")]
        public DateTime StartDate { get; set; }
        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Column("technology_stack")]
        [Required (ErrorMessage = "Required")]
        public string TechnologyStack { get; set; } = string.Empty;

        [Column("github_url")]
        [Url]
        public string GithubUrl { get; set; } = string.Empty;
    }



    [Table("project_image")]
    public class ProjectImage : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column ("project_id")]
        public int ProjectId { get; set; }

        [Column("file")]
        public string File { get; set; } = string.Empty;
    }

    public class Techology
    {
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; } = 1;
    }
}
