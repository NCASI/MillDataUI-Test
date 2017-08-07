using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MillData.Models;

namespace MillData.ViewComponents
{
    public class ProdDetail : ViewComponent
    {
        private readonly MillDataContext db;

        public ProdDetail(MillDataContext context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(
        int id)
        {
            var items = await GetProdData(id);
            return View(items);
        }
        public Task<List<ProductionData>> GetProdData(int? id)
        {
            var prodData = db.ProductionData
                .Include(m => m.FkProdCat)
                .Include(m => m.FkSource)
                .Where(m => m.FkMillKey == id);

            return prodData.ToListAsync();
        }
    }
}
