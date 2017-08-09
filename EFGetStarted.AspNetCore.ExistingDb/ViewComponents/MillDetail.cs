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

        //Asynchronously calls GetItems
        public async Task<IViewComponentResult> InvokeAsync(
        int id)
        {
            var items = await GetItems(id);
            return View(items);
        }

        /****************************************************************************
         * GET: MillInformation
         * Handles queries to database using the IQueryable Linq provider. 
         * Does the same thing as the "Details" page.
         * 
         * INPUT: 
         *      id: int value representing Mill ID (NOT MILLKEY)
         * 
         * OUTPUT:
         *      Aynchronous list of Mills where Mill ID = ID. 
         * ***************************************************************************/
        private Task<List<MillInformation>> GetItems(int id)
        {
            var result = db.MillInformation.Where(x => x.MillId == id).ToListAsync();
            return result;
        }
    }
}