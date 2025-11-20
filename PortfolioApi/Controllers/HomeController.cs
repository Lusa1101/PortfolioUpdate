using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Supabase;

namespace Portfolio.Controllers;

[ApiController]
[Route("[Controller]/[action]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly Client _client;

    // Statics for Supabase operator
    public static Supabase.Postgrest.QueryOptions QueryOptions = new()
    { 
        Returning = Supabase.Postgrest.QueryOptions.ReturnType.Representation 
    };
    //static Supabase.Postgrest.Constants.Operator.Equals Operator;

    //To get the tech stack
    private List<Project> Projects { get; set; } = new();
    [BindProperty]
    public List<string> TechStack { get; set; } = new();

    public HomeController(ILogger<HomeController> logger, Client client)
    {
        _logger = logger;
        _client = client;
    }

    // Get projects
    [HttpGet]
    private async Task<IActionResult> GetProjects()
    {
        try
        {
            var list = await _client.From<Project>().Get();
            Projects = list.Models;

            //Extrect the tech stact from the projects
            foreach (var project in Projects)
            {
                var cuurentStack = project.TechnologyStack.Split(", ");
                for (int i = 0; i < cuurentStack.Length; i++)
                {
                    //Add to @TechStack if does not yet added
                    if (!TechStack.Contains(cuurentStack[i]))
                        TechStack.Add(cuurentStack[i]);
                }
            }

            return Ok(new {Projects = list.Models, TechStack = TechStack});
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error while getting projects: {ex.Message}");
            return StatusCode(500, $"Internal server error while getting projects: {ex.Message}");
        }
    }

    // Get project
    [HttpGet]
    private async Task<IActionResult> GetProject(int id)
    {
        try
        {
            Project? project = await _client.From<Project>()
                .Select("*")
                .Filter("id", Supabase.Postgrest.Constants.Operator.Equals, id)
                .Single();

            // Checks 
            if(project is null)
                return NotFound();

            //Extrect the tech stact from the projects
            var cuurentStack = project.TechnologyStack.Trim().Split(",");
            string[] techStack = new string[cuurentStack.Length];

            for (int i = 0; i < cuurentStack.Length; i++)
            {
                //Add to @TechStack if does not yet added
                if (!techStack.Contains(cuurentStack[i]))
                    techStack.Append(cuurentStack[i]);
            }

            return Ok(new { Project =  project, TechStack = techStack});
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error while getting project: {ex.Message}");
            return StatusCode(500, $"Internal server error while getting project: {ex.Message}");
        }
    }

    // Post project
    [HttpPost]
    public async Task<IActionResult> InsertProject(Project project)
    {
        try
        {
            // Check if project is valid
            if (project is null)
                return BadRequest();

            // Continue posting the job
            var result = await _client.From<Project>()
                .Insert(project, QueryOptions);

            return Ok(result.Content);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error while inserting project: {ex.Message}");
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // Updating a project
    [HttpPut]
    public async Task<IActionResult> UpdateProject(Project project)
    {
        try
        {
            // Verify project exists
            var tempProject = await _client.From<Project>()
                .Where(x => x.Id == project.Id)
                .Single();

            if (tempProject is null)
            {
                Debug.WriteLine("When updating project: Not found!");
                return BadRequest();
            }

            tempProject.Name = project.Name;
            tempProject.Description = project.Description;
            tempProject.EndDate = project.EndDate;

            // Update the projecr
            var result = await tempProject.Update<Project>();

            return Ok(result);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error while updating project: {ex.Message}");
            return StatusCode(500, $"Internal server error while updating project: {ex.Message}");
        }
    }

    [HttpDelete]
    public Task<IActionResult> DeleteProject(int id)
    {
        throw new NotImplementedException();
    }
}
