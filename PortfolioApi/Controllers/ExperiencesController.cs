using System;
using System.Collections.Generic;
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
    [Route("[controller]/[action]")]
    public class ExperiencesController : ControllerBase
    {
        private readonly Client _client;

        public ExperiencesController(Client client)
        {
            _client = client;
        }

        // GET: Experiences
        [HttpGet]
        public async Task<IActionResult> GetExperiences()
        {
            try
            {
                var experiences = await _client.From<Experience>().Get();
                var cleanedList = experiences.Models.Select(e => new
                {
                    e.Id,
                    e.Name,
                    e.Description,
                    e.StartDate,
                    e.EndDate
                }).ToList();

                if (experiences == null)
                {
                    return NotFound();
                }

                return Ok(cleanedList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // Get experience
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExperienceById(int id)
        {
            try
            {
                var list = await _client.From<Experience>()
                    .Where(x => x.Id == id)
                    .Get();

                var cleanedList = list.Models.Select(e => new
                {
                    e.Id,
                    e.Name,
                    e.Description,
                    e.StartDate,
                    e.EndDate
                }).ToList();

                return Ok(cleanedList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Experiences/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertExperience([Bind("Id,Name,Description,StartDate,EndDate")] Experience experience)
        {
            if (experience == null)
            {
                return BadRequest("Experience is null.");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _client.From<Experience>().Insert(experience);
                    return Ok(nameof(result));
                }
                return Ok(experience);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: Experiences/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateExperience([Bind("Id,Name,Description,StartDate,EndDate")] Experience experience)
        {
            if (experience is null)
            {
                return NotFound();
            }

            try
            {
                var exp = await _client.From<Experience>()
                    .Where(e => e.Id == experience.Id)
                    .Single();

                if (exp == null)
                    return BadRequest("The experience does not exist.");

                exp.EndDate = experience.EndDate;
                exp.Description = experience.Description;

                return Ok(experience);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: Experiences/Delete/5
        [HttpDelete]
        public async Task<IActionResult> DeleteExperience(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {                
                var experience = await _client.From<Experience>()
                    .Where(e => e.Id == id)
                    .Single();

                if (experience == null)
                {
                    return NotFound();
                }

                var result = await _client.From<Experience>().Delete(experience);

                return Ok(experience);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
