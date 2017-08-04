using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MillData.Models;

namespace MillData.ViewComponents
{

    public class MillDetail : ViewComponent
    {
        private readonly MillDataContext db;

        public MillDetail(MillDataContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(
        int id)
        {
            var items = await GetItems(id);
            return View(items);
        }
        private Task<List<MillInformation>> GetItems(int id)
        {


            var result = db.MillInformation.Where(x => x.MillId == id).ToListAsync();

            

            return result;
        }

        public async Task<IActionResult> GetProdData(int? id)
        {
            var prodData = await db.ProductionData
                .Include(m => m.FkProdCat.ProdType)
                .Include(m => m.FkProdCat.Category)
                .SingleOrDefaultAsync(m => m.FkMillKey == id);

            return ViewData["ProdData"] = prodData;
        }
    }
}