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
    public class CertificatesController : ControllerBase
    {
        private readonly Client _client;

        public CertificatesController(Client client)
        {
            _client = client;
        }

        // GET: References
        [HttpGet]
        public async Task<IActionResult> GetCertificates()
        {
            try
            {
                var list = await _client.From<Certification>().Get();

                var cleanedList = list.Models.Select(c => new
                {
                    c.Id,
                    c.Title,
                    c.Description,
                    c.Issuer,
                    c.IssueDate,
                    c.CredentialId,
                    c.VerificationLink
                }).ToList();

                return Ok(cleanedList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: References/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCertificateById(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var list = await _client.From<Certification>()
                    .Where(c => c.Id == id)
                    .Get();

                var reference = list.Models.Select(c => new
                {
                    c.Id,
                    c.Title,
                    c.Description,
                    c.Issuer,
                    c.IssueDate,
                    c.CredentialId,
                    c.VerificationLink
                });

                if (reference == null)
                {
                    return NotFound();
                }

                return Ok(reference);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: References/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertCertificate([Bind("Id,Names,Email,Cell,Relation,DateCreated")] Certification certificate)
        {
            if(certificate is null)
                return BadRequest("Reference data is null");

            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _client.From<Certification>().Insert(certificate);

                    return Ok(nameof(result));
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: References/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCertificate([Bind("Id,Names,Email,Cell,Relation,DateCreated")] Certification certificate)
        {
            if (certificate is null)
                return BadRequest("Certificate data is null");

            try
            {
                var cert = await _client.From<Certification>()
                    .Where(r => r.Id == certificate.Id)
                    .Single();

                if (cert == null)
                {
                    return NotFound();
                }



                return Ok(certificate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

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
