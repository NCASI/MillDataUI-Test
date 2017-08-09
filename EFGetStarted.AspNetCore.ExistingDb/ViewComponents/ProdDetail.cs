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

        /****************************************************************************
         * GET: ProductionData
         * Handles queries to database using the IQueryable Linq provider. 
         * 
         * INPUT: 
         *      id: int value representing Mill ID (NOT MILLKEY)
         * 
         * OUTPUT:
         *      Aynchronous list of production data where Mill ID = ID. 
         * ***************************************************************************/
        public Task<List<ProductionData>> GetProdData(int? id)
        {
            
            int? key = getMillKey(id);

            //Queries the database to get data
            var prodData = db.ProductionData
                .Include(m => m.FkProdCat)
                .Include(m => m.FkSource)
                .Where(m => m.FkMillKey == key);

            return prodData.ToListAsync();
        }

        private int? getMillKey(int? id)
        {
            var results = db.MillInformation.Where(m => m.MillId == id)
                            .Select(u => new { key = u.PkMillKey }).Single();
            int key = results.key;
            return key;
        }
    }
}
