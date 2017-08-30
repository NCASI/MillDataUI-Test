using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MillData.Models;

namespace MillData.ViewComponents
{
    public class EnvFacDetail : ViewComponent
    {
        private readonly MillDataContext db;

        public EnvFacDetail(MillDataContext context)
        {
            db = context;
        }
       public async Task<IViewComponentResult> InvokeAsync(
        int id)
        {
            //Gets mill key corresponding to the id
            MillSearchLogic keysearch = new MillSearchLogic(db);
            int? key = keysearch.getMillKeyFromId(id);

            var items = await GetItems(key);
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
        private Task<List<Env_Facility>> GetItems(int? key)
        {
            var result = db.Env_Facility.Where(x => x.FkMillkey == key).ToListAsync();
            return result;
        }
    }
}