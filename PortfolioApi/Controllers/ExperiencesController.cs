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
    public class ExperiencesController : Controller
    {
        private readonly Client _client;

        public ExperiencesController(Client client)
        {
            _client = client;
        }

        // GET: Experiences
        public async Task<IActionResult> Index()
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            var list = await _client.From<Experience>().Get();
            return View(list.Models);*/
        }

        // GET: Experiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*if (id == null)
            {
                return NotFound();
            }

            var experiences = await _client.From<Experience>().Get();
            var experience = experiences.Models.FirstOrDefault(m => m.Id == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);*/
        }

        // GET: Experiences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Experiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,StartDate,EndDate")] Experience experience)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (ModelState.IsValid)
            {
                await _client.From<Experience>().Insert(experience);
                return RedirectToAction(nameof(Index));
            }
            return View(experience);*/
        }

        // GET: Experiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id == null)
            {
                return NotFound();
            }

            var experiences = await _client.From<Experience>().Get();
            var experience = experiences.Models.FirstOrDefault(m => m.Id == id);
            if (experience == null)
            {
                return NotFound();
            }
            return View(experience);
            */
        }

        // POST: Experiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,StartDate,EndDate")] Experience experience)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id != experience.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _client.From<Experience>().Update(experience);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienceExists(experience.Id))
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
            return View(experience);*/
        }

        // GET: Experiences/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {                
                var experiences = await _client.From<Experience>().Get();
                var experience = experiences.Models.FirstOrDefault(m => m.Id == id);
                if (experience == null)
                {
                    return NotFound();
                }

                return Ok(experience);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
