using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JoelMovies.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JoelMovies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieDbContext Context;

        public HomeController(ILogger<HomeController> logger, MovieDbContext context)
        {
            _logger = logger;
            Context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] 
        public IActionResult EnterMovies()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult EnterMovies(ApplicationResponse appResponse)
        {
            if (ModelState.IsValid)
            {
                //ADD THE ENTERED MOVIE TO MY DATABASE
                Context.applicationResponses.Add(appResponse);
                //TempStorage.AddApplication(appResponse);
                return View("Index");
            }
            else
            {
                return View();
            }

        }

       // public IActionResult MovieList()
        //{
        //    return View(Context.applicationResponses);
        //}

        public IActionResult MyPodcasts()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> List()
        {
            return View(await Context.applicationResponses.ToListAsync());
        }

        // GET: ApplicationResponseCRUD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationResponse = await Context.applicationResponses
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (applicationResponse == null)
            {
                return NotFound();
            }

            return View(applicationResponse);
        }

        // GET: ApplicationResponseCRUD/Create
        public IActionResult Create()
        {
            return View("Create");
        }

        // POST: ApplicationResponseCRUD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //BIND: sends model level data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Category,Title,Year,Director,Rating,Edited,LentTo,Notes")] ApplicationResponse applicationResponse)
        {
            if (ModelState.IsValid)
            {
                Context.Add(applicationResponse);
                //When  in an async method use the savechangesAsync
                await Context.SaveChangesAsync();
                //Takes us back to the index page
                return RedirectToAction(nameof(Index));
            }
            return View(applicationResponse);
        }

        // GET: ApplicationResponseCRUD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationResponse = await Context.applicationResponses.FindAsync(id);
            if (applicationResponse == null)
            {
                return NotFound();
            }
            return View(applicationResponse);
        }

        // POST: ApplicationResponseCRUD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Category,Title,Year,Director,Rating,Edited,LentTo,Notes")] ApplicationResponse applicationResponse)
        {
            if (id != applicationResponse.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Context.Update(applicationResponse);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationResponseExists(applicationResponse.MovieId))
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
            return View(applicationResponse);
        }

        // GET: ApplicationResponseCRUD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationResponse = await Context.applicationResponses
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (applicationResponse == null)
            {
                return NotFound();
            }

            return View(applicationResponse);
        }

        // POST: ApplicationResponseCRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationResponse = await Context.applicationResponses.FindAsync(id);
            Context.applicationResponses.Remove(applicationResponse);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationResponseExists(int id)
        {
            return Context.applicationResponses.Any(e => e.MovieId == id);
        }
    }
}
