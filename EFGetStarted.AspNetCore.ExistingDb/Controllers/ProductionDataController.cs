using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MillData.Models;

namespace MillData.Controllers
{
    public class ProductionDataController : Controller
    {
        private readonly MillDataContext _context;

        public ProductionDataController(MillDataContext context)
        {
            _context = context;    
        }

        // GET: ProductionData
        public async Task<IActionResult> Index()
        {
            var millDataContext = _context.ProductionData.Include(p => p.FkMillKeyNavigation).Include(p => p.FkProdCat).Include(p => p.FkSource);
            return View(await millDataContext.ToListAsync());
        }

        // GET: ProductionData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionData = await _context.ProductionData
                .Include(p => p.FkMillKeyNavigation)
                .Include(p => p.FkProdCat)
                .Include(p => p.FkSource)
                .SingleOrDefaultAsync(m => m.PkProductionId == id);
            if (productionData == null)
            {
                return NotFound();
            }

            return View(productionData);
        }

        // GET: ProductionData/Create
        public IActionResult Create()
        {
            ViewData["FkMillKey"] = new SelectList(_context.MillInformation, "PkMillKey", "PkMillKey");
            ViewData["FkProdCatId"] = new SelectList(_context.NcasiprodCat, "PkProdCatId", "PkProdCatId");
            ViewData["FkSourceId"] = new SelectList(_context.Source, "PkSourceId", "DataSource");
            return View();
        }

        // POST: ProductionData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkProductionId,FkMillKey,FkProdCatId,Quantity,Units,FkSourceId,SourceYear,Comments")] ProductionData productionData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productionData);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["FkMillKey"] = new SelectList(_context.MillInformation, "PkMillKey", "PkMillKey", productionData.FkMillKey);
            ViewData["FkProdCatId"] = new SelectList(_context.NcasiprodCat, "PkProdCatId", "PkProdCatId", productionData.FkProdCatId);
            ViewData["FkSourceId"] = new SelectList(_context.Source, "PkSourceId", "DataSource", productionData.FkSourceId);
            return View(productionData);
        }

        // GET: ProductionData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionData = await _context.ProductionData.SingleOrDefaultAsync(m => m.PkProductionId == id);
            if (productionData == null)
            {
                return NotFound();
            }
            ViewData["FkMillKey"] = new SelectList(_context.MillInformation, "PkMillKey", "MillId", productionData.FkMillKey);
            ViewData["FkProdCatId"] = new SelectList(_context.NcasiprodCat, "PkProdCatId", "Category", productionData.FkProdCatId);
            ViewData["FkSourceId"] = new SelectList(_context.Source, "PkSourceId", "DataSource", productionData.FkSourceId);
            return View(productionData);
        }

        // POST: ProductionData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkProductionId,FkMillKey,FkProdCatId,Quantity,Units,FkSourceId,SourceYear,Comments")] ProductionData productionData)
        {
            if (id != productionData.PkProductionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productionData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionDataExists(productionData.PkProductionId))
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
            ViewData["FkMillKey"] = new SelectList(_context.MillInformation, "PkMillKey", "MillId", productionData.FkMillKey);
            ViewData["FkProdCatId"] = new SelectList(_context.NcasiprodCat, "PkProdCatId", "Category", productionData.FkProdCatId);
            ViewData["FkSourceId"] = new SelectList(_context.Source, "PkSourceId", "DataSource", productionData.FkSourceId);
            return View(productionData);
        }

        // GET: ProductionData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionData = await _context.ProductionData
                .Include(p => p.FkMillKeyNavigation)
                .Include(p => p.FkProdCat)
                .Include(p => p.FkSource)
                .SingleOrDefaultAsync(m => m.PkProductionId == id);
            if (productionData == null)
            {
                return NotFound();
            }

            return View(productionData);
        }

        // POST: ProductionData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productionData = await _context.ProductionData.SingleOrDefaultAsync(m => m.PkProductionId == id);
            _context.ProductionData.Remove(productionData);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductionDataExists(int id)
        {
            return _context.ProductionData.Any(e => e.PkProductionId == id);
        }
    }
}
