using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MillData.Models;

namespace MillData.Controllers
{
    public class Env_FacilityController : Controller
    {
        private readonly MillDataContext _context;

        public Env_FacilityController(MillDataContext context)
        {
            _context = context;    
        }

        // GET: Env_Facility
        public async Task<IActionResult> Index()
        {
            var millDataContext = _context.Env_Facility.Include(e => e.FkMillInformation).Include(e => e.FkNcasiProdcat);
            return View(await millDataContext.ToListAsync());
        }

        // GET: Env_Facility/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var env_Facility = await _context.Env_Facility
                .Include(e => e.FkMillInformation)
                .Include(e => e.FkNcasiProdcat)
                .SingleOrDefaultAsync(m => m.PkEnvFacilityKey == id);
            if (env_Facility == null)
            {
                return NotFound();
            }

            return View(env_Facility);
        }

        // GET: Env_Facility/Create
        public IActionResult Create()
        {
            ViewData["FkMillkey"] = new SelectList(_context.MillInformation, "PkMillKey", "PkMillKey");
            ViewData["FkProdCatId"] = new SelectList(_context.NcasiprodCat, "PkProdCatId", "PkProdCatId");
            return View();
        }

        // POST: Env_Facility/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkEnvFacilityKey,FkMillkey,NotAfpa,FkParentKey,Year,Company,HasCodischarge,CoBod,CoTss,CoFlow,CoSludge,CoAllSw,CoBoilers,CoTri,FkProdCatId,Eprodcat,MosOp,PrimaryProd,SecondaryProd,NumSpills,SpillComments,Penalty,PenaltyComments,GenComments,FossilFuelComments,BiomassComments,EnergyComments,NtProducts")] Env_Facility env_Facility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(env_Facility);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["FkMillkey"] = new SelectList(_context.MillInformation, "PkMillKey", "PkMillKey", env_Facility.FkMillkey);
            ViewData["FkProdCatId"] = new SelectList(_context.NcasiprodCat, "PkProdCatId", "PkProdCatId", env_Facility.FkProdCatId);
            return View(env_Facility);
        }

        // GET: Env_Facility/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var env_Facility = await _context.Env_Facility.SingleOrDefaultAsync(m => m.PkEnvFacilityKey == id);
            if (env_Facility == null)
            {
                return NotFound();
            }
            ViewData["FkMillkey"] = new SelectList(_context.MillInformation, "PkMillKey", "PkMillKey", env_Facility.FkMillkey);
            ViewData["FkProdCatId"] = new SelectList(_context.NcasiprodCat, "PkProdCatId", "PkProdCatId", env_Facility.FkProdCatId);
            return View(env_Facility);
        }

        // POST: Env_Facility/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkEnvFacilityKey,FkMillkey,NotAfpa,FkParentKey,Year,Company,HasCodischarge,CoBod,CoTss,CoFlow,CoSludge,CoAllSw,CoBoilers,CoTri,FkProdCatId,Eprodcat,MosOp,PrimaryProd,SecondaryProd,NumSpills,SpillComments,Penalty,PenaltyComments,GenComments,FossilFuelComments,BiomassComments,EnergyComments,NtProducts")] Env_Facility env_Facility)
        {
            if (id != env_Facility.PkEnvFacilityKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(env_Facility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Env_FacilityExists(env_Facility.PkEnvFacilityKey))
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
            ViewData["FkMillkey"] = new SelectList(_context.MillInformation, "PkMillKey", "PkMillKey", env_Facility.FkMillkey);
            ViewData["FkProdCatId"] = new SelectList(_context.NcasiprodCat, "PkProdCatId", "PkProdCatId", env_Facility.FkProdCatId);
            return View(env_Facility);
        }

        // GET: Env_Facility/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var env_Facility = await _context.Env_Facility
                .Include(e => e.FkMillInformation)
                .Include(e => e.FkNcasiProdcat)
                .SingleOrDefaultAsync(m => m.PkEnvFacilityKey == id);
            if (env_Facility == null)
            {
                return NotFound();
            }

            return View(env_Facility);
        }

        // POST: Env_Facility/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var env_Facility = await _context.Env_Facility.SingleOrDefaultAsync(m => m.PkEnvFacilityKey == id);
            _context.Env_Facility.Remove(env_Facility);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool Env_FacilityExists(int id)
        {
            return _context.Env_Facility.Any(e => e.PkEnvFacilityKey == id);
        }
    }
}
