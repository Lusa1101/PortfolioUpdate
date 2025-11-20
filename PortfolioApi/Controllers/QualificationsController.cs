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
    [Route("[controller]/[action]")]
    public class QualificationsController : ControllerBase
    {
        private readonly Client _client;

        public QualificationsController(Client client)
        {
            _client = client;
        }

        // GET: Qualifications
        [HttpGet]
        public async Task<IActionResult> GetQualifications()
        {
            try
            {
                var list = await _client.From<Qualification>().Get();
                return Ok(list.Models);
            }
            catch ( Exception ex)
            {
                Debug.WriteLine($"Error while getting qualifications {ex.GetType}: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        // GET: Qualifications/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQualificationById(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var qualification = await _client.From<Qualification>()
                    .Where(m => m.Id == id)
                    .Single();

                if (qualification == null)
                {
                    return NotFound();
                }

                return Ok(qualification);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error while getting qualification {ex.GetType}: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        // GET: Qualifications/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertQualification([Bind("Id,Name,Description,StartDate,EndDate")] Qualification qualification)
        {
            // Check the qualification
            if (qualification == null)
                return BadRequest("Invalid qualification data.");

            try
            {
                var result = await _client.From<Qualification>().Insert(qualification);

                return Ok(qualification);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error while inserting qualification {ex.GetType}: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        // GET: Qualifications/Edit/5
        [HttpPut]
        public async Task<IActionResult> UpdateQualification(Qualification qualification)
        {
            if (qualification.Id < 0)
            {
                return NotFound();
            }

            try
            {
                var qual = await _client.From<Qualification>()
                    .Where(x => x.Id == qualification.Id)
                    .Single();

                if (qual == null)
                {
                    return NotFound();
                }
                return Ok(qualification);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error while updating qualification: ", ex.Message);
                return BadRequest(ex.Message);
            }

        }

        // GET: Qualifications/Delete/5
        [HttpDelete]
        public async Task<IActionResult> DeleteQualification(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var qualification = await _client.From<Qualification>()
                    .Where(m => m.Id == id)
                    .Single();

                if (qualification == null)
                    return NotFound();

                await _client.From<Qualification>().Delete(qualification);

                return Ok(qualification);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error while deleting qualification {ex.GetType}: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
