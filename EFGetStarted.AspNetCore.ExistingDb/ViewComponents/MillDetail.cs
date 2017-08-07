﻿using Microsoft.AspNetCore.Mvc;
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
            var items = await GetProdData(id);
            return View(items);
        }
        private Task<List<MillInformation>> GetItems(int id)
        {


            var result = db.MillInformation.Where(x => x.MillId == id).ToListAsync();

            

            return result;
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