using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MillData.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<List<ProductionData>> GetProdDataWrapper(int? id)
        {
            var result = await GetProdData(id).ToAsyncEnumerable().ToList();
            return result;
        }
        public Task<ProductionData> GetProdData(int? id)
        {
            var prodData = db.ProductionData
                .Include(m => m.FkProdCat)
                .Include(m => m.FkProdCat)
                .FirstOrDefaultAsync(m => m.FkMillKey == id);

            return prodData;
        }
    }
}
