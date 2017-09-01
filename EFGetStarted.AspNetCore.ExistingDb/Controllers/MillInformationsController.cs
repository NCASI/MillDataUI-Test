using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MillData.Models;
using Microsoft.Extensions.Configuration;

namespace MillData.Controllers
{
    public class MillInformationsController : Controller
    {
        private readonly MillDataContext _context;
       
        public MillInformationsController(MillDataContext context)
        {
            _context = context;
        }

        /***************************************************************************
         * GET: MillInformations
         * 
         * ARGUMENTS:
         *  -sortOrder: passed as GET param, tells the system which field to sort by.
         *  -IDSearchString: value to search Mill ID by.
         *  
         * INPUT:
         *      Uses the a context of type MillDataContext (see MillDataContext.cs).
         * 
         * OUTPUT:
         *      Returns a View of mill information results.
         *  
         *  ************************************************************************/
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IActionResult> Index(string sortOrder, string IDSearchString, int? id)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            //Create the mill data context and the results object to be modified
            var millDataContext = _context.MillInformation.Include(m => m.FkEpasubcat);
            var results = millDataContext.ToList();
            int idsearch = 0;

            //handle the Mill ID search param
            if (!String.IsNullOrEmpty(IDSearchString))
            {
                //parse the string into an int
                Int32.TryParse(IDSearchString, out idsearch);
                Console.WriteLine(IDSearchString);
                    
                //filter the results by mill ID
                //equivalent of SELECT * FROM MillInformation WHERE PK_MillKey = MillID
                results = results.Where(s => s.MillId.Equals(idsearch)).ToList();
                return View(results);
            }

            ViewBag.IDSort = String.IsNullOrEmpty(sortOrder) ? "id" : "";
            ViewBag.EPASort = String.IsNullOrEmpty(sortOrder) ? "epa" : "";
            ViewBag.IDSort = sortOrder == "id" ? "id_desc" : "id";
            ViewBag.EPASort = sortOrder == "epa" ? "epa_desc" : "epa";

            switch(sortOrder)
            {
                case "epa":
                    results = millDataContext.OrderBy(s => s.FkEpasubcatId).ToList();
                    break;
                case "epa_desc":
                    results = millDataContext.OrderByDescending(s => s.FkEpasubcatId).ToList();
                    break;
                case "id_desc":
                    results = millDataContext.OrderByDescending(s => s.MillId).ToList();
                    break;
                case "id":
                    results = millDataContext.OrderBy(s => s.MillId).ToList();
                    break;
                default:
                    results = millDataContext.OrderBy(s => s.MillId).ToList();
                    break;
            }

            if (id != null)
            {
                results = results.Where(s => s.MillId >= id).ToList();
                return View(results);

            }


            return View(results);
        }

        // GET: MillInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var millInformation = await _context.MillInformation
                .Include(m => m.FkEpasubcat)
                .Include(m => m.FkMillType)
                .SingleOrDefaultAsync(m => m.MillId == id);
            if (millInformation == null)
            {
                return NotFound();
            }

            return View(millInformation);
        }

        // GET: MillInformations/Create
        public IActionResult Create()
        {
            ViewData["FkEpasubcatId"] = new SelectList(_context.Epasubcat, "PkSubcatId", "Subcat");
            ViewData["FkMillTypeId"] = new SelectList(_context.MillType, "PkTypeId", "PkTypeId");
            return View();
        }

        // POST: MillInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkMillKey,MillId,FkMillTypeId,Company,Latitude,Longitude,FkEpasubcatId,Naprodcat,ProdCat1,ProdCat2,ShippingAddress,ShippingAddress2,ShippingCity,ShippingState,ShippingPostcode,ShippingCountry,PostalAddress,PostalAddress2,PostalCity,PostalState,PostalPostcode,PostalCountry,Eparegion,Website,Comments,MillStatus,StatusDate")] MillInformation millInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(millInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["FkEpasubcatId"] = new SelectList(_context.Epasubcat, "PkSubcatId", "Subcat", millInformation.FkEpasubcatId);
            ViewData["FkMillTypeId"] = new SelectList(_context.MillType, "PkTypeId", "PkTypeId", millInformation.FkMillTypeId);
            return View(millInformation);
        }

        // GET: MillInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var millInformation = await _context.MillInformation.SingleOrDefaultAsync(m => m.PkMillKey == id);
            if (millInformation == null)
            {
                return NotFound();
            }
            ViewData["FkEpasubcatId"] = new SelectList(_context.Epasubcat, "PkSubcatId", "Subcat", millInformation.FkEpasubcatId);
            ViewData["FkMillTypeId"] = new SelectList(_context.MillType, "PkTypeId", "PkTypeId", millInformation.FkMillTypeId);
            return View(millInformation);
        }

        // POST: MillInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkMillKey,MillId,FkMillTypeId,Company,Latitude,Longitude,FkEpasubcatId,Naprodcat,ProdCat1,ProdCat2,ShippingAddress,ShippingAddress2,ShippingCity,ShippingState,ShippingPostcode,ShippingCountry,PostalAddress,PostalAddress2,PostalCity,PostalState,PostalPostcode,PostalCountry,Eparegion,Website,Comments,MillStatus,StatusDate")] MillInformation millInformation)
        {
            if (id != millInformation.MillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(millInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MillInformationExists(millInformation.MillId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["FkEpasubcatId"] = new SelectList(_context.Epasubcat, "PkSubcatId", "Subcat", millInformation.FkEpasubcatId);
            ViewData["FkMillTypeId"] = new SelectList(_context.MillType, "PkTypeId", "PkTypeId", millInformation.FkMillTypeId);
            return View(millInformation);
        }

        // GET: MillInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var millInformation = await _context.MillInformation
                .Include(m => m.FkEpasubcat)
                .Include(m => m.FkMillType)
                .SingleOrDefaultAsync(m => m.MillId == id);
            if (millInformation == null)
            {
                return NotFound();
            }

            return View(millInformation);
        }

        // POST: MillInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var millInformation = await _context.MillInformation.SingleOrDefaultAsync(m => m.PkMillKey == id);
            _context.MillInformation.Remove(millInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MillInformationExists(int id)
        {
            return _context.MillInformation.Any(e => e.PkMillKey == id);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        public IActionResult GetAjax(string id)
        {
            int chosenid = Int32.Parse(id);
            var millDataContext = _context.MillInformation.Include(m => m.FkEpasubcat);
            var results = millDataContext.ToList();
            if (id != null)
            {
                 results = results.Where(s => s.MillId >= chosenid).ToList();
                return View(results);

            }
            else
            {
                return View();
            }
        }
    }
}
