namespace Portfolio.Models
{
    public class Resume
    {
        public string Names { get; set; } = string.Empty;
        public string Initials {  get; set; } = string.Empty;
        public string Surname {  get; set; } = string.Empty;
        public string Address {  get; set; } = string.Empty;
        public List<Qualification> Qualifications { get; set; } = new();
        public List<Experience> Experiences {  get; set; } = new();
        public string Cell {  get; set; } = "0783887879";
        public string Email {  get; set; } = "omphu.shau@outlook.com";
        public string LinkedIn { get; set; } = "https://www.linkedin.com/in/omphulusa-mashau/";
        public List<Certification> Certifications { get; set; } = new();
        public List<Reference> References { get; set; } = new();
    }
    
}
