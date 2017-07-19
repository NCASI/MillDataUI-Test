using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFGetStarted.AspNetCore.ExistingDb.Models;

namespace EFGetStarted.AspNetCore.ExistingDb.Controllers
{
    public class MillInformationsController : Controller
    {
        private readonly MillDataContext _context;

        public MillInformationsController(MillDataContext context)
        {
            _context = context;    
        }

        // GET: MillInformations
        public async Task<IActionResult> Index()
        {
            var millDataContext = _context.MillInformation.Include(m => m.FkEpasubcat).Include(m => m.FkMillType);
            return View(await millDataContext.ToListAsync());
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
                .SingleOrDefaultAsync(m => m.PkMillKey == id);
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
            if (id != millInformation.PkMillKey)
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
                    if (!MillInformationExists(millInformation.PkMillKey))
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
                .SingleOrDefaultAsync(m => m.PkMillKey == id);
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
    }

    

    public class MillSearchLogic
    {
        private MillDataContext MillContext;
        private DbContextOptions<MillDataContext> options;

        public MillSearchLogic()
        {
            MillContext = new MillDataContext(options);
        }

        public IQueryable<MillInformation> SearchMill(MillSearchModel searchModel)
        {
            var result = MillContext.MillInformation.AsQueryable();

            if(searchModel != null)
            {
                result = result.Where(x => x.MillId == searchModel.MillId);
            }


            return result;
        }
    }

}
