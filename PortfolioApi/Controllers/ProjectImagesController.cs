using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Supabase;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class ProjectImagesController : ControllerBase
    {
        private readonly Client _client;

        public ProjectImagesController(Client client)
        {
            _client = client;
        }

        // GET: ProjectImages
        [HttpGet]
        public async Task<IActionResult> GetProjectImages()
        {
            try
            {
                //var list = await _client.Storage.From("project-images").List();

                //Debug.WriteLine("Images");

                //List<ProjectImage> images = new();
                //if (list is null) return NoContent();
                //for (int i = 0; i < list.Count; i++)
                //{
                //    images[i].File = _client.Storage.From("project-images").GetPublicUrl($"public/{list[i].Name}");

                //    Console.WriteLine("Image:" + list[i].Name);
                //}

                var images = await _client.From<ProjectImage>()
                    .Get();

                var cleanedList = images.Models
                    .Select(x => new
                    {
                        x.Id,
                        x.ProjectId,
                        x.File
                    }).ToList();                    

                if (cleanedList.Count == 0)
                    return NoContent();


                return Ok(cleanedList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while getting project images: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        //
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectImagesById(int? id)
        {
            if (id < 0 || id is null)
                return BadRequest("Invalid project id");

            try
            {
                var result = await _client.From<ProjectImage>()
                    .Where(pi => pi.ProjectId == id)
                    .Get();

                var cleanedList = result.Models
                    .Select(pi => new
                    {
                        pi.Id,
                        pi.ProjectId,
                        pi.File
                    });

                if (result is null || result.Models.Count == 0)
                    return NotFound("No images found for the specified project id");

                return Ok(cleanedList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while getting project images by id: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        // GET: ProjectImages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertProjectImage([Bind("Id,ProjectId,Image")] ProjectImage projectImage)
        {
            try
            {
                if (projectImage.File == null)
                    return NotFound();

                var imagePath = projectImage.File;
                projectImage.File = imagePath;

                if (ModelState.IsValid)
                {
                    //Add to the bucket first
                    string result = await _client.Storage
                      .From("project-images")
                      .Upload(projectImage.File, projectImage.File);

                    //On success, add metadata to the db
                    await _client.From<ProjectImage>().Insert(projectImage);

                    return RedirectToAction(nameof(Index));
                }

                return Ok(projectImage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while inserting project image: ", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        //file picker
        public async Task Picker()
        {
            await Task.Delay(100000);
        }

        // GET: ProjectImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id == null)
            {
                return NotFound();
            }

            string projectImages = "";//await _context.ProjectImages.FindAsync(id);
            if (projectImages == null)
            {
                await Task.Delay(10);
                return NotFound();
            }
            return View(projectImages);*/
        }

        // POST: ProjectImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectId,File")] ProjectImage projectImages)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id != projectImages.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(projectImages);
                    //await _context.SaveChangesAsync();
                    await Task.Delay(10);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var check = ProjectImagesExists(projectImages.Id).Result;
                    if (!check)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(projectImages);*/
        }

        // GET: ProjectImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id == null)
            {
                return NotFound();
            }

            var projectImages = await _client.Storage.From("project-images").List();
            if(projectImages == null)
                return NotFound();
            var image = projectImages.Find(i => i.Id == id.ToString());
            if (projectImages == null)
            {
                return NotFound();
            }

            return View(projectImages);*/
        }

        // POST: ProjectImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            var projectImages = await _client.From<ProjectImage>().Get();
            var image = projectImages.Models.FirstOrDefault(i => i.Id == id);
            if (projectImages != null)
            {
                if (image != null && image.File != null)
                {
                    //Delete in the bucket first
                    await _client.Storage.From("project-images").Remove(image.File);

                    //Now delete in the db
                    await _client.From<ProjectImage>().Delete(image);
                }


            }

            return RedirectToAction(nameof(Index));*/
        }

        private async Task<bool> ProjectImagesExists(int id)
        {
            await Task.Delay(100000);
            return false;
            /*
            var list = await _client.Storage.From("project-images").List();

            if (list == null)
                return false;
            return list.Any(e => e.Id == id.ToString());*/
        }
    }
}
