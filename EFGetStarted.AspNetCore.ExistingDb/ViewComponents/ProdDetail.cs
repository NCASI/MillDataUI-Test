using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MillData.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;

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
            //Gets mill key corresponding to the id
            MillSearchLogic keysearch = new MillSearchLogic(db);
            int? key = keysearch.getMillKey(id);
            if (key > 0)
            {
                var items = await GetProdData(key);
                return View(items);
            }
            else
                return Content("");
            
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
            

           
                //Queries the database to get data
                var prodData = db.ProductionData
                    .Include(m => m.FkProdCat)
                    .Include(m => m.FkSource)
                    .Where(m => m.FkMillKey == id);
                return prodData.ToListAsync(); 
        }

        
    }
}