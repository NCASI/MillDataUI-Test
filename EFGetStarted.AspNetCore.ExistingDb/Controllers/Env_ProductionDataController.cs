using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MillData.Models;

namespace MillData.Controllers
{
    public class Env_ProductionDataController : Controller
    {
        private readonly MillDataContext _context;

        public Env_ProductionDataController(MillDataContext context)
        {
            _context = context;    
        }

        // GET: Env_ProductionData
        public async Task<IActionResult> Index()
        {
            var millDataContext = _context.Env_ProductionData.Include(e => e.FkFacilityNavigation).Include(e => e.FkWoodThickness);
            return View(await millDataContext.ToListAsync());
        }

        // GET: Env_ProductionData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var env_ProductionData = await _context.Env_ProductionData
                .Include(e => e.FkFacilityNavigation)
                .Include(e => e.FkWoodThickness)
                .SingleOrDefaultAsync(m => m.PkEnvProdId == id);
            if (env_ProductionData == null)
            {
                return NotFound();
            }

            return View(env_ProductionData);
        }

        // GET: Env_ProductionData/Create
        public IActionResult Create()
        {
            ViewData["FkFacilityKey"] = new SelectList(_context.Env_Facility, "PkEnvFacilityKey", "PkEnvFacilityKey");
            ViewData["FkWoodThicknessId"] = new SelectList(_context.Env_WoodThickness, "PkWoodKey", "PkWoodKey");
            return View();
        }

        // POST: Env_ProductionData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkEnvProdId,FkFacilityKey,FkWoodThicknessId,ProdType,Category,Amount,Units,Comments")] Env_ProductionData env_ProductionData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(env_ProductionData);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["FkFacilityKey"] = new SelectList(_context.Env_Facility, "PkEnvFacilityKey", "PkEnvFacilityKey", env_ProductionData.FkFacilityKey);
            ViewData["FkWoodThicknessId"] = new SelectList(_context.Env_WoodThickness, "PkWoodKey", "PkWoodKey", env_ProductionData.FkWoodThicknessId);
            return View(env_ProductionData);
        }

        // GET: Env_ProductionData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var env_ProductionData = await _context.Env_ProductionData.SingleOrDefaultAsync(m => m.PkEnvProdId == id);
            if (env_ProductionData == null)
            {
                return NotFound();
            }
            ViewData["FkFacilityKey"] = new SelectList(_context.Env_Facility, "PkEnvFacilityKey", "PkEnvFacilityKey", env_ProductionData.FkFacilityKey);
            ViewData["FkWoodThicknessId"] = new SelectList(_context.Env_WoodThickness, "PkWoodKey", "PkWoodKey", env_ProductionData.FkWoodThicknessId);
            return View(env_ProductionData);
        }

        // POST: Env_ProductionData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkEnvProdId,FkFacilityKey,FkWoodThicknessId,ProdType,Category,Amount,Units,Comments")] Env_ProductionData env_ProductionData)
        {
            if (id != env_ProductionData.PkEnvProdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(env_ProductionData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Env_ProductionDataExists(env_ProductionData.PkEnvProdId))
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
            ViewData["FkFacilityKey"] = new SelectList(_context.Env_Facility, "PkEnvFacilityKey", "PkEnvFacilityKey", env_ProductionData.FkFacilityKey);
            ViewData["FkWoodThicknessId"] = new SelectList(_context.Env_WoodThickness, "PkWoodKey", "PkWoodKey", env_ProductionData.FkWoodThicknessId);
            return View(env_ProductionData);
        }

        // GET: Env_ProductionData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var env_ProductionData = await _context.Env_ProductionData
                .Include(e => e.FkFacilityNavigation)
                .Include(e => e.FkWoodThickness)
                .SingleOrDefaultAsync(m => m.PkEnvProdId == id);
            if (env_ProductionData == null)
            {
                return NotFound();
            }

            return View(env_ProductionData);
        }

        // POST: Env_ProductionData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var env_ProductionData = await _context.Env_ProductionData.SingleOrDefaultAsync(m => m.PkEnvProdId == id);
            _context.Env_ProductionData.Remove(env_ProductionData);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool Env_ProductionDataExists(int id)
        {
            return _context.Env_ProductionData.Any(e => e.PkEnvProdId == id);
        }
    }
}
