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
    public class ReferencesController : Controller
    {
        private readonly Client _client;

        public ReferencesController(Client client)
        {
            _client = client;
        }

        // GET: References
        public async Task<IActionResult> Index()
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            var list = await _client.From<Reference>().Get();
            return View(list.Models);*/
        }

        // GET: References/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id == null)
            {
                return NotFound();
            }

            var list = await _client.From<Reference>().Get();
            var reference = list.Models.FirstOrDefault(m => m.Id == id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);*/
        }

        // GET: References/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: References/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Names,Email,Cell,Relation,DateCreated")] Reference reference)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (ModelState.IsValid)
            {
                await _client.From<Reference>().Insert(reference);

                return RedirectToAction(nameof(Index));
            }
            return View(reference);*/
        }

        // GET: References/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id == null)
            {
                return NotFound();
            }

            var list = await _client.From<Reference>().Get();
            var reference = list.Models.FirstOrDefault(m => m.Id == id);
            if (reference == null)
            {
                return NotFound();
            }
            return View(reference);*/
        }

        // POST: References/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Names,Email,Cell,Relation,DateCreated")] Reference reference)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id != reference.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _client.From<Reference>().Update(reference);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferenceExists(reference.Id))
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
            return View(reference);*/
        }

        // GET: References/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id == null)
            {
                return NotFound();
            }

            var list = await _client.From<Reference>().Get();
            var reference = list.Models.FirstOrDefault(m => m.Id == id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);*/
        }

        // POST: References/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            var list = await _client.From<Reference>().Get();
            var reference = list.Models.FirstOrDefault(m => m.Id == id);
            if (reference != null)
            {
                await _client.From<Reference>().Delete(reference);
            }

            return RedirectToAction(nameof(Index));*/
        }

        private bool ReferenceExists(int id)
        {
            return false;// _client.From<Reference>().Get().Result.Models.Any(e => e.Id == id);
        }
    }
}
