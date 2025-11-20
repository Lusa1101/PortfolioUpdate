using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Supabase;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class ResumeController : Controller
    {
        //Samples
        Resume resume = new();
        Resume resume1 = new();

        //Lists to get values from db
        List<Reference> References { get; set; } = new();
        List<Qualification> Qualifications { get; set; } = new();
        List<Experience> Experiences { get; set; } = new();
        List<Certification> Certifications { get; set; } = new();

        //Client instance
        private readonly Client _client;

        //The constructor
        public ResumeController(Client client)
        {
            _client = client;
        }

        // GET: ResumeController
        public async Task<IActionResult> Index()
        {
            //Get data from the db
            await GetData();

            //Set data
            Set();

            return View(resume);
        }

        private void Set()
        {
            resume = new Resume
            {
                Names = "Omphulusa",
                Initials = "O",
                Surname = "Mashau",
                Address = "Limpopo, South Africa",
                Cell = "0783887879",
                Email = "omphu.shau@outlook.com",
                Certifications = this.Certifications,
                Qualifications = this.Qualifications,
                Experiences = this.Experiences,
                References = this.References
            };

            resume1 = new Resume
            {
                Names = "Omphulusa",
                Surname = "Mashau",
                Address = "Johannesburg, South Africa",
                Email = "your.email@example.com",
                Cell = "+27 12 345 6789",
                Certifications = new List<Certification>
                {
                    new Certification
                    {
                        Id = 1,
                        Title = "Microsoft Certified: Azure Fundamentals",
                        Issuer = "Microsoft",
                        IssueDate = new DateTime(2024, 6, 15),
                        ExpiryDate = new DateTime(2027, 6, 15),
                        CredentialId = "AZF-123456",
                        VerificationLink = "https://www.microsoft.com/en-us/learning/certification.aspx"
                    },
                    new Certification
                    {
                        Id = 2,
                        Title = "AWS Certified Developer – Associate",
                        Issuer = "Amazon Web Services",
                        IssueDate = new DateTime(2023, 9, 10),
                        ExpiryDate = new DateTime(2026, 9, 10),
                        CredentialId = "AWS-987654",
                        VerificationLink = "https://aws.amazon.com/certification/certified-developer-associate/"
                    },
                    new Certification
                    {
                        Id = 3,
                        Title = "Google IT Support Professional Certificate",
                        Issuer = "Google",
                        IssueDate = new DateTime(2022, 5, 20),
                        ExpiryDate = null, // No expiry for this one
                        CredentialId = "GIT-20220520",
                        VerificationLink = "https://grow.google/certificates/it-support/"
                    }
                },
                Qualifications = new List<Qualification>
                {
                    new Qualification
                    {
                        Name = "BSc Computer Science (Honours)",
                        Description = "Specialized in AI and Robotics. Thesis on IoT Security.",
                        StartDate = new DateTime(2021, 1, 1),
                        EndDate = new DateTime(2024, 12, 31)
                    },
                    new Qualification 
                    { 
                        Name = "Honours in Computer Science", 
                        StartDate = new DateTime(2025, 1, 1), 
                        EndDate = new DateTime(2025, 12, 31) 
                    },
                    new Qualification 
                    { 
                        Name = "Bachelor of Sciences in Mathematical Sciences", 
                        StartDate = new DateTime(2022, 1, 1), 
                        EndDate = new DateTime(2024, 12, 31) 
                    }
                    // Add more qualifications
                },
                Experiences = new List<Experience>
                {
                    new Experience
                    {
                        Name = "Junior IoT Developer",
                        Description = "Developed embedded systems for smart home applications using Raspberry Pi and Arduino.",
                        StartDate = new DateTime(2023, 6, 1),
                        EndDate = new DateTime(2024, 5, 31)
                    },
                    new Experience 
                    { 
                        Name = "Student Assistant", 
                        Description = "Guided students with tutorials and technical issues.", 
                        StartDate = new DateTime(2024, 1, 1), 
                        EndDate = new DateTime(2024, 12, 31) 
                    },
                    new Experience 
                    { 
                        Name = "Student Mentor", 
                        Description = "Organized study sessions and assisted mentees.", 
                        StartDate = new DateTime(2023, 1, 1), 
                        EndDate = new DateTime(2023, 12, 31) 
                    }
                    // Add more experiences
                },
                References = new List<Reference>
                {
                    new Reference
                    {
                        Names = "Dr. Jane Smith",
                        Email = "j.smith@university.edu",
                        Cell = "+27 11 222 3333",
                        Relation = "Academic Supervisor"
                    },
                    // Add more references
                }
            };
        }

        private async Task GetData()
        {
            //Experiences
            var list = await _client.From<Experience>().Get();
            Experiences = list.Models;

            //References
            var list2 = await _client.From<Reference>().Get();
            References = list2.Models;

            //Qualifications
            var list3 = await _client.From<Qualification>().Get();
            Qualifications = list3.Models;

            //Certifications
            var list4 = await _client.From<Certification>().Get();
            Certifications = list4.Models;

            foreach(var item in Qualifications)
                Debug.WriteLine(item.Name);

            //Arrange the lists
            ArrangeLists();
        }

        private void ArrangeLists()
        {
            //Arrange the lists in a specific order if needed
            References = References.OrderBy(r => r.DateCreated).ToList();
            Qualifications = Qualifications.OrderByDescending(q => q.StartDate).ToList();
            Experiences = Experiences.OrderByDescending(e => e.StartDate).ToList();
            Certifications = Certifications.OrderByDescending(c => c.IssueDate).ToList();
        }

        // GET: ResumeController/Details/5
        public ActionResult Details(int id)
        {
            return NotFound();
        }

        // GET: ResumeController/Create
        public ActionResult Create()
        {
            return NotFound();
        }

        // POST: ResumeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return NotFound();
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: ResumeController/Edit/5
        public ActionResult Edit(int id)
        {
            return NotFound();
        }

        // POST: ResumeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return NotFound();
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: ResumeController/Delete/5
        public ActionResult Delete(int id)
        {
            return NotFound();
        }

        // POST: ResumeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            return NotFound();
        }
    }
}
