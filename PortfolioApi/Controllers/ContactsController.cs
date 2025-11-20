using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Services;
using Supabase;

namespace Portfolio.Controllers
{
    public class ContactsController : Controller
    {
        private readonly Client _client;
        private readonly MailKitSender _sender;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private List<Contact> _contacts;

        public ContactsController(Client client, IWebHostEnvironment env, IConfiguration configuration, MailKitSender sender)
        {
            _client = client;
            _configuration = configuration;
            _env = env;
            _contacts = _client.From<Contact>().Get().Result.Models;
            _sender = sender;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            await Task.Delay(100000);
            return NotFound();
            //var list = await _client.From<Contact>().Get();

            //return View();// list.Models);
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*if (id == null)
            {
                return NotFound();
            }

            var list = await _client.From<Contact>().Get();
            var contact = list.Models.Find(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);*/
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Names,Email,Phone,Message")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                //Insert into the db
                await _client.From<Contact>().Insert(contact);

                //Send email
                try
                {
                    await Task.Run(async () =>
                    {
                        string result2 = await _sender.SendEmail($"New message from {contact.Names} ({contact.Email}), \n{contact.Message}");
                        Debug.WriteLine(result2);
                    });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

                TempData["Success"] = "Message sent successfully!";
                return RedirectToAction(nameof(Create));
            }
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*if (id == null)
            {
                return NotFound();
            }

            var list = await _client.From<Contact>().Get();
            var contact = list.Models.Find(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);*/
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Names,Email,Phone,Message")] Contact contact)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _client.From<Contact>().Update(contact);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
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
            return View(contact);*/
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            if (id == null)
            {
                return NotFound();
            }

            var list = await _client.From<Contact>().Get();
            var contact = list.Models.Find(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);*/
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await Task.Delay(100000);
            return NotFound();
            /*
            var list = await _client.From<Contact>().Get();
            var contact = list.Models.Find(c => c.Id == id);
            if (contact != null)
            {
                await _client.From<Contact>().Delete(contact);
            }

            return RedirectToAction(nameof(Index));*/
        }

        private bool ContactExists(int id)
        {
            return false; // _client.From<Contact>().Get().Result.Models.Any(e => e.Id == id);
        }
    }
}
