using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MillData.Models;

namespace ViewComponentSample.ViewComponents
{
    public class MillDetailViewComponent : ViewComponent
    {
        private readonly MillDataContext db;

        public MillDetailViewComponent(MillDataContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(
        int maxPriority, bool isDone)
        {
            var items = await GetItemsAsync(maxPriority, isDone);
            return View(items);
        }
        private Task<List<MillInformation>> GetItemsAsync(int maxPriority, bool isDone)
        {
            //return db.MillInformation.Where(x => x.IsDone == isDone &&
            //                     x.Priority <= maxPriority).ToListAsync();
        }
    }
}