using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MillData.Models;

namespace MillData.ViewComponents
{
    public class EnvProdDetail : ViewComponent
    {
        private readonly MillDataContext db;

        public EnvProdDetail(MillDataContext context)
        {
            db = context;
        }
       public async Task<IViewComponentResult> InvokeAsync(
        int id)
        {
            //Gets mill key corresponding to the id
            MillSearchLogic keysearch = new MillSearchLogic(db);
            int? key = keysearch.getMillKeyFromId(id);
            int? facilityK = keysearch.getFacilityKeyFromMillKey(key);

            var items = await GetItems(facilityK);
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
        private Task<List<Env_ProductionData>> GetItems(int? key)
        {
            var result = db.Env_ProductionData
                .Include(m => m.FkFacilityKey)
                .Where(x => x.FkFacilityKey == key).ToListAsync();
            return result;
        }
    }
}